package workers;

import com.google.common.eventbus.EventBus;
import com.google.common.eventbus.Subscribe;
import events.DoneStabilizerEvent;
import events.StopWorkingEvent;
import products.ChairInProgress;

/**
 * @author Luigi Bolovan
 *
 * Packs ChairInProgress.
 * It's subscribed to the stabilizer bar assembler.
 */
public class Packer {
    private ChairInProgress  mChair;
    private EventBus         mEventBus;
    private int              mStopValue;
    private int              mPackedChairsCounter;
    private final static int STOP_TIME_IN_MILLIS = 1000;

    public Packer(EventBus eventBus) {
        mEventBus = eventBus;
        mEventBus.register(this);
    }

    public void setStopValue(int stopValue){
        mStopValue = stopValue;
        System.out.println("Stop value:" + mStopValue);
    }

    @Subscribe
    private void subscribeTo(DoneStabilizerEvent assemblingEvent){
        mChair = assemblingEvent.getEventChair();
        mPackedChairsCounter++;
        System.out.println("Packer: Packed " + mChair);
        if(mPackedChairsCounter == mStopValue){
            mEventBus.post(new StopWorkingEvent()); //stop the assemblers
            try{
                System.out.println("Ending: "+ this.getClass());
                Thread.currentThread().join(STOP_TIME_IN_MILLIS);
            }catch(InterruptedException ie){
                ie.printStackTrace();
            }
        }
    }

    public void build() {

    }
}
