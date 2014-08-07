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
    public partial class kaydet : Form
    {
        public kaydet()
        {
            InitializeComponent();
        }
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        private void kaydet_Load(object sender, EventArgs e)
        {
           // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM sektor order by adi asc";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                listBox7.Items.Add(sqlite_datareader["adi"].ToString());
            }
            sqlite_conn.Close();

         
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(textBox4.Text!="")
            {
                int i,kontrol=0;
                string adres;
                adres=textBox4.Text.ToString();
                for(i=0;i<listBox1.Items.Count;i++)
                {
                    if(adres==listBox1.Items[i].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                }
                if(kontrol==0)
                {
                    listBox1.Items.Add(adres);
                    textBox4.Text = "";
                    textBox4.Focus();

                }
                else
                {
                    MessageBox.Show("Eklemek istediğiniz kayıt daha önceden kaydedilmiştir.","Tekrarlanan Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox4.Text = "";
                    textBox4.Focus();

                }
            }
            else
            {
                textBox4.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                int i, kontrol = 0,sayac=0;
                string telefon;
                telefon = maskedTextBox1 .Text.ToString();
                for (i = 0; i < listBox2.Items.Count; i++)
                {
                    if (telefon == listBox2.Items[i].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                }
                if (kontrol == 0)
                {
                    for (i = 0; i < maskedTextBox1.TextLength; i++)
                    {
                        try
                        {
                            if (maskedTextBox1.Text[i] == '0' || maskedTextBox1.Text[i] == '1' || maskedTextBox1.Text[i] == '2' || maskedTextBox1.Text[i] == '3' || maskedTextBox1.Text[i] == '4' || maskedTextBox1.Text[i] == '5' || maskedTextBox1.Text[i] == '6' || maskedTextBox1.Text[i] == '7' || maskedTextBox1.Text[i] == '8' || maskedTextBox1.Text[i] == '9')
                            {
                                sayac++;
                            }
                        }
                        catch { }
                    }
                    if(sayac==10)
                    {

                        listBox2.Items.Add(telefon);
                        maskedTextBox1.Text = "";
                        maskedTextBox1.Focus();

                    }
                    else if(sayac>0 && sayac<10)
                    {
                        MessageBox.Show("Telefon numarası eksik girildi.","Kontrol edin",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        maskedTextBox1.Focus();
                    }
                    else if(sayac==0)
                    {
                        maskedTextBox1.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Eklemek istediğiniz kayıt daha önceden kaydedilmiştir.", "Tekrarlanan Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maskedTextBox1.Text = "";
                    maskedTextBox1.Focus();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "")
            {
                int i, kontrol = 0, sayac = 0;
                string faks;
                faks = maskedTextBox2.Text.ToString();
                for (i = 0; i < listBox3.Items.Count; i++)
                {
                    if (faks == listBox3.Items[i].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                }
                if (kontrol == 0)
                {
                    for (i = 0; i < maskedTextBox2.TextLength; i++)
                    {
                        try
                        {
                            if (maskedTextBox2.Text[i] == '0' || maskedTextBox2.Text[i] == '1' || maskedTextBox2.Text[i] == '2' || maskedTextBox2.Text[i] == '3' || maskedTextBox2.Text[i] == '4' || maskedTextBox2.Text[i] == '5' || maskedTextBox2.Text[i] == '6' || maskedTextBox2.Text[i] == '7' || maskedTextBox2.Text[i] == '8' || maskedTextBox2.Text[i] == '9')
                            {
                                sayac++;
                            }
                        }
                        catch { }
                    }
                    if (sayac == 10)
                    {

                        listBox3.Items.Add(faks);
                        maskedTextBox2.Text = "";
                        maskedTextBox2.Focus();

                    }
                    else if(sayac<10 && sayac>0)
                    {
                        MessageBox.Show("Faks numarası eksik girildi.", "Kontrol edin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maskedTextBox2.Focus();
                    }
                    else if(sayac==0)
                    {
                        maskedTextBox2.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Eklemek istediğiniz kayıt daha önceden kaydedilmiştir.", "Tekrarlanan Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maskedTextBox2.Text = "";
                    maskedTextBox2.Focus();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox3.Text!="")
            {
                int i,kontrol=0;
                for (i = 0; i < listBox4.Items.Count;i++ )
                {
                    if (textBox3.Text == listBox4.Items[i].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                    else kontrol = 0;

                }
                if(kontrol==0)
                {
                    listBox4.Items.Add(textBox3.Text.ToString());
                    textBox3.Text = "";
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("Girilen web adresi mevcuttur. Kontrol edin.","Tekrarlanan Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox3.Text = "";
                    textBox3.Focus();
                }
            }
            else
            {
                textBox3.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!="" && textBox5.Text!="")
            {
                int i, kontrol = 0;
                for (i = 0; i < listBox5.Items.Count; i++)
                {
                    if (textBox2.Text == listBox5.Items[i].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                    else kontrol = 0;

                }
                if (kontrol == 0)
                {
                    listBox5.Items.Add(textBox2.Text.ToString());
                    listBox6.Items.Add(textBox5.Text.ToString());
                    textBox2.Text = "";
                    textBox2.Focus();
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Girilen e-mail adresi mevcuttur. Kontrol edin.", "Tekrarlanan Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            else
            {
                if(textBox5.Text=="" && textBox2.Text!="")
                {
                    MessageBox.Show("Açıklama boş bırakılamaz.", "Eksik Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox5.Focus();
                }
                else if(textBox5.Text=="" && textBox2.Text!="")
                {
                    MessageBox.Show("E-Mail adresi boş bırakılamaz.", "Eksik Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(listBox7.SelectedItem!=null)
            {
                string[] dizi = new string[listBox7.SelectedItems.Count];
                int i = 0,sayac;
                foreach (var obj in listBox7.SelectedItems )
                {
                   listBox8.Items.Add(obj.ToString());
                   dizi[i] = obj.ToString();
                   i++;
                }
                for (sayac = 0; sayac < i;sayac++ )
                {
                    listBox7.Items.Remove(dizi[sayac]);

                }

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox8.SelectedItem != null)
            {
                string[] dizi = new string[listBox8.SelectedItems.Count];
                int i = 0, sayac;
                foreach (var obj in listBox8.SelectedItems)
                {
                    listBox7.Items.Add(obj.ToString());
                    dizi[i] = obj.ToString();
                    i++;
                }
                for (sayac = 0; sayac < i; sayac++)
                {
                    listBox8.Items.Remove(dizi[sayac]);

                }
                
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            temizle();
        }

        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox8.Items.Clear();
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            listBox7.Items.Clear();
            textBox1.Focus();

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM sektor order by adi asc";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                listBox7.Items.Add(sqlite_datareader["adi"].ToString());
            }
            sqlite_conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && listBox8.Items.Count>0)
            {
                int kontrol = 0,i;
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // But how do we read something out of our table ?
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT * FROM firma";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    if (textBox1.Text == sqlite_datareader["adi"].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                    else kontrol = 0;
                }
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();

                if(kontrol==0)
                {

                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "INSERT INTO firma (id, adi) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM firma), '" + textBox1.Text.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();

                    // We are ready, now lets cleanup and close our connection:
                    sqlite_conn.Close();


                    if (listBox1.Items.Count > 0)
                    {
                        sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                        // open the connection:
                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        for (i = 0; i < listBox1.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO adres (id, adres, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM adres), '" + listBox1.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox1.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }

                        // We are ready, now lets cleanup and close our connection:
                        sqlite_conn.Close();
                    }

                    if (listBox2.Items.Count > 0)
                    {
                        sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                        // open the connection:
                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        for (i = 0; i < listBox2.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO telefon (id, numara, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM telefon), '" + listBox2.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox1.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }

                        // We are ready, now lets cleanup and close our connection:
                        sqlite_conn.Close();
                    }

                    if (listBox3.Items.Count > 0)
                    {
                        sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                        // open the connection:
                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        for (i = 0; i < listBox3.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO faks (id, numara, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM faks), '" + listBox3.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox1.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }

                        // We are ready, now lets cleanup and close our connection:
                        sqlite_conn.Close();
                    }

                    if (listBox5.Items.Count > 0)
                    {
                        sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                        // open the connection:
                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        for (i = 0; i < listBox5.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO email (id, adresadi, aciklama, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM email), '" + listBox5.Items[i].ToString() + "', '" + listBox6.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox1.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }

                        // We are ready, now lets cleanup and close our connection:
                        sqlite_conn.Close();
                    }

                    if (listBox4.Items.Count > 0)
                    {
                        sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                        // open the connection:
                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        for (i = 0; i < listBox4.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO web (id, webadresi, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM web), '" + listBox4.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox1.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }

                        // We are ready, now lets cleanup and close our connection:
                        sqlite_conn.Close();
                    }


                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    for (i = 0; i < listBox8.Items.Count; i++)
                    {
                        // Lets insert something into our new table:
                        sqlite_cmd.CommandText = "INSERT INTO Firma_has_Sektor (Firma_id, Sektor_id) VALUES ((SELECT id From firma Where adi='" + textBox1.Text.ToString() + "'), (SELECT id From sektor Where adi='" + listBox8.Items[i].ToString() + "'))";

                        // And execute this again ;D
                        sqlite_cmd.ExecuteNonQuery();
                    }

                    // We are ready, now lets cleanup and close our connection:
                    sqlite_conn.Close();

                    temizle();
                    MessageBox.Show("İşlem başarı ile tamamlandı.", "Tamamlanan İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Girilen firma adı mevcuttur. Kontrol edin.","Mevcut Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox1.Focus();
                }
               
            }
            else
            {
                MessageBox.Show("Firma adi ya da sektor boş girilemez. Kontrol Edin.","Eksik Bilgi Hatası",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox1.Focus();
            }

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void tümünüSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void sİlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void tümünüSilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void tümünüSilToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void silToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox6.Items.Remove(listBox6.Items[listBox5.SelectedIndex]);
                listBox5.Items.Remove(listBox5.SelectedItem);
            }
            catch
            {

            }
        }

        private void tümünüSilToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            listBox6.Items.Clear();
        }

        private void silToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listBox4.Items.Remove(listBox4.SelectedItem);
        }

        private void tümünüSilToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
        }

 
    }
}
