package workers;

import com.google.common.eventbus.EventBus;
import com.google.common.eventbus.Subscribe;
import events.DoneBackrestEvent;
import events.DoneFeetEvent;

/**
 * @author Luigi Bolovan
 *
 * Subscribed to backrest assembler
 */
public class FeetAssembler extends Assembler {

    public FeetAssembler(EventBus eventBus) {
        super(eventBus);
        mEventBus.register(this);
    }

    @Subscribe
    private void subscribeTo(DoneBackrestEvent assemblingEvent){
        mChair = assemblingEvent.getEventChair();
        mEventBus.post(new DoneFeetEvent(mChair));
        System.out.println("Feet assembler: Feet assembled for " + mChair);
    }
}
