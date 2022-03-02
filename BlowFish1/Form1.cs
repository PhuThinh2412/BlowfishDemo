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
    public partial class Form1 : Form
    {
        public static string KEY = "";
        public static string CIPHER_TEXT = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plainText = rtbPlainText.Text;
            string key = txtKey.Text;
            
            //convert key to hexadecimal
            byte[] keyInBytes = Encoding.Default.GetBytes(key);
            string hexKey = BitConverter.ToString(keyInBytes);
            hexKey = hexKey.Replace("-", "");

            BlowFish blowfishAlgorithm = new BlowFish(hexKey); //caohochutech
            
            string cipherText = blowfishAlgorithm.Encrypt_CBC(plainText);
            rtbCipherText.Text = cipherText;
            //MessageBox.Show(cipherText, "Encrypted Message");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KEY = txtKey.Text;
            CIPHER_TEXT = rtbCipherText.Text;

            Form2 frm2 = new Form2();
            frm2.Show();
            
        }
    }
}
