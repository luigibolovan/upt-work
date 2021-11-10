using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Deployment.Application;

namespace SymmetricEncyptionForm
{
    public partial class Form1 : Form
    {
        SymmetricAlgorithm mSymmetricAlgo;
        ConversionHelper myConversionHelper = new ConversionHelper();
        public Form1()
        {
            InitializeComponent();
            algorithmComboBox.Items.Add("DES");
            algorithmComboBox.Items.Add("3DES");
            algorithmComboBox.Items.Add("Rijndael");
        }

        private void generateKeyIVBtn_Click(object sender, EventArgs e)
        {
            if (algorithmComboBox.SelectedItem == null)
            {
                errorLabel.Text = "Please select an algorithm from the dropdown";
                return;
            }

            string algorithm = algorithmComboBox.SelectedItem.ToString();

            switch (algorithm)
            {
                case "DES":
                    mSymmetricAlgo = DES.Create();
                    break;
                case "3DES":
                    mSymmetricAlgo = TripleDES.Create();
                    break;
                case "Rijndael":
                    mSymmetricAlgo = Rijndael.Create();
                    break;
            }
            mSymmetricAlgo.GenerateIV();
            ivTextBox.Text = myConversionHelper.convertByteArrayToHEXString(mSymmetricAlgo.IV);
            mSymmetricAlgo.GenerateKey();
            keyTextBox.Text = myConversionHelper.convertByteArrayToHEXString(mSymmetricAlgo.Key);
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            if (keyTextBox.Text.Length == 0 || ivTextBox.Text.Length == 0)
            {
                errorLabel.Text = "Generate Key and IV";
                return;
            }
            
            if (plainTextASCIITextBox.Text.Length == 0)
            {
                errorLabel.Text = "No plain text to encrypt";
            }

            string plainTextString = plainTextASCIITextBox.Text.ToString();
            byte[] plainTextBytes = myConversionHelper.convertStringToByteArray(plainTextString);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, mSymmetricAlgo.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(plainTextBytes, 0 , plainTextBytes.Length);
            cs.Close();

            string cipherASCII  = myConversionHelper.convertBytesToASCIIString(ms.ToArray());
            string cipherHEX    = myConversionHelper.convertByteArrayToHEXString(ms.ToArray());

            cipherTextASCIITextBox.Text = cipherASCII;
            cipherTextHEXTextBox.Text   = cipherHEX;
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {

            if (cipherTextASCIITextBox.Text.Length == 0 || cipherTextHEXTextBox.Text.Length == 0)
            {
                errorLabel.Text = "No ciphertext";
            }

            byte[] cipherBytes = myConversionHelper.convertHEXStringToByteArray(cipherTextHEXTextBox.Text);
            byte[] plainTextBytes = new byte[cipherBytes.Length];
            MemoryStream ms = new MemoryStream(cipherBytes);
            CryptoStream cs = new CryptoStream(ms, mSymmetricAlgo.CreateDecryptor(), CryptoStreamMode.Read);

            cs.Read(plainTextBytes, 0, cipherBytes.Length);
            cs.Close();

            string plainTextASCII = myConversionHelper.convertBytesToASCIIString(plainTextBytes);
            string plainTextHEX = myConversionHelper.convertByteArrayToHEXString(plainTextBytes);

            plainTextASCIITextBox.Text = plainTextASCII;
            plainTextHEXTextBox.Text = plainTextHEX;
        }

        private void encryptTimeBtn_Click(object sender, EventArgs e)
        {
            string plainTextString = plainTextASCIITextBox.Text.ToString();
            byte[] plainTextBytes = myConversionHelper.convertStringToByteArray(plainTextString);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, mSymmetricAlgo.CreateEncryptor(), CryptoStreamMode.Write);


            long startTime = DateTime.Now.Ticks;
            int count = 10000000;
            for(int i = 0; i < count; i++)
                cs.Write(plainTextBytes, 0, plainTextBytes.Length);
            
            cs.Close();
            double howLong = DateTime.Now.Ticks - startTime;

            howLong = howLong / (10 * count);

            timeEncryptionLabel.Text = "Time/message at encryption:" + howLong.ToString() + "us";

        }

        private void decryptTimeBtn_Click(object sender, EventArgs e)
        {
            byte[] cipherBytes = myConversionHelper.convertHEXStringToByteArray(cipherTextHEXTextBox.Text);
            byte[] plainTextBytes = new byte[cipherBytes.Length];
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, mSymmetricAlgo.CreateDecryptor(), CryptoStreamMode.Read);

            long startTime = DateTime.Now.Ticks;
            int count = 10000000;
            for (int i = 0; i < count; i++)
                cs.Read(plainTextBytes, 0, cipherBytes.Length);
            cs.Close();

            double howLong = DateTime.Now.Ticks - startTime;

            howLong = howLong / (10 * count);

            decryptionTimeLabel.Text = "Time/message at decryption:" + howLong.ToString() + "us";
        }

        private void plainTextASCIITextBox_TextChanged(object sender, EventArgs e)
        {
            string currentText = plainTextASCIITextBox.Text.ToString();

            string currentHEX = myConversionHelper.convertStringToHEXString(currentText);
            plainTextHEXTextBox.Text = currentHEX;
        }

        private void plainTextHEXTextBox_TextChanged(object sender, EventArgs e)
        {
            string currentHEXText = plainTextHEXTextBox.Text.ToString();

            byte[] currentBytes = myConversionHelper.convertHEXStringToByteArray(currentHEXText);

            string currentASCIIText = myConversionHelper.convertBytesToASCIIString(currentBytes);
            plainTextASCIITextBox.Text = currentASCIIText;
        }

        private void cipherTextHEXTextBox_TextChanged(object sender, EventArgs e)
        {
            string currentHEXText = cipherTextHEXTextBox.Text.ToString();

            byte[] currentBytes = myConversionHelper.convertHEXStringToByteArray(currentHEXText);

            string currentASCIIText = myConversionHelper.convertBytesToASCIIString(currentBytes);
            cipherTextASCIITextBox.Text = currentASCIIText;
        }
    }
}
