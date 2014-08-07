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
    public partial class sektor : Form
    {
        public sektor()
        {
            InitializeComponent();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Sektör Ekle")
            {
                groupBox1.Visible = true;
                groupBox3.Visible = false;
                groupBox2.Visible = false;
                this.MaximumSize = new Size(378, 350);
                this.MinimumSize = new Size(378, 350);
                textBox1.Text = "";
                textBox1.Focus();


                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "SELECT * FROM sektor order by adi asc";

                sqlite_datareader = sqlite_cmd.ExecuteReader();

                listBox1.Items.Clear();

                while (sqlite_datareader.Read())
                {
                    listBox1.Items.Add(sqlite_datareader.GetString(1));
                }
                sqlite_conn.Close();
            }
           
            else if (comboBox1.Text == "Sektör Güncelle")
            {
                groupBox1.Visible = false;
                groupBox3.Visible = true;
                groupBox2.Visible = false;
                this.MaximumSize = new Size(378, 290);
                this.MinimumSize = new Size(378, 290);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Focus();
            }

            else if (comboBox1.Text == "Sektör Sil")
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                groupBox3.Visible = false;

                this.MaximumSize = new Size(378, 183);
                this.MinimumSize = new Size(378, 183);
                textBox4.Text = "";
                textBox4.Focus();
            }
            else
            {
                groupBox1.Visible = false;
                groupBox3.Visible = false;
                this.MaximumSize = new Size(378, 350);
                this.MinimumSize = new Size(378, 350);

            }
        }
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Sektör Ekle")
            {
                if(textBox1.Text!="")
                {
                    int kontrol = 0;
                    string sektorismi,dsektorismi;
                    sektorismi = textBox1.Text.ToUpper();

                  
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();

                  
                    sqlite_cmd.CommandText = "SELECT * FROM sektor";

                    
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                   
                    while (sqlite_datareader.Read()) 
                    {
                        dsektorismi = sqlite_datareader.GetString(1);

                        if (dsektorismi == sektorismi)
                        {
                            kontrol = 1;
                            break;
                        }
                        else kontrol = 0;                       
                    }
                    if(kontrol==0)
                    {

                        sqlite_conn.Close();


                        sqlite_conn.Open();

                        listBox1.Items.Add(sektorismi);

                        sqlite_cmd = sqlite_conn.CreateCommand();

                        sqlite_cmd.CommandText = "INSERT INTO sektor (id, adi) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM sektor), '" + sektorismi + "');";

                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_conn.Close();

                        textBox1.Text = "";
                        textBox1.Focus();

                    }
                    else
                    {

                        sqlite_conn.Close();

                        MessageBox.Show("Girilen sektör ismi mevcuttur. Kontrol edin.", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                   
                  
                }
                else
                {
                    MessageBox.Show("Sektör ismi girilmemiştir. Kontrol edin.","İşlem Hatası",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Sektör Güncelle")
            {
                if(textBox2.Text!="" && textBox3.Text!="")
                {
                    int kontrol = 0,tkontrol=0;
                    string sektorismi,dsektorismi,ysektorismi;
                    sektorismi = textBox2.Text.ToUpper();
                    ysektorismi=textBox3.Text.ToUpper();
                  
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();

                  
                    sqlite_cmd.CommandText = "SELECT * FROM sektor";

                    
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                   
                    while (sqlite_datareader.Read()) 
                    {
                        dsektorismi = sqlite_datareader.GetString(1);

                        if (dsektorismi == sektorismi)
                        {
                            kontrol = 1;
                            break;
                        }
                        else kontrol = 0;                       
                    }
                    if (kontrol == 1)
                    {

                        sqlite_conn.Close();

                        sqlite_conn.Open();

                        sqlite_cmd = sqlite_conn.CreateCommand();


                        sqlite_cmd.CommandText = "SELECT * FROM sektor";


                        sqlite_datareader = sqlite_cmd.ExecuteReader();


                        while (sqlite_datareader.Read())
                        {
                            dsektorismi = sqlite_datareader.GetString(1);

                            if (dsektorismi == ysektorismi && ysektorismi!=sektorismi)
                            {
                                tkontrol = 1;
                                break;
                            }
                            else tkontrol = 0;
                        }

                        if(tkontrol==0)
                        {
                            sqlite_conn.Close();

                            sqlite_conn.Open();

                            sqlite_cmd = sqlite_conn.CreateCommand();

                            sqlite_cmd.CommandText = "UPDATE sektor SET adi='" + ysektorismi + "' WHERE adi='" + sektorismi + "';";

                            sqlite_cmd.ExecuteNonQuery();

                            sqlite_conn.Close();

                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox2.Focus();
                        }
                        else
                        {

                            sqlite_conn.Close();

                            MessageBox.Show("Girilen yeni sektör ismi mevcuttur. Kontrol edin.", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox3.Text = "";
                            textBox3.Focus();
                        }




                        
                    }
                    else
                    {
                        sqlite_conn.Close();

                        MessageBox.Show("Girilen sektör ismi mevcut değildir. Kontrol edin.", "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        textBox2.Focus();

                    }
                }
                else
                {
                    MessageBox.Show("Sektör ismi girilmemiştir. Kontrol edin.","İşlem Hatası",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox2.Focus();

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox4.Text!="")
            {
                string sektorismi;
                int kontrol = 0,tkontrol = 0;
                sektorismi = textBox4.Text.ToUpper();

                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();


                sqlite_cmd.CommandText = "SELECT * FROM sektor";


                sqlite_datareader = sqlite_cmd.ExecuteReader();


                while (sqlite_datareader.Read())
                {
                    if (sektorismi == sqlite_datareader["adi"].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                    else kontrol = 0;
                }
                sqlite_conn.Close();

                if(kontrol==1)
                {
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();


                    sqlite_cmd.CommandText = "Select Firma_id From Firma_has_Sektor where Sektor_id=(SELECT id FROM sektor where adi='" + sektorismi + "')";


                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    while (sqlite_datareader.Read())
                    {
                        if(sqlite_datareader["Firma_id"]!=null)
                        {
                            tkontrol=1;
                            break;
                        }
                        else tkontrol=0;
                    }
                    if(tkontrol==0)
                    {
                        sqlite_conn.Close();


                        sqlite_conn.Open();

                        sqlite_cmd = sqlite_conn.CreateCommand();

                        sqlite_cmd.CommandText = "Delete From sektor where adi='" + sektorismi + "'";

                        sqlite_cmd.ExecuteNonQuery();

                        sqlite_conn.Close();

                        MessageBox.Show("Sektör başarılı bir şekilde silindi.","İşlem Tamam",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        textBox4.Text = "";
                        textBox4.Focus();

                    }
                    else
                    {
                        sqlite_conn.Close();
                        MessageBox.Show("Sektör kullanılmaktadır. Silinemez.","Erişim Engellendi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        textBox4.Text = "";
                        textBox4.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Girilen kayıt mevcut değildir. Kontrol edin.","Mevcut Olmayan Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox4.Text = "";
                    textBox4.Focus();
                }
            }
            else
            {
                MessageBox.Show("Boş kayıt. Kontrol edin.","Kayıt Hatası",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox4.Focus();
            }
        }
    }
}
