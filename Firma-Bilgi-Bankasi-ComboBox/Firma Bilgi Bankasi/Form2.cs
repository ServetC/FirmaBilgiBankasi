using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;

namespace Firma_Bilgi_Bankasi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form girisfrm = new giris();
            girisfrm.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sektor sfm = new sektor();
            sfm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kaydet kfm = new kaydet();
            kfm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guncelle gncl = new guncelle();
            gncl.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sil silform = new sil();
            silform.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ara araform = new ara();
            araform.ShowDialog();
        }

        private void Form2_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
