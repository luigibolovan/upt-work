package orders;

import com.google.common.eventbus.EventBus;
import workerManagement.WorkerManager;

/**
 * @author Luigi Bolovan
 *
 */
public interface OrdersManager {
    void processOrder(EventBus mEventBus, WorkerManager mWorkerManger);
}
