package ro.upt.ac.ssc;


import java.math.BigInteger;

public class Main {

    public static void main(String [] args) {
        BigInteger n = new BigInteger("5076313634899413540120536350051034312987619378778911504647420938544" +
                                          "7465177110314901155284204273194792744073890582538974985571109131603" +
                                          "02801741874277608327");
        BigInteger e = new BigInteger("3");
        BigInteger d = new BigInteger("3384209089932942360080357566700689541991746252519274336431613959029" +
                                          "8310118072592266557861250508877279212747197519861041620378008076415" +
                                          "22348207376583379547");


        BigInteger k_numarator = d.multiply(e).subtract(BigInteger.ONE);
        BigInteger k;
        if (k_numarator.mod(n).equals(BigInteger.ZERO)) {
            k = k_numarator.divide(n);
        } else {
            k = k_numarator.divide(n).add(BigInteger.ONE);
        }

        /**
         *  pq = n
         *  p + q?
         */

        BigInteger pPLUSq = k.multiply(n).add(k).subtract(d.multiply(e)).subtract(BigInteger.ONE);

        /**
         * x^2 - Sx + P = 0
         * S = p + q
         * P = pq = n
         */
        BigInteger delta = pPLUSq.multiply(pPLUSq).subtract(n.multiply(new BigInteger("4")));

        BigInteger p = pPLUSq.add(delta.sqrt()).divide(BigInteger.TWO);
        BigInteger q = pPLUSq.subtract(delta.sqrt()).divide(BigInteger.TWO);

        System.out.println("p = " + p);
        System.out.println("q = " + q);
    }
}
