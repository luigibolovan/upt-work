package ro.upt.ac.ssc;

import java.math.BigInteger;

public class Main {

    /**
     * Solution 1
     */
    public static void main(String[] args) {
        BigInteger n = new BigInteger("837210799");
        BigInteger e1 = new BigInteger("7");
        BigInteger d1 = new BigInteger("478341751");
        BigInteger e2 = new BigInteger("17");


        /**
         *  de = 1 modf(n);
         *  de = 1 + k * f(n); => k = aproximare_prin_adaos( (de - 1) / n );
         */
        BigInteger k;
        BigInteger k_numarator = d1.multiply(e1).subtract(BigInteger.ONE);
        if (k_numarator.mod(n).equals(BigInteger.ZERO)) {
            k = k_numarator.divide(n);
        } else {
            k = k_numarator.divide(n).add(BigInteger.ONE);
        }

        /**
         * pq = n; f(n) = (p-1)(q-1) = pq - (p + q) + 1; p + q = ?
         *
         * pq + 1 - ((de - 1)/k) = p + q
        */

        BigInteger pPLUSq;
        pPLUSq = k.multiply(n).add(k).subtract(e1.multiply(d1)).divide(k);

        /**
         * p + q = pPLUSq
         * pq = n
         *
         * x^2 - Sx + P = 0 => p & q sunt solutiile ecuatiei de gradul 2;
         */
        BigInteger p;
        BigInteger q;
        BigInteger delta;

        delta = pPLUSq.multiply(pPLUSq).subtract(new BigInteger("4").multiply(n));

        //sqrt for BigInteger not available in jdk 8
        p = pPLUSq.add(delta.sqrt()).divide(BigInteger.TWO);
        q = pPLUSq.subtract(delta.sqrt()).divide(BigInteger.TWO);

        System.out.println(p);
        System.out.println(q);

        /**
         * d2 = (e2)^(-1) mod(p-1)(q-1)
         */
        BigInteger d2;

        d2 = BigInteger.ONE.divide(e1).mod(p.subtract(BigInteger.ONE).multiply(q.subtract(BigInteger.ONE)));

        System.out.println(d2);// 246205313
    }
}
