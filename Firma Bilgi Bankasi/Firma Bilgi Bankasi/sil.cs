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
    public partial class sil : Form
    {
        public sil()
        {
            InitializeComponent();
        }

        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem!=null)
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
                sqlite_cmd.CommandText = "SELECT * FROM firma";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    if (sqlite_datareader["adi"].ToString() == listBox1.SelectedItem.ToString())
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

                    // open the connection:
                    sqlite_conn.Open();

                    // create a new SQL command:
                    sqlite_cmd = sqlite_conn.CreateCommand();

                 
                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From adres WHERE Firma_id=(Select id From firma where adi='" + listBox1.SelectedItem.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From telefon where Firma_id=(Select id From firma where adi='" + listBox1.SelectedItem.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From faks where Firma_id=(Select id From firma where adi='" + listBox1.SelectedItem.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From email where Firma_id=(Select id From firma where adi='" + listBox1.SelectedItem.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From web where Firma_id=(Select id From firma where adi='" + listBox1.SelectedItem.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();


                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From Firma_has_Sektor where Firma_id=(Select id From firma where adi='" + listBox1.SelectedItem.ToString() + "')";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();

                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "Delete From firma where adi='" + listBox1.SelectedItem.ToString() + "'";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();

                    // We are ready, now lets cleanup and close our connection:
                    sqlite_conn.Close();

                    goster();

                    MessageBox.Show("İşlem başarı ile tamamlandı.","Tamamlanan İşlem",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    listBox1.SelectedItem = null;
                    listBox1.Focus();

                    
                }
            }
            else
            {
                MessageBox.Show("Firma adı seçilmemiştir. Kontrol edin.","Boş Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);
                listBox1.Focus();
            }
        }
        void goster()
        {
            listBox1.Items.Clear();
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
                listBox1.Items.Add(sqlite_datareader["adi"].ToString());
            }
            sqlite_conn.Close();
        }
        private void sil_Load(object sender, EventArgs e)
        {
           
            goster();
        }
    }
}
