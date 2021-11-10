import com.google.common.eventbus.EventBus;
import orders.OrdersManager;
import workerManagement.WorkerManager;

/**
 * @author Luigi Bolovan
 *
 * Interface with the client.
 */
public class FurnitureFactory {
    private WorkerManager mWorkerManger;
    private OrdersManager mOrdersManager;
    private EventBus        mEventBus;

    public FurnitureFactory(WorkerManager workerManager, OrdersManager ordersManager){
        this.mWorkerManger  = workerManager;
        this.mOrdersManager = ordersManager;
        mEventBus           = new EventBus("furnitureFactory");
    }

    public void order(){
        mOrdersManager.processOrder(mEventBus, mWorkerManger);
    }
}
