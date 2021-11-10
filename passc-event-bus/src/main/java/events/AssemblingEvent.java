package events;

import products.ChairInProgress;

/**
 * @author Luigi Bolovan
 *
 * Assembling events' base class.
 * Stores the chair that is being passed through the event bus between workers.
 */
public abstract class AssemblingEvent {
    protected ChairInProgress mChair;

    public AssemblingEvent(ChairInProgress chairInProgress){
        mChair = chairInProgress;
    }

    public synchronized ChairInProgress getEventChair(){
        return mChair;
    }
}
