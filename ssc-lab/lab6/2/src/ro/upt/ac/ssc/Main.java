package ro.upt.ac.ssc;

import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;
import java.security.SecureRandom;
import java.util.Scanner;

/**
 * implementați o aplicație Java
 * care criptează un mesaj la alegere folosind
 * AES/128 în modul CBC cu PKCS5 padding și
 * o cheie secretă derivată dintr-o parolă introdusă de utilizator
 */

public class Main {

    public static void main(String[] args) throws Exception {

        final String plainText = "my plaintext";
        Cipher aes = Cipher.getInstance("AES/CBC/PKCS5Padding");
        SecureRandom prng = new SecureRandom();

        //input from user
        Scanner keyboard = new Scanner(System.in);
        System.out.print("Parola: ");
        String password = keyboard.nextLine();
        char[] passwordBytes = password.toCharArray();

        //key derivation
        byte[] salt = new byte[16];
        int iterations = 10000;
        int AESkeySize = 128;
        prng.nextBytes(salt);
        SecretKeyFactory keyFactory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
        PBEKeySpec pbeKeySpec       = new PBEKeySpec(passwordBytes, salt, iterations, AESkeySize);
        SecretKey myAESKey          = new SecretKeySpec(keyFactory.generateSecret(pbeKeySpec).getEncoded(),
                                               "AES");

        //aes encryption
        aes.init(Cipher.ENCRYPT_MODE, myAESKey);
        byte[] cipherText = new byte[16];
        int cipherLength = aes.update(plainText.getBytes(), 0,
                                      plainText.getBytes().length,
                                      cipherText, 0);
        cipherLength += aes.doFinal(cipherText, cipherLength);

        System.out.println(hexStringFromBytes(cipherText));

    }


    private static String hexStringFromBytes(byte[] array) {
        String returnedString = "";
        for (byte b : array) {
            int msn = (b >> 4) & 0x0F;
            int lsn = b & 0x0F;

            returnedString += getHexCharFromIntValue(msn);
            returnedString += getHexCharFromIntValue(lsn);
        }
        return returnedString;
    }

    private static char getHexCharFromIntValue(int value) {
        return (char) ((value <= 9) ? (value + '0') : (value + 55));
    }

}
