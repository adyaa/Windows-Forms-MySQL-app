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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "insert into database.edata (Eid,name,surname,age) values ('" + this.Eid_txt.Text + "','" + this.Name_txt.Text + "','" + this.Surname_txt.Text + "','" + this.Age_txt.Text + "') ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
