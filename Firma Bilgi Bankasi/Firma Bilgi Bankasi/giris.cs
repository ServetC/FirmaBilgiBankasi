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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Kullanıcı Ekle")
            {
                groupBox1.Visible = true;
                groupBox1.Text = "Super Admin";
                groupBoxEkle.Visible = true;
                groupBoxSil.Visible = false;
                groupBoxDuzenle.Visible = false;
                this.MaximumSize = new Size(407,368);
                this.MinimumSize = new Size(407, 368);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

            }
            else if (comboBox1.Text == "Kullanıcı Sil")
            {
                groupBoxSil.Visible = true;
                groupBox1.Visible = true;
                groupBox1.Text = "Super Admin";
               
                groupBoxEkle.Visible = false;
                groupBoxDuzenle.Visible = false;
                this.MaximumSize = new Size(407, 321);
                this.MinimumSize = new Size(407, 321);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
              

            }
            else if (comboBox1.Text == "Kullanıcı Düzenle")
            {
                groupBoxDuzenle.Visible = true;
                groupBox1.Visible = true;
                groupBox1.Text = "Eski";
                groupBoxSil.Visible = false;
                groupBoxEkle.Visible = false;
                this.MaximumSize = new Size(407, 368);
                this.MinimumSize = new Size(407, 368);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
           
               
               
            }
            else 
            {
                groupBox1.Visible = false;
                groupBox1.Text = "Super Admin";
                groupBoxEkle.Visible = false;
                groupBoxSil.Visible = false;
                groupBoxDuzenle.Visible = false;
                this.MaximumSize = new Size(407, 368);
                this.MinimumSize = new Size(407, 368);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }

        string kadi, sifre, dkadi, dsifre, skadi, ssifre;
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Kullanıcı Ekle")
           {
              
               skadi = textBox1.Text.ToString();
               ssifre = textBox2.Text.ToString();
               kadi = textBox6.Text.ToString();
               sifre = textBox7.Text.ToString();

               if (kadi != "" && sifre != "" && skadi != "" && ssifre != "")
               {
                   int kontrol = 0, skontrol = 0;
                   sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");


                   sqlite_conn.Open();

                   sqlite_cmd = sqlite_conn.CreateCommand();


                   sqlite_cmd.CommandText = "SELECT * FROM giris";


                   sqlite_datareader = sqlite_cmd.ExecuteReader();

                   while (sqlite_datareader.Read())
                   {
                       dkadi = sqlite_datareader["kadi"].ToString();

                       if (kadi == dkadi)
                       {
                           kontrol = 1;
                           break;
                       }
                       else kontrol = 0;
                   }
                   if (kontrol == 0)
                   {

                       sqlite_cmd = sqlite_conn.CreateCommand();
                       sqlite_cmd.CommandText = "SELECT kadi, sifre FROM giris WHERE sa= 1";
                       sqlite_datareader = sqlite_cmd.ExecuteReader();

                       while (sqlite_datareader.Read())
                       {
                           if (ssifre == sqlite_datareader["sifre"].ToString() && skadi == sqlite_datareader["kadi"].ToString())
                           {
                               skontrol = 1;
                               break;
                           }
                           else skontrol = 0;
                       }

                       if (skontrol == 1)
                       {
                           if (textBox1.Text.ToString() != textBox6.Text.ToString())
                           {
                               sqlite_conn.Close();


                               sqlite_conn.Open();
                               sqlite_cmd = sqlite_conn.CreateCommand();

                               sqlite_cmd.CommandText = "INSERT INTO giris (kadi, sifre, sa) VALUES ('" + kadi + "', '" + sifre + "', 0);";

                               sqlite_cmd.ExecuteNonQuery();

                               sqlite_cmd.CommandText = "SELECT * FROM giris";

                               textBox1.Text = "";
                               textBox2.Text = "";
                               textBox6.Text = "";
                               textBox7.Text = "";
                               textBox1.Focus();

                           }
                           else
                           {
                               MessageBox.Show("Girilen kullanıcı adı Super Admine aittir.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               textBox6.Text = "";
                               textBox7.Text = "";
                               textBox6.Focus();
                           }
                       }
                       else
                       {
                           MessageBox.Show("Girilen Super Admin kullanıcı adı veya şifre hatalı.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           textBox1.Text = "";
                           textBox2.Text = "";
                           textBox1.Focus();
                       }
                   }
                   else
                   {
                       MessageBox.Show("Girilen kullanıcı adı veritabanında mevcuttur. \nLütfen kontrol edin...", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       textBox6.Text = "";
                       textBox7.Text = "";
                       textBox6.Focus();
                   }

                   sqlite_conn.Close();
               }
               else
               {
                   MessageBox.Show("Değerlerin hiçbiri boş bırakılamaz.\nLütfen değerleri kontrol edin.","İşlem Hatası",MessageBoxButtons.OK,MessageBoxIcon.Information);
                   textBox1.Focus();
               }
           }
        }

        private void giris_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(407, 368);
            this.MinimumSize = new Size(407, 368);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Kullanıcı Sil")
            {

                skadi = textBox1.Text.ToString();
                ssifre = textBox2.Text.ToString();
                kadi = textBox5.Text.ToString();

                if (kadi != "" && skadi != "" && ssifre != "")
                {
                    int kontrol = 0, skontrol = 0;
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "SELECT * FROM giris";

                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    while (sqlite_datareader.Read())
                    {
                        dkadi = sqlite_datareader["kadi"].ToString();

                        if (kadi == dkadi)
                        {
                            kontrol = 1;
                            break;
                        }
                        else kontrol = 0;
                    }
                    if (kontrol == 1)
                    {
                        sqlite_cmd = sqlite_conn.CreateCommand();
                        sqlite_cmd.CommandText = "SELECT kadi, sifre FROM giris WHERE sa= 1";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();

                        while (sqlite_datareader.Read())
                        {
                            if (ssifre == sqlite_datareader["sifre"].ToString() && skadi == sqlite_datareader["kadi"].ToString())
                            {
                                skontrol = 1;
                                break;
                            }
                            else skontrol = 0;
                        }

                        if (skontrol == 1)
                        {
                            if (textBox1.Text.ToString() != textBox5.Text.ToString())
                            {
                                sqlite_conn.Close();


                                sqlite_conn.Open();
                                sqlite_cmd = sqlite_conn.CreateCommand();

                                sqlite_cmd.CommandText = "DELETE FROM giris Where kadi='" + kadi + "';";

                                sqlite_cmd.ExecuteNonQuery();

                                sqlite_cmd.CommandText = "SELECT * FROM giris";

                                if(Form1.giriskadi==kadi)
                                {
                                    sqlite_conn.Close();
                                    Application.Restart();
                                }
                                else
                                {
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox5.Text = "";
                                    textBox1.Focus();

                                }
                            }
                            else
                            {
                                MessageBox.Show("Girilen kullanıcı adını silemezsiniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox5.Text = "";
                                textBox5.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Girilen Super Admin kullanıcı adı veya şifre hatalı.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox1.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Girilen kullanıcı adı veritabanında mevcut değildir. \nLütfen kontrol edin...", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox5.Text = "";
                        textBox5.Focus();
                    }

                    sqlite_conn.Close();
                }
                else
                {
                    MessageBox.Show("Değerlerin hiçbiri boş bırakılamaz.\nLütfen değerleri kontrol edin.", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
            }
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Kullanıcı Düzenle")
            {

                skadi = textBox1.Text.ToString();
                ssifre = textBox2.Text.ToString();
                kadi = textBox3.Text.ToString();
                sifre = textBox4.Text.ToString();

                if (kadi != "" && sifre != "" && skadi != "" && ssifre != "")
                {
                    int kontrol = 0, skontrol = 0;
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");


                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "SELECT * FROM giris";

                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    while (sqlite_datareader.Read())
                    {
                        dkadi = sqlite_datareader["kadi"].ToString();
                        dsifre = sqlite_datareader["sifre"].ToString();
                        if (skadi == dkadi && ssifre==dsifre)
                        {
                            kontrol = 1;
                            break;
                        }
                        else kontrol = 0;
                    }
                    if (kontrol == 1)
                    {
                        sqlite_cmd = sqlite_conn.CreateCommand();
                        sqlite_cmd.CommandText = "SELECT kadi, sifre FROM giris";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();

                        while (sqlite_datareader.Read())
                        {
                            if (kadi == sqlite_datareader["kadi"].ToString() && kadi!=skadi)
                            {
                                skontrol = 1;
                                break;
                            }
                            else skontrol = 0;
                        }

                        if (skontrol == 0)
                        {
                            sqlite_conn.Close();


                            sqlite_conn.Open();
                            sqlite_cmd = sqlite_conn.CreateCommand();

                            sqlite_cmd.CommandText = "Update giris Set kadi='" + kadi + "', sifre='" + sifre + "' Where kadi='" + skadi + "' and sifre='" + ssifre + "';";

                            sqlite_cmd.ExecuteNonQuery();

                            sqlite_cmd.CommandText = "SELECT * FROM giris";

                            sqlite_conn.Close();
                            Application.Restart();
                        }
                        else
                        {
                            MessageBox.Show("Girilen kullanıcı veritabanında mevcut.\nLütfen girilen değeri kontrol edin.","İşlem Hatası",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox3.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Girilen kullanıcı veritabanında mevcut değildir.\nLütfen girilen değeri kontrol edin.", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();
                    }
                    sqlite_conn.Close();
                }
                else
                {
                    MessageBox.Show("Değerlerin hiçbiri boş bırakılamaz.\nLütfen değerleri kontrol edin.", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
            }
        }

    }
}
