package events;

import products.ChairInProgress;


/**
 * @author Luigi Bolovan
 *
 * Event posted after the stabilizer bar is assembled
 * Packer is subscribed to this event.
 */
public class DoneStabilizerEvent extends AssemblingEvent {
    public DoneStabilizerEvent(ChairInProgress eventChair) {
        super(eventChair);
    }
}
