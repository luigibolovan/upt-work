package workers;

import com.google.common.eventbus.EventBus;
import com.google.common.eventbus.Subscribe;
import events.DoneBackrestEvent;
import events.DoneCuttingEvent;

/**
 * @author Luigi Bolovan
 *
 * Backrest assembler.
 * Subscribed to seat cutter.
 */
public class BackrestAssembler extends Assembler {

    public BackrestAssembler(EventBus eventBus) {
        super(eventBus);
        mEventBus.register(this);
    }

    @Subscribe
    private void subscribeTo(DoneCuttingEvent assemblingEvent){
        mChair = assemblingEvent.getEventChair();
        mEventBus.post(new DoneBackrestEvent(mChair));
        System.out.println("Backrest assembler: Assembled backrest for " + mChair);
    }
}
