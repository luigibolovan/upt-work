package events;

import products.ChairInProgress;

/**
 * @author Luigi Bolovan
 *
 * Event posted after the seat is cut.
 * Backrest assembler is the one that is subscribed to this event.
 */
public class DoneCuttingEvent extends AssemblingEvent {

    public DoneCuttingEvent(ChairInProgress eventChair) {
        super(eventChair);
    }
}
