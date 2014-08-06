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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string giriskadi, girissifre;
        string girisdkadi, girisdsifre;
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        private void button1_Click(object sender, EventArgs e)
        {

            giriskadi = textBox1.Text.ToString();
            girissifre = textBox2.Text.ToString();

            if (giriskadi != "" && girissifre != "")
            {
                int kontrol = 0;
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // But how do we read something out of our table ?
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT * FROM giris";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    girisdkadi = sqlite_datareader["kadi"].ToString();
                    girisdsifre = sqlite_datareader["sifre"].ToString();

                    if (giriskadi == girisdkadi && girissifre == girisdsifre)
                    {
                        kontrol = 1;
                        break;
                    }
                    else kontrol = 0;
                }
                if (kontrol == 1)
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı ya da Şifre hatalı. Girilen değerleri kontrol edin...", "Hatalı Giriş İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
              
                sqlite_conn.Close();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre boş bırakılamaz.\nGirirlen değerleri kontrol edin.","İşlem Hatası",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (giriskadi != "" && girissifre == "")
                {
                    textBox2.Focus();
                }
                else 
                {
                    textBox1.Focus();
                }
            }
        }

       
    }
}
