package events;

import products.ChairInProgress;

/**
 * @author Luigi Bolovan
 *
 * Event used after adding a new chair in the event bus.
 * Seat cutter, because it's the first worker in the build process, is the one that is subscribed to this event
 */
public class DoneAddingEvent extends AssemblingEvent {

    public DoneAddingEvent(ChairInProgress chairInProgress) {
        super(chairInProgress);
    }
}
