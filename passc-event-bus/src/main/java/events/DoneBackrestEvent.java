package events;

import products.ChairInProgress;

/**
 * @author Luigi Bolovan
 *
 * Event that is posted after the backrest is being assembled.
 * Feet assembler is subscribed to this event
 */
public class DoneBackrestEvent extends AssemblingEvent {

    public DoneBackrestEvent(ChairInProgress eventChair) {
        super(eventChair);
    }
}
