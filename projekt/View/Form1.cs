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
using System.Runtime.InteropServices; //aby przesuwac kursorem okno bez obramowki

namespace projekt
{
    public partial class Form1 : Form
    {
        public Form1() //szyfrowanie hasla przy logowaniu
        {
            InitializeComponent();
            password_txt.PasswordChar = '●';
        }

        public void button1_Click(object sender, EventArgs e) //przycisk polaczenia z baza danych
        {
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=lksada31";
                MySqlConnection myConn = new MySqlConnection(myConnection); //pozwala na nawiązanie połączenia z BD
                MySqlCommand SelectCommand = new MySqlCommand(" select * from database.edata where username='" + this.username_txt.Text + "'and password = '" + this.password_txt.Text + "' ;", myConn);
                //pobiera i porownuje dane z kolumn BD username i password
                MySqlDataReader myReader;

                if (username_txt.Text == "" || password_txt.Text == "")
                {
                    MessageBox.Show("One of your fields is empty. Fill it and try again!");
                    //zabezpieczenie na wypadek zostawienia pustego pola
                } 
                else
                {
                    myConn.Open();
                    myReader = SelectCommand.ExecuteReader();
                    int count = 0;
                    while (myReader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Username and password is correct.");
                        //jesli poprawnie wpiszemy login i haslo pojawi sie komunikat o poprawnym zalogowaniu
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.ShowDialog();
                        this.Close();
                        //otworzy sie nam okno Form2, a poprzednie zostanie zamkniete
                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("Duplicate username and password. Try again.");
                        // jesli gdzies w bazie danych zostanie wpisany identyczny login i haslo to zablokuje mozliwosc logowania
                    }
                    else
                    {
                        MessageBox.Show("Username and password is not correct. Try again.");
                        //zablokuje mozliwosc logowania jesli nie znajdzie w bazie danych takiego loginu i hasla
                    }
                    myConn.Close(); //zamkniecie polaczenia
                }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //kod ponizej umozliwia przesuwanie kursorem formy bez obramowki
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
