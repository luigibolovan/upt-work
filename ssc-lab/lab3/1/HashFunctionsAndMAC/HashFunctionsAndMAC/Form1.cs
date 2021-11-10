using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFunctionsAndMAC
{
    public partial class Form1 : Form
    {

        private MacHelper myMAC;
        private byte[] computed_tag;
        public Form1()
        {
            InitializeComponent();
            hashAlgorithms.Items.Add("SHA1");
            hashAlgorithms.Items.Add("MD5");
            hashAlgorithms.Items.Add("RIPEMD");
            hashAlgorithms.Items.Add("SHA256");
            hashAlgorithms.Items.Add("SHA384");
            hashAlgorithms.Items.Add("SHA512");
        }

        private void computeMACButton_Click(object sender, EventArgs e)
        {
            if (hashAlgorithms.SelectedItem == null)
            {
                errorLabel.Text = "Please select an algorithm from the dropdown";
                return;
            }

            string option = hashAlgorithms.SelectedItem.ToString();
            myMAC = new MacHelper(option);

            if (keyTextBox.Text.Length == 0)
            {
                errorLabel.Text = "ERROR: no key";
                return;
            }

            if (messageTextBox.Text.Length == 0)
            {
                errorLabel.Text = "ERROR: no plain text";
                return;
            }

            byte[] keyBytes         = Encoding.ASCII.GetBytes(keyTextBox.Text.ToString());
            byte[] plainTextBytes   = Encoding.ASCII.GetBytes(messageTextBox.Text.ToString());
            computed_tag = myMAC.getTag(plainTextBytes, keyBytes);

            string tagASCII = Encoding.ASCII.GetString(computed_tag);
            string tagHEX   = BitConverter.ToString(computed_tag);
            tagHEX = tagHEX.Replace("-", "");

            asciiMACTextBox.Text    = tagASCII;
            hexMACTextBox.Text      = tagHEX;
        }

        private void verifyMACButton_Click(object sender, EventArgs e)
        {
            if (keyTextBox.Text.Length == 0)
            {
                errorLabel.Text = "ERROR: no key";
                return;
            }

            if (messageTextBox.Text.Length == 0)
            {
                errorLabel.Text = "ERROR: no plain text";
                return;
            }

            if (asciiMACTextBox.Text.Length == 0)
            {
                errorLabel.Text = "ERROR: no tag";
                return;
            }

            byte[] plainTextBytes   = Encoding.ASCII.GetBytes(messageTextBox.Text.ToString());
            byte[] key              = Encoding.ASCII.GetBytes(keyTextBox.Text.ToString());


            if (myMAC.isAuthentic(plainTextBytes, computed_tag, key))
            {
                verifyLabel.Text = "Authentic";
            }
            else
            {
                verifyLabel.Text = "Corrupted";
            }

        }
    }
}
