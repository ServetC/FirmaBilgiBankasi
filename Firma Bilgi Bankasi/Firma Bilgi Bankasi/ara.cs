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
    public partial class ara : Form
    {
        public ara()
        {
            InitializeComponent();
        }

        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Adres")
            {
                label2.Text = "Adres";
                label2.Visible = true;
                textBox1.Text = "";
                maskedTextBox1.Text = "";
                listBox2.Items.Clear();
                textBox1.Visible = true;
                maskedTextBox1.Visible = false;
                listBox2.Visible = false;
                listBox1.Items.Clear();
                textBox1.Focus();
            }
            else if (comboBox1.Text == "E-Mail")
            {
                label2.Text = "E-Mail";
                textBox1.Text = "";
                label2.Visible = true;
                maskedTextBox1.Text = "";
                listBox2.Items.Clear();
                textBox1.Visible = true;
                maskedTextBox1.Visible = false;
                listBox2.Visible = false;
                listBox1.Items.Clear();
                textBox1.Focus();
            }
            else if (comboBox1.Text == "Faks")
            {
                label2.Text = "Faks";
                textBox1.Text = "";
                label2.Visible = true;
                maskedTextBox1.Text = "";
                listBox2.Items.Clear();
                textBox1.Visible = false;
                maskedTextBox1.Visible = true;
                listBox2.Visible = false;
                listBox1.Items.Clear();
                maskedTextBox1.Focus();
            }
            else if (comboBox1.Text == "Firma Adı")
            {
                label2.Text = "Firma Adı";
                textBox1.Text = "";
                label2.Visible = true;
                maskedTextBox1.Text = "";
                listBox2.Items.Clear();
                textBox1.Visible = true;
                maskedTextBox1.Visible = false;
                listBox2.Visible = false;
                listBox1.Items.Clear();
                textBox1.Focus();
            }
            else if (comboBox1.Text == "Telefon")
            {
                label2.Text = "Telefon";
                textBox1.Text = "";
                label2.Visible = true;
                maskedTextBox1.Text = "";
                listBox2.Items.Clear();
                textBox1.Visible = false;
                maskedTextBox1.Visible = true;
                listBox2.Visible = false;
                listBox1.Items.Clear();
                maskedTextBox1.Focus();
            }
            else if (comboBox1.Text == "Web Adresi")
            {
                label2.Text = "Web Adresi";
                textBox1.Text = "";
                label2.Visible = true;
                maskedTextBox1.Text = "";
                listBox2.Items.Clear();
                textBox1.Visible = true;
                maskedTextBox1.Visible = false;
                listBox2.Visible = false;
                listBox1.Items.Clear();
                textBox1.Focus();
            }
            else if (comboBox1.Text == "Sektör")
            {
                label2.Text = "Sektör";
                textBox1.Text = "";
                label2.Visible = true;
                maskedTextBox1.Text = "";
                listBox2.Items.Clear();
                textBox1.Visible = false;
                maskedTextBox1.Visible = false;
                listBox2.Visible = true;
                listBox1.Items.Clear();
                listBox2.Focus();

                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                sqlite_cmd.CommandText = "Select * From sektor order by adi asc";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    listBox2.Items.Add(sqlite_datareader["adi"].ToString());
                }
                sqlite_conn.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.Text == "Adres")
            {

                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

               // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                sqlite_cmd.CommandText = "Select firma.adi, adres.adres From firma, adres where firma.id=adres.Firma_id and adres.adres IN(Select adres From adres where adres like '%" + textBox1.Text.ToString() + "%')";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    listBox1.Items.Add(sqlite_datareader["firma.adi"].ToString() + "       -      " + sqlite_datareader["adres.adres"].ToString());
                }
                sqlite_conn.Close();

            }
            else if (comboBox1.Text == "E-Mail")
            {
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                sqlite_cmd.CommandText = "Select firma.adi, email.adresadi From firma, email where firma.id=email.Firma_id and email.adresadi IN(Select adresadi From email where adresadi like '%" + textBox1.Text.ToString() + "%')";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    listBox1.Items.Add(sqlite_datareader["firma.adi"].ToString() + "       -      " + sqlite_datareader["email.adresadi"].ToString());
                }
                sqlite_conn.Close();


            }
            else if (comboBox1.Text == "Faks")
            {
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                sqlite_cmd.CommandText = "Select firma.adi, faks.numara From firma, faks where firma.id=faks.Firma_id and faks.numara IN(Select numara From faks where numara like '%" + maskedTextBox1.Text.ToString() + "%')";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    listBox1.Items.Add(sqlite_datareader["firma.adi"].ToString() + "       -      " + sqlite_datareader["faks.numara"].ToString());
                }
                sqlite_conn.Close();

            }
            else if (comboBox1.Text == "Firma Adı")
            {
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                sqlite_cmd.CommandText = "Select * From firma where adi like'%" + textBox1.Text.ToString() + "%'";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    listBox1.Items.Add(sqlite_datareader["adi"].ToString());
                }
                sqlite_conn.Close();
            }
            else if (comboBox1.Text == "Telefon")
            {
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                sqlite_cmd.CommandText = "Select firma.adi, telefon.numara From firma, telefon where firma.id=telefon.Firma_id and telefon.numara IN(Select numara From telefon where numara like '%" + maskedTextBox1.Text.ToString() + "%')";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    listBox1.Items.Add(sqlite_datareader["firma.adi"].ToString() + "       -      " + sqlite_datareader["telefon.numara"].ToString());
                }
                sqlite_conn.Close();
            }
            else if (comboBox1.Text == "Web Adresi")
            {
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                sqlite_cmd.CommandText = "Select firma.adi, web.webadresi From firma, web where firma.id=web.Firma_id and web.webadresi IN(Select webadresi From web where webadresi like '%" + textBox1.Text.ToString() + "%')";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    listBox1.Items.Add(sqlite_datareader["firma.adi"].ToString() + "       -      " + sqlite_datareader["web.webadresi"].ToString());
                }
                sqlite_conn.Close();

            }
            else if (comboBox1.Text == "Sektör")
            {
                if (listBox2.SelectedItem != null)
                {

                    listBox1.Items.Clear();

                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "Delete From sektorbul";

                    sqlite_cmd.ExecuteNonQuery();


                    foreach (var obj in listBox2.SelectedItems)
                    {
                        sqlite_cmd.CommandText = "Insert Into sektorbul (adi) Values('" + obj.ToString() + "')";

                        sqlite_cmd.ExecuteNonQuery();
                     
                    }

                    sqlite_conn.Close();



                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    // -- sqlite_cmd.CommandText = "Select * From firma f Join adres e On f.id=e.Firma_id where f.id IN(Select Firma_id From adres Where adres like '%" + textBox1.Text.ToString() + "%')";

                    sqlite_cmd.CommandText = "Select * From firma Where id In(Select Firma_id From Firma_has_Sektor Where Sektor_id In(Select id From sektor WHERE adi In(Select adi From sektorbul)))";
                
                    // Now the SQLiteCommand object can give us a DataReader-Object:
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    // The SQLiteDataReader allows us to run through the result lines:
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        listBox1.Items.Add(sqlite_datareader["adi"].ToString());
                    }
                    sqlite_conn.Close();

                    listBox2.SelectedItem = null;
                }

            }
        }
    }
}
