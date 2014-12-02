using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestDecrypt
{
    public partial class Form1 : Form
    {
        Enc Encrypt = new Enc("lafwjatjwatotuatu923178296378632068230962862907sd90f780a");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("test.txt");
            sw.Write(Encrypt.EncryptData(textBox1.Text));
            sw.Flush();
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textEncrypte;
            StreamReader sr = new StreamReader("test.txt");
            textEncrypte = sr.ReadToEnd();
            textBox2.Text = Encrypt.DecryptData(textEncrypte);
        }
    }
}
