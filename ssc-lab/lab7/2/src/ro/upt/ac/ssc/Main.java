package ro.upt.ac.ssc;


import javax.net.ssl.HttpsURLConnection;
import java.io.IOException;
import java.net.URL;
import java.security.cert.Certificate;

/**
 *
 * Certificate added via
 *
 * sudo keytool -importcert -cacerts -file <certificate_location>
 * certificate location : ../../../../../home/@user/Desktop/_.badssl.com
 */

public class Main {
    public static void main(String[] args) {
        String link = "https://self-signed.badssl.com";
        URL url;
        HttpsURLConnection urlConnection;

        try {
            url = new URL(link);
            urlConnection = (HttpsURLConnection) url.openConnection();

            System.out.println("Cipher suite: " + urlConnection.getCipherSuite());
            System.out.println();

            Certificate[] certificates = urlConnection.getServerCertificates();

            for (Certificate cert : certificates) {
                System.out.println("Cert PK Algorithm: " + cert.getPublicKey().getAlgorithm());
                System.out.println("Cert PK: " + cert.getPublicKey());
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
