using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //przycisk polaczenia z baza danych
        {
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
                MySqlConnection myConn = new MySqlConnection(myConnection); //pozwala na nawiązanie połączenia z BD
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(); //reprezentuje zestaw komend i połączenia z BD
                myDataAdapter.SelectCommand = new MySqlCommand(" select * database.edata ;", myConn); //zaznaczamy wszystkie rekordy z tabeli edata pracownikow
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter); //automatycznie generuje polecenia tabeli używane do uzgadniania zmian wprowadzonych z powiązaną BD
                myConn.Open();
                MessageBox.Show("Connected");
                myConn.Close(); //po prawidlowym polaczeniu sie wyskoczy informacja 'connected'
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
