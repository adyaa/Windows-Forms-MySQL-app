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
            Fillcombo1();
            Fillcombo2();
            Fillcombo3();
            load_table();
            timer1.Start();
        }

        void Fillcombo1()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "select * from database.edata;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sEid = myReader.GetString("Eid");
                    comboBox2.Items.Add(sEid);
                }
                //funkcja ta pobiera z kolumny "Eid" jej wartosci, zapisuje pod postacia sEid, a nastepnie wyswietla w comboBoxie jako opcje do wyboru
                conDataBase.Close();
            }
       
            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Fillcombo2()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "select * from database.edata;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("name");
                    comboBox1.Items.Add(sName);
                }
                conDataBase.Close();
                //funkcja ta pobiera z kolumny "name" jej wartosci, zapisuje pod postacia sName, a nastepnie wyswietla w comboBoxie jako opcje do wyboru
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Fillcombo3()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "select * from database.edata;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sSurname = myReader.GetString("surname");
                    comboBox3.Items.Add(sSurname);
                }
                conDataBase.Close();
                //funkcja ta pobiera z kolumny name jej wartosci, zapisuje pod postacia sName, a nastepnie wyswietla w comboBoxie jako opcje do wyboru
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
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
                MessageBox.Show("Saved"); //po prawidlowym dodaniu rekordu wyskoczy okno z napisem Saved
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "delete from database.edata  where Eid = '" + this.Eid_txt.Text + "' ;";
            //usunie nam z tabeli rekord o danym nr ID pracownika
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Deleted"); //po prawidlowym usunieciu wyskoczy okno z napisem Deleted
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "update database.edata set Eid = '" + this.Eid_txt.Text + "', name = '" + this.Name_txt.Text + "', surname = '" + this.Surname_txt.Text + "', age = '" + this.Age_txt.Text + "' where Eid = '" + this.Eid_txt.Text + "' ;";
            //dodajemy na koncu where, poniewaz Eid jest kluczem unikalnym i program musi wiedziec do ktorego pracownika odnosi sie zmiana
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Updated"); //po prawidlowym zedytowaniu rekordu wyskoczy okno z napisem Updated
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "select * from database.edata where name = '" + comboBox1.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("name");
                    Name_txt.Text = sName;
                }
                conDataBase.Close();
               
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "select * from database.edata where Eid = '" + comboBox2.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sEid = myReader.GetInt32("Eid").ToString(); //nalezy przekonwertowac int na string aby wyswietlil sie w textboxie
                    string sName = myReader.GetString("name");
                    string sSurname = myReader.GetString("surname");
                    string sAge = myReader.GetInt32("age").ToString(); //nalezy przekonwertowac int na string aby wyswietlil sie w textboxie
                    Eid_txt.Text = sEid;
                    Name_txt.Text = sName;
                    Surname_txt.Text = sSurname;
                    Age_txt.Text = sAge;

                }
                //funkcja ta pobiera z kolumny "Eid" jej wartosci, zapisuje pod postacia sEid, a nastepnie wyswietla w comboBoxie jako opcje do wyboru ktorymi mozemy uzupelnic textboxy jednym kliknieciem
                conDataBase.Close();
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            string Query = "select * from database.edata where surname = '" + comboBox3.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sSurname = myReader.GetString("surname");
                    Surname_txt.Text = sSurname;
                }
                conDataBase.Close(); 
            }

            catch (Exception ex) //reprezentuje bledy wystepujace podczas nieprawidlowego polaczenia z BD
            {
                MessageBox.Show(ex.Message);
            }
        }

        void load_table() //funkcja pobierajaca nam tabele z bazy danych i wyswietlajaca ja w aplikacji
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select * from database.edata;", conDataBase); //polaczenie z baza danych


            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(); 
                sda.SelectCommand = cmdDataBase; //reprezentuje jedna tabele danych w pamieci
                DataTable dbdataset = new DataTable();  //tworzy tabele
                sda.Fill(dbdataset); //dodaje lub odswieza wiersze w tabeli
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset; 
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset); //pobiera lub ustawia zrodlo danych, ktore w DataGridView sa wyswietlane dane
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now; //ustawianie daty na obecna
            this.time_lbl.Text = dateTime.ToString(); //wyswietlanie daty w polu tekstowym, konwersja na string
        }
    }
}
