import orders.OrdersManagerDef;
import workerManagement.WorkerManagerDef;

/**
 * @author Luigi Bolovan
 *
 * Dummy client class
 */
public class Client {

    public static void main(String[] args) {
        FurnitureFactory myFactory = new FurnitureFactory(new WorkerManagerDef(), new OrdersManagerDef());
        myFactory.order();
    }
}
