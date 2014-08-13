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
    public partial class guncelle : Form
    {
        public guncelle()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox7.SelectedItem != null)
            {
                string[] dizi = new string[listBox7.SelectedItems.Count];
                int i = 0, sayac;
                foreach (var obj in listBox7.SelectedItems)
                {
                    listBox8.Items.Add(obj.ToString());
                    dizi[i] = obj.ToString();
                    i++;
                }
                for (sayac = 0; sayac < i; sayac++)
                {
                    listBox7.Items.Remove(dizi[sayac]);

                }

            }
        }


        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        void enablefalse()
        {
            textBox6.Text = "";
            textBox6.Enabled = false;
            listBox7.Items.Clear();
            listBox7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            listBox8.Items.Clear();
            listBox8.Enabled = false;
            textBox4.Text = "";
            textBox4.Enabled = false;
            button7.Enabled = false;
            listBox1.Items.Clear();
            listBox1.Enabled = false;
            maskedTextBox1.Text = "";
            maskedTextBox1.Enabled = false;
            button1.Enabled = false;
            listBox2.Items.Clear();
            listBox2.Enabled = false;
            maskedTextBox2.Text = "";
            maskedTextBox2.Enabled = false;
            listBox3.Items.Clear();
            listBox3.Enabled = false;
            button3.Enabled = false;
            textBox2.Text = "";
            textBox2.Enabled = false;
            textBox5.Text = "";
            textBox5.Enabled = false;
            listBox5.Items.Clear();
            listBox5.Enabled = false;
            listBox6.Items.Clear();
            listBox6.Enabled = false;
            textBox3.Text = "";
            textBox3.Enabled = false;
            button4.Enabled = false;
            listBox4.Items.Clear();
            listBox4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button2.Enabled = false;
            button11.Enabled = false;
    
        }
        void enabletrue()
        {
            textBox6.Text = "";
            textBox6.Enabled = true;
            listBox7.Items.Clear();
            listBox7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            listBox8.Items.Clear();
            listBox8.Enabled = true;
            textBox4.Text = "";
            textBox4.Enabled = true;
            button7.Enabled = true;
            listBox1.Items.Clear();
            listBox1.Enabled = true;
            maskedTextBox1.Text = "";
            maskedTextBox1.Enabled = true;
            button1.Enabled = true;
            listBox2.Items.Clear();
            listBox2.Enabled = true;
            maskedTextBox2.Text = "";
            maskedTextBox2.Enabled = true;
            listBox3.Items.Clear();
            listBox3.Enabled = true;
            button3.Enabled = true;
            textBox2.Text = "";
            textBox2.Enabled = true;
            textBox5.Text = "";
            textBox5.Enabled = true;
            listBox5.Items.Clear();
            listBox5.Enabled = true;
            listBox6.Items.Clear();
            listBox6.Enabled = true;
            textBox3.Text = "";
            textBox3.Enabled = true;
            button4.Enabled = true;
            listBox4.Items.Clear();
            listBox4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button2.Enabled = true;
            button11.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                int kontrol = 0;
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
                    if (comboBox1.Text == sqlite_datareader["adi"].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                    else kontrol = 0;
                }
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
                

                if(kontrol==1)
                {
                    enabletrue();
                    button10.Enabled = false;
                    comboBox1.Enabled = false;

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



                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // But how do we read something out of our table ?
                    // First lets build a SQL-Query again:
                    sqlite_cmd.CommandText = "SELECT * FROM adres where Firma_id=(Select id From firma where adi='" + comboBox1.Text.ToString() + "')";

                    // Now the SQLiteCommand object can give us a DataReader-Object:
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    // The SQLiteDataReader allows us to run through the result lines:
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        listBox1.Items.Add(sqlite_datareader["adres"].ToString());
                    }
                    sqlite_conn.Close();



                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // But how do we read something out of our table ?
                    // First lets build a SQL-Query again:
                    sqlite_cmd.CommandText = "SELECT * FROM telefon where Firma_id=(Select id From firma where adi='" + comboBox1.Text.ToString() + "')";

                    // Now the SQLiteCommand object can give us a DataReader-Object:
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    // The SQLiteDataReader allows us to run through the result lines:
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        listBox2.Items.Add(sqlite_datareader["numara"].ToString());
                    }
                    sqlite_conn.Close();




                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // But how do we read something out of our table ?
                    // First lets build a SQL-Query again:
                    sqlite_cmd.CommandText = "SELECT * FROM faks where Firma_id=(Select id From firma where adi='" + comboBox1.Text.ToString() + "')";

                    // Now the SQLiteCommand object can give us a DataReader-Object:
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    // The SQLiteDataReader allows us to run through the result lines:
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        listBox3.Items.Add(sqlite_datareader["numara"].ToString());
                    }
                    sqlite_conn.Close();




                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // But how do we read something out of our table ?
                    // First lets build a SQL-Query again:
                    sqlite_cmd.CommandText = "SELECT * FROM web where Firma_id=(Select id From firma where adi='" + comboBox1.Text.ToString() + "')";

                    // Now the SQLiteCommand object can give us a DataReader-Object:
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    // The SQLiteDataReader allows us to run through the result lines:
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        listBox4.Items.Add(sqlite_datareader["webadresi"].ToString());
                    }
                    sqlite_conn.Close();



                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // But how do we read something out of our table ?
                    // First lets build a SQL-Query again:
                    sqlite_cmd.CommandText = "SELECT * FROM email where Firma_id=(Select id From firma where adi='" + comboBox1.Text.ToString() + "')";

                    // Now the SQLiteCommand object can give us a DataReader-Object:
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    // The SQLiteDataReader allows us to run through the result lines:
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        listBox5.Items.Add(sqlite_datareader["adresadi"].ToString());
                        listBox6.Items.Add(sqlite_datareader["aciklama"].ToString());
                    }
                    sqlite_conn.Close();




                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // But how do we read something out of our table ?
                    // First lets build a SQL-Query again:
                    sqlite_cmd.CommandText = "Select * From sektor Where id In(SELECT Sektor_id FROM Firma_has_Sektor where Firma_id=(Select id From firma where adi='" + comboBox1.Text.ToString() + "'))";

                    // Now the SQLiteCommand object can give us a DataReader-Object:
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    // The SQLiteDataReader allows us to run through the result lines:
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        listBox8.Items.Add(sqlite_datareader["adi"].ToString());
                    }
                    sqlite_conn.Close();

                    int i,j;
                    if(listBox8.Items.Count>0)
                    {
                        for (i = 0; i < listBox8.Items.Count;i++ )
                        {
                            for (j = 0; j < listBox7.Items.Count;j++ )
                            {
                                if(listBox8.Items[i].ToString()==listBox7.Items[j].ToString())
                                {
                                    listBox7.Items.Remove(listBox7.Items[j]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Girilen firma adi mevcut değildir. Kontrol edin.","Yanlış Veri Kaydı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    comboBox1.Text = null;
                    comboBox1.Focus();
                }
                
            }
            else
            {
                enablefalse();
                comboBox1.Focus();
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                int i, kontrol = 0;
                string adres;
                adres = textBox4.Text.ToString();
                for (i = 0; i < listBox1.Items.Count; i++)
                {
                    if (adres == listBox1.Items[i].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                }
                if (kontrol == 0)
                {
                    listBox1.Items.Add(adres);
                    textBox4.Text = "";
                    textBox4.Focus();

                }
                else
                {
                    MessageBox.Show("Eklemek istediğiniz kayıt daha önceden kaydedilmiştir.", "Tekrarlanan Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int i, kontrol = 0, sayac = 0;
                string telefon;
                telefon = maskedTextBox1.Text.ToString();
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
                    if (sayac == 10)
                    {

                        listBox2.Items.Add(telefon);
                        maskedTextBox1.Text = "";
                        maskedTextBox1.Focus();

                    }
                    else if (sayac > 0 && sayac < 10)
                    {
                        MessageBox.Show("Telefon numarası eksik girildi.", "Kontrol edin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maskedTextBox1.Focus();
                    }
                    else if (sayac == 0)
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
                    else if (sayac < 10 && sayac > 0)
                    {
                        MessageBox.Show("Faks numarası eksik girildi.", "Kontrol edin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maskedTextBox2.Focus();
                    }
                    else if (sayac == 0)
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox5.Text != "")
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
                if (textBox5.Text == "" && textBox2.Text != "")
                {
                    MessageBox.Show("Açıklama boş bırakılamaz.", "Eksik Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox5.Focus();
                }
                else if (textBox5.Text == "" && textBox2.Text != "")
                {
                    MessageBox.Show("E-Mail adresi boş bırakılamaz.", "Eksik Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                }
                else textBox2.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int i, kontrol = 0;
                for (i = 0; i < listBox4.Items.Count; i++)
                {
                    if (textBox3.Text == listBox4.Items[i].ToString())
                    {
                        kontrol = 1;
                        break;
                    }
                    else kontrol = 0;

                }
                if (kontrol == 0)
                {
                    listBox4.Items.Add(textBox3.Text.ToString());
                    textBox3.Text = "";
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("Girilen web adresi mevcuttur. Kontrol edin.", "Tekrarlanan Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Text = "";
                    textBox3.Focus();
                }
            }
            else
            {
                textBox3.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            textBox4.Text = "";
            listBox1.Items.Clear();
            maskedTextBox1.Text = "";
            listBox2.Items.Clear();
            maskedTextBox2.Text = "";
            listBox3.Items.Clear();
            textBox2.Text = "";
            textBox5.Text = "";
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            textBox3.Text = "";
            listBox4.Items.Clear();

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

            textBox6.Focus();

          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && listBox8.Items.Count > 0)
            {
                int kontrol=0;
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
                    if (sqlite_datareader["adi"].ToString() == textBox6.Text && textBox6.Text != comboBox1.Text)
                    {
                        kontrol=1;
                        break;
                    }
                    else kontrol=0;
                }
                sqlite_conn.Close();

                if(kontrol==0)
                {
                    int i;

                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Update firma Set adi='" + textBox6.Text.ToString() + "' Where adi='" + comboBox1.Text.ToString() + "'";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From adres WHERE Firma_id=(Select id From firma where adi='" + textBox6.Text.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From telefon where Firma_id=(Select id From firma where adi='" + textBox6.Text.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From faks where Firma_id=(Select id From firma where adi='" + textBox6.Text.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From email where Firma_id=(Select id From firma where adi='" + textBox6.Text.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From web where Firma_id=(Select id From firma where adi='" + textBox6.Text.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From Firma_has_Sektor where Firma_id=(Select id From firma where adi='" + textBox6.Text.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // We are ready, now lets cleanup and close our connection:
                    sqlite_conn.Close();



                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();


                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    if (listBox1.Items.Count > 0)
                    {
                   
                        for (i = 0; i < listBox1.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO adres (id, adres, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM adres), '" + listBox1.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox6.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }

                   
                    }

                    if (listBox2.Items.Count > 0)
                    {
                   
                        for (i = 0; i < listBox2.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO telefon (id, numara, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM telefon), '" + listBox2.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox6.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }
                    }

                    if (listBox3.Items.Count > 0)
                    {
                    
                        for (i = 0; i < listBox3.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO faks (id, numara, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM faks), '" + listBox3.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox6.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }

                    }

                    if (listBox5.Items.Count > 0)
                    {
                        for (i = 0; i < listBox5.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO email (id, adresadi, aciklama, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM email), '" + listBox5.Items[i].ToString() + "', '" + listBox6.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox6.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }
                    }

                    if (listBox4.Items.Count > 0)
                    {
                        for (i = 0; i < listBox4.Items.Count; i++)
                        {
                            // Lets insert something into our new table:
                            sqlite_cmd.CommandText = "INSERT INTO web (id, webadresi, Firma_id) VALUES ((SELECT COALESCE(MAX(id)+1, 1) FROM web), '" + listBox4.Items[i].ToString() + "', (SELECT id From firma Where adi='" + textBox6.Text.ToString() + "'))";

                            // And execute this again ;D
                            sqlite_cmd.ExecuteNonQuery();
                        }
                    }


                    // We are ready, now lets cleanup and close our connection:
                    sqlite_conn.Close();





                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();


                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    for (i = 0; i < listBox8.Items.Count; i++)
                    {
                        // Lets insert something into our new table:
                        sqlite_cmd.CommandText = "INSERT INTO Firma_has_Sektor (Firma_id, Sektor_id) VALUES ((SELECT id From firma Where adi='" + textBox6.Text.ToString() + "'), (SELECT id From sektor Where adi='" + listBox8.Items[i].ToString() + "'))";

                        // And execute this again ;D
                        sqlite_cmd.ExecuteNonQuery();
                    }

                    // We are ready, now lets cleanup and close our connection:
                    sqlite_conn.Close();

                    enablefalse();
                    comboBox1.Text = null;
                    comboBox1.Enabled = true;
                    button10.Enabled = true;
                    comboBox1.Focus();
                    goster();

                }
                else
                {
                    MessageBox.Show("Girilen firma adi mevcuttur. Kontrol edin.","Mevcut Bilgi Girişi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox6.Text = "";
                    textBox6.Focus();
                }
            }
            else
            {
                MessageBox.Show("Firma adi ya da sektor boş girilemez. Kontrol Edin.", "Eksik Bilgi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
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

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void tümünüSilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void silToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void tümünüSilToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void silToolStripMenuItem3_Click(object sender, EventArgs e)
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

        private void silToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            listBox4.Items.Remove(listBox4.SelectedItem);
        }

        private void tümünüSilToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            enablefalse();
            comboBox1.Text = null;
            comboBox1.Enabled = true;
            button10.Enabled = true;
            comboBox1.Focus();
        }

        private void guncelle_Load(object sender, EventArgs e)
        {
            goster();
        }

        void goster()
        {
            comboBox1.Items.Clear();
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
                comboBox1.Items.Add(sqlite_datareader["adi"].ToString());
            }
            sqlite_conn.Close();
        }
    }
}
