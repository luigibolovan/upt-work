package workers;

import com.google.common.eventbus.EventBus;
import com.google.common.eventbus.Subscribe;
import events.DoneAddingEvent;
import events.DoneCuttingEvent;

/**
 * @author Luigi Bolovan
 *
 * Subscribed to order manager.
 */
public class SeatCutter extends Assembler {

    public SeatCutter(EventBus eventBus) {
        super(eventBus);
        mEventBus.register(this);
    }

    @Subscribe
    private void subscribeTo(DoneAddingEvent assemblingEvent){
        mChair = assemblingEvent.getEventChair();
        mEventBus.post(new DoneCuttingEvent(mChair));
        System.out.println("Seat cutter: Cut seat for " + mChair);

    }
}
