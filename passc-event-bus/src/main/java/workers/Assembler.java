package workers;

import com.google.common.eventbus.EventBus;
import com.google.common.eventbus.Subscribe;
import events.StopWorkingEvent;
import products.ChairInProgress;

/**
 * @author Luigi Bolovan
 *
 * Assemblers' base class
 * Embeds the main behavior of the assemblers
 */
public abstract class Assembler {
    protected EventBus        mEventBus;
    protected ChairInProgress mChair;
    private static final int  STOP_TIME_IN_MILLIS = 1000;

    public Assembler(EventBus eventBus){
        mEventBus = eventBus;
    }

    public synchronized void build(){
    }

    /**
     * When the packer finishes its job, this will be triggered on every object
     * @param stopEvent - the StopWorkingEvent that packer will post
     */
    @Subscribe
    protected void stopWhenStopEventOccurs(StopWorkingEvent stopEvent){
        try {
            System.out.println("Ending: " + this.getClass());
            Thread.currentThread().join(STOP_TIME_IN_MILLIS);
        }catch (InterruptedException ie){
            ie.printStackTrace();
        }
    }

}
