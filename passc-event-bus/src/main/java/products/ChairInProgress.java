package products;

/**
 * @author Luigi Bolovan
 *
 *
 */
public class ChairInProgress {
    private static int  noOfInstances;
    private final int   mInstanceNumber;

    public ChairInProgress(){
        noOfInstances++;
        mInstanceNumber = noOfInstances;
    }

    public String toString(){
        return "Chair " + mInstanceNumber;
    }
}