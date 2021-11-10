package ro.upt.ac.ssc;

import javax.crypto.Cipher;
import java.security.Key;
import java.security.KeyPair;
import java.security.KeyPairGenerator;

/**
 * implementați o aplicație Java care criptează un mesaj la alegere folosind criptosistemul RSA
 */

public class Main {

    public static void main(String[] args) throws Exception{
        final String message2Encrypt = "Test1234567890";

        Cipher rsa = Cipher.getInstance("RSA/ECB/PKCS1Padding");

        KeyPairGenerator rsaKeyGenerator = KeyPairGenerator.getInstance("RSA");

        rsaKeyGenerator.initialize(1024);

        KeyPair rsaKeyPair = rsaKeyGenerator.generateKeyPair();

        Key publicKey   = rsaKeyPair.getPublic();
        Key prvKey      = rsaKeyPair.getPrivate();

        rsa.init(Cipher.ENCRYPT_MODE, publicKey);

        byte[] cipherText = rsa.doFinal(message2Encrypt.getBytes());

        System.out.println(hexStringFromBytes(cipherText));
    }

    private static String hexStringFromBytes(byte[] array) {
        String myString = "";
        for (byte b : array) {
            int msn = (b >> 4) & 0x0F;
            int lsn = b & 0x0F;

            myString += getHexCharFromIntValue(msn);
            myString += getHexCharFromIntValue(lsn);
        }
        return myString;
    }

    private static char getHexCharFromIntValue(int value) {
       return (char) ((value <= 9) ? (value + '0') : (value + 55));
    }
}
