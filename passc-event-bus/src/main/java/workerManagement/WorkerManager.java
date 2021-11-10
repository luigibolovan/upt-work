package workerManagement;

import com.google.common.eventbus.EventBus;

/**
 * @author Luigi Bolovan
 *
 * Interface for managing the workers.
 */
public interface WorkerManager {
    void initializeWorkers(EventBus eventBus);
    void startWorkers();
    void setStopConditions(int mNumberOfChairsOrdered);
}
