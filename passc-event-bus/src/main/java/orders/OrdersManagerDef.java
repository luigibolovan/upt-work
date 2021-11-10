package orders;

import com.google.common.eventbus.EventBus;
import com.google.common.eventbus.Subscribe;
import events.DoneAddingEvent;
import events.DoneCuttingEvent;
import workerManagement.WorkerManager;
import products.ChairInProgress;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * @author Luigi Bolovan
 *
 * Class responsible with generating the chairs in progress according with client's input
 */
public class OrdersManagerDef implements OrdersManager {
    private int mNumberOfChairsOrdered;
    private EventBus mEventBus;
    private WorkerManager mWorkerManager;

    /**
     * Method responsible with input processing.
     * @param eventBus - the event bus on which the workers will communicate
     * @param workerManger - the worker manager that handles the furniture factory's workers
     */
    public void processOrder(EventBus eventBus, WorkerManager workerManger) {
        System.out.print("Enter the desired number of chairs:");
        mNumberOfChairsOrdered = getNoOfChairs();

        mEventBus = eventBus;
        mEventBus.register(this);
        mWorkerManager = workerManger;

        //instruct every worker with the subscription plan regarding the eventbus
        workerManger.initializeWorkers(mEventBus);

        //set stop condition
        workerManger.setStopConditions(mNumberOfChairsOrdered);

        //initialize workers' threads and make them wait until a new chair appears
        workerManger.startWorkers();
        putChairOnEventBus(mEventBus);
    }

    @Subscribe
    private void subscribeToSeatCutter(DoneCuttingEvent cuttingEvent){
        putChairOnEventBus(mEventBus);
    }

    /**
     * Method that posts DoneAddingEvent type of event with new chairs
     * @param eventBus - the bus where the events will be posted
     */
    private void putChairOnEventBus(EventBus eventBus){
        if(mNumberOfChairsOrdered > 0) {
            mNumberOfChairsOrdered--;
            ChairInProgress next = new ChairInProgress();
            System.out.println("Order manager: Posted ChairInProgress" + next);
            eventBus.post(new DoneAddingEvent(next));

        }
    }

    private int getNoOfChairs(){
        int numberOfChairs = 0;
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        try{
            numberOfChairs = Integer.parseInt(reader.readLine());
        }catch(IOException ioe){
            System.out.println("Exception occurred when getting number of chairs");
            ioe.printStackTrace();
        }

        return numberOfChairs;
    }
}
