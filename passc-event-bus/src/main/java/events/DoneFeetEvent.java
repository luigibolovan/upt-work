package events;

import products.ChairInProgress;

/**
 * @author Luigi Bolovan
 *
 * Event posted after the chair's feet are assembled.
 * Stabilizer bar assembler is subscribed to this event.
 */
public class DoneFeetEvent extends AssemblingEvent {
    public DoneFeetEvent(ChairInProgress eventChair) {
        super(eventChair);
    }
}
