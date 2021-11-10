package workerManagement;

import com.google.common.eventbus.EventBus;
import workers.*;

/**
 * @author Luigi Bolovan
 *
 * Ensures the parallelism of the working process.
 */
public class WorkerManagerDef implements WorkerManager {
    private Packer mPacker;
    private Assembler mSeatCutter;
    private Assembler mFeetAssembler;
    private Assembler mBackrestAssembler;
    private Assembler mStabilizerBarAssembler;

    /**
     * Instantiates the workers
     * @param eventBus - the EventBus where the workers will post their events
     */
    public void initializeWorkers(EventBus eventBus) {
        mPacker = new Packer(eventBus);
        mSeatCutter = new SeatCutter(eventBus);
        mFeetAssembler = new FeetAssembler(eventBus);
        mBackrestAssembler = new BackrestAssembler(eventBus);
        mStabilizerBarAssembler = new StabilizerBarAssembler(eventBus);
    }

    /**
     * Starts the threads on which every worker will perform its job
     */
    public void startWorkers() {
        Thread seatCutterJob = new Thread(new Runnable() {
            @Override
            public void run() {
                mSeatCutter.build();
            }
        });
        Thread feetAssemblerJob = new Thread(new Runnable() {
            public void run() {
                mFeetAssembler.build();
            }
        });
        Thread backrestAssemblerJob = new Thread(new Runnable() {
            public void run() {
                mBackrestAssembler.build();
            }
        });
        Thread stabilizerBarAssemblerJob = new Thread(new Runnable() {
            public void run() {
                mStabilizerBarAssembler.build();
            }
        });
        Thread packerJob = new Thread(new Runnable() {
            public void run() {
                mPacker.build();
            }
        });

       packerJob.start();
       seatCutterJob.start();
       feetAssemblerJob.start();
       backrestAssemblerJob.start();
       stabilizerBarAssemblerJob.start();
    }

    @Override
    public void setStopConditions(int mNumberOfChairsOrdered) {
        mPacker.setStopValue(mNumberOfChairsOrdered);
    }
}
