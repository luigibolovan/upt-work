package workers;

import com.google.common.eventbus.EventBus;
import com.google.common.eventbus.Subscribe;
import events.DoneFeetEvent;
import events.DoneStabilizerEvent;

/**
 * @author Luigi Bolovan
 *
 * Subscribed to the feet assembler
 */
public class StabilizerBarAssembler extends Assembler {

    public StabilizerBarAssembler(EventBus eventBus) {
        super(eventBus);
        mEventBus.register(this);
    }

    @Subscribe
    private void subscribeTo(DoneFeetEvent assemblingEvent){
        mChair = assemblingEvent.getEventChair();
        mEventBus.post(new DoneStabilizerEvent(mChair));
        System.out.println("Stabilizer bar: Just added the stabilizer bar for " + mChair);

    }
}
