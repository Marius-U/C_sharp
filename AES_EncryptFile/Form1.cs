using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_EncryptFile
{
    public partial class Form1 : Form
    {
        static byte[] key        = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
        static byte[] plaintext  = { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };
        static byte[] iv         = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        static byte[] ciphertext = { 0x69, 0xC4, 0xE0, 0xD8, 0x6A, 0x7B, 0x04, 0x30, 0xD8, 0xCD, 0xB7, 0x80, 0x70, 0xB4, 0xC5, 0x5A };

        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes 
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm. 
            // We are going to use Rijndael because it is strong and
            // available on all platforms. 
            // You can use other algorithms, to do so substitute the
            // next line with something like 
            //      TripleDES alg = TripleDES.Create(); 
            AesManaged alg = new AesManaged();

            // Now set the key and the IV. 
            // We need the IV (Initialization Vector) because
            // the algorithm is operating in its default 
            // mode called CBC (Cipher Block Chaining).
            // The IV is XORed with the first block (8 byte) 
            // of the data before it is encrypted, and then each
            // encrypted block is XORed with the 
            // following block of plaintext.
            // This is done to make encryption more secure. 

            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure. 
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data. 
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream and the output will be written
            // in the MemoryStream we have provided. 
            CryptoStream cs = new CryptoStream(ms,
               alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption 
            cs.Write(clearData, 0, clearData.Length);

            // Close the crypto stream (or do FlushFinalBlock). 
            // This will tell it that we have done our encryption and
            // there is no more data coming in, 
            // and it is now a good time to apply the padding and
            // finalize the encryption process. 
            cs.Close();

            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way. 
            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        // Decrypt a byte array into a byte array using a key and an IV 
        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream that is going to accept the
            // decrypted bytes 
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm. 
            // We are going to use Rijndael because it is strong and
            // available on all platforms. 
            // You can use other algorithms, to do so substitute the next
            // line with something like 
            //     TripleDES alg = TripleDES.Create(); 
            AesManaged alg = new AesManaged();

            // Now set the key and the IV. 
            // We need the IV (Initialization Vector) because the algorithm
            // is operating in its default 
            // mode called CBC (Cipher Block Chaining). The IV is XORed with
            // the first block (8 byte) 
            // of the data after it is decrypted, and then each decrypted
            // block is XORed with the previous 
            // cipher block. This is done to make encryption more secure. 
            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure. 
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data. 
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream 
            // and the output will be written in the MemoryStream
            // we have provided. 
            CryptoStream cs = new CryptoStream(ms,
                alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption 
            cs.Write(cipherData, 0, cipherData.Length);

            // Close the crypto stream (or do FlushFinalBlock). 
            // This will tell it that we have done our decryption
            // and there is no more data coming in, 
            // and it is now a good time to remove the padding
            // and finalize the decryption process. 
            cs.Close();

            // Now get the decrypted data from the MemoryStream. 
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way. 
            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Plain text:  " + BitConverter.ToString(plaintext));

            byte[] encryptedBytes = Encrypt(plaintext, key, iv);
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText("Encripted:");
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText(BitConverter.ToString(encryptedBytes));
            textBox2.AppendText(Environment.NewLine);
           // textBox2.AppendText(System.Text.Encoding.Default.GetString(encryptedBytes));

            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText(Environment.NewLine);

            byte[] dencryptedBytes = Decrypt(encryptedBytes, key,iv);
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText("Decripted:");
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText(BitConverter.ToString(dencryptedBytes));
            
        }
    }
}
