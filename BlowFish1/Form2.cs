using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlowFishCS;

namespace BlowFish1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rtbCipherText.Text = Form1.CIPHER_TEXT;
            txtKey.Text = Form1.KEY;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string cipherText = rtbCipherText.Text;
            string key = txtKey.Text;

            //convert key to hexadecimal
            byte[] keyInBytes = Encoding.Default.GetBytes(key);
            string hexKey = BitConverter.ToString(keyInBytes);
            hexKey = hexKey.Replace("-", "");

            BlowFish blowfishAlgorithm = new BlowFish(hexKey); //caohochutech

            string decryptedString = blowfishAlgorithm.Decrypt_CBC(cipherText);
            rtbPlainText.Text = decryptedString;
        }
    }
}
