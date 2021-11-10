using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncyptionForm
{
    class ConversionHelper
    {

        public String convertBytesToASCIIString(byte[] byteArray)
        {
            return Encoding.ASCII.GetString(byteArray);
        }

        public String convertStringToHEXString(String msg)
        {
            string uglyHEX;
            byte[] msgBytes = Encoding.ASCII.GetBytes(msg);

            uglyHEX = BitConverter.ToString(msgBytes);

            return uglyHEX.Replace("-", "");
        }

        public String convertByteArrayToHEXString(byte[] byteArray)
        {
            string uglyHEX = BitConverter.ToString(byteArray);

            return uglyHEX.Replace("-", "");
        }

        public byte[] convertStringToByteArray(String msg)
        {
            return Encoding.ASCII.GetBytes(msg);
        }

        public byte[] convertHEXStringToByteArray(String hexString)
        {
            byte[] array = new byte[hexString.Length / 2];
            char[] charArray = hexString.ToCharArray();

            for (int i = 0; i < hexString.Length / 2; i++)
            {
                array[i] = (byte)(((hexCharToHexValue(charArray[2 * i]) << 4) & 0xF0) | ((hexCharToHexValue(charArray[2 * i + 1]) & 0x0f)));
            }

            return array;
        }

        private int hexCharToHexValue(char hexChar)
        {
            if(hexChar >= 'A' && hexChar <= 'F')
            {
                return hexChar - 55;
            }
            else
            {
                return hexChar - '0';
            }
        }
    }
}
