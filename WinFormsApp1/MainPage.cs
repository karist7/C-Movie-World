using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;

using System.Data.SQLite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace WinFormsApp1
{
    public partial class MainPage : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        DataTable dataTable;
        Label[] names = new Label[6];
        Label[] rates = new Label[6];
        Label[] dates = new Label[6];
        List<Button> infbtn = new List<Button>();
        List<Button> resbtn = new List<Button>();
        PictureBox[] pictureBox = new PictureBox[6];
        public static string title = "";
        public static string rate = "";
        public static string date = "";
        public static string number = "";

        int i;
        public static byte[] infImg;
        public MainPage()
        {
            InitializeComponent();
            create();

            try
            {
                connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/movie.db");
                connection.Open();
                String sql = "select * from movie ORDER BY reservationRate DESC";
                command = new SQLiteCommand(sql, connection);
                SQLiteDataReader rdr = command.ExecuteReader();
                i = 0;
                while (rdr.Read())
                {
                    names[i].Text = rdr["Title"].ToString();
                    rates[i].Text = rdr["reservationRate"].ToString() + "%";
                    dates[i].Text = rdr["releaseDate"].ToString();

                    byte[] img = (byte[])(rdr["image"]);
                    MemoryStream mstream = new MemoryStream(img);
                    Image image = Image.FromStream(mstream);


                    pictureBox[i].Image = image;

                    i++;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginForm = new LoginPage(this);
            loginForm.ShowDialog();

            

        }
        public void UpdateInformation()
        {
            button1.Visible = false;
            button2.Visible = false;

            info.Visible = true;
            info.Text = LoginPage.user + "님";
            button9.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterPage w = new RegisterPage();
            w.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void create()
        {
            names[0] = title1;
            names[1] = title2;
            names[2] = title3;
            names[3] = title4;
            names[4] = title5;
            names[5] = title6;
            rates[0] = rate1;
            rates[1] = rate2;
            rates[2] = rate3;
            rates[3] = rate4;
            rates[4] = rate5;
            rates[5] = rate6;
            dates[0] = date1;
            dates[1] = date2;
            dates[2] = date3;
            dates[3] = date4;
            dates[4] = date5;
            dates[5] = date6;
            pictureBox[0] = pictureBox1;
            pictureBox[1] = pictureBox2;
            pictureBox[2] = pictureBox3;
            pictureBox[3] = pictureBox4;
            pictureBox[4] = pictureBox5;
            pictureBox[5] = pictureBox6;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 로그아웃 시 초기화
                button1.Visible = true;
                button2.Visible = true;

                info.Visible = false;
                button9.Visible = false;
                LoginPage.success = false;
                LoginPage.user = null;
                LoginPage.number = null;
            }
        }

        private void 예약확인_Click(object sender, EventArgs e)
        {
            if (LoginPage.number == null)
            {
                checkResv res = new checkResv();
                res.ShowDialog();
            }
            else
            {
                result r = new result();
                r.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void inf1_Click(object sender, EventArgs e)
        {
            title = names[0].Text;
            rate = rates[0].Text;
            date = dates[0].Text;

            MoreInformation m = new MoreInformation();
            m.ShowDialog();

        }

        private void inf2_Click(object sender, EventArgs e)
        {
            title = names[1].Text;
            rate = rates[1].Text;
            date = dates[1].Text;

            MoreInformation m = new MoreInformation();
            m.ShowDialog();
        }

        private void inf3_Click(object sender, EventArgs e)
        {
            title = names[2].Text;
            rate = rates[2].Text;
            date = dates[2].Text;

            MoreInformation m = new MoreInformation();
            m.ShowDialog();
        }

        private void inf4_Click(object sender, EventArgs e)
        {
            title = names[3].Text;
            rate = rates[3].Text;
            date = dates[3].Text;

            MoreInformation m = new MoreInformation();
            m.ShowDialog();
        }

        private void inf5_Click(object sender, EventArgs e)
        {
            title = names[4].Text;
            rate = rates[4].Text;
            date = dates[4].Text;

            MoreInformation m = new MoreInformation();
            m.ShowDialog();
        }

        private void inf6_Click(object sender, EventArgs e)
        {
            title = names[5].Text;
            rate = rates[5].Text;
            date = dates[5].Text;

            MoreInformation m = new MoreInformation();
            m.ShowDialog();
        }

        private void res1_Click(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {
                title = names[0].Text;
                reservation resv = new reservation();
                resv.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
                button1_Click(sender, e);
                
                if (LoginPage.success == true)
                {
                    title = names[0].Text;
                    reservation resv = new reservation();
                    resv.ShowDialog();
                }
            }

        }

        private void res2_Click(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {
                
                title = names[1].Text;
                reservation resv = new reservation();
                resv.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
                button1_Click(sender, e);
                
                if (LoginPage.success == true)
                {
                    title = names[1].Text;
                    reservation resv = new reservation();
                    resv.ShowDialog();
                }
            }
            
        }

        private void res3_Click(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {
                title = names[2].Text;
                reservation resv = new reservation();
                resv.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
                button1_Click(sender, e);
              
                if (LoginPage.success == true)
                {
                    title = names[2].Text;
                    reservation resv = new reservation();
                    resv.ShowDialog();
                }
            }
        }

        private void res4_Click(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {
                title = names[3].Text;
                reservation resv = new reservation();
                resv.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
                button1_Click(sender, e);
              
                if (LoginPage.success == true)
                {
                    title = names[3].Text;
                    reservation resv = new reservation();
                    resv.ShowDialog();
                }
            }
        }

        private void res5_Click(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {
                title = names[4].Text;
                reservation resv = new reservation();
                resv.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
                button1_Click(sender, e);
             
                if (LoginPage.success == true)
                {
                    title = names[3].Text;
                    reservation resv = new reservation();
                    resv.ShowDialog();
                }
            }
        }

        private void res6_Click(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {
                title = names[5].Text;
                reservation resv = new reservation();
                resv.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
                button1_Click(sender, e);
              
                if (LoginPage.success == true)
                {
                    title = names[5].Text;
                    reservation resv = new reservation();
                    resv.ShowDialog();
                }
            }
        }
        
        

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {
                title = names[2].Text;
                snack s = new snack();
                s.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
                button1_Click(sender, e);
                MainPage mainPage = Application.OpenForms.OfType<MainPage>().FirstOrDefault();
                mainPage.UpdateInformation();
                if (LoginPage.success == true)
                {
                    title = names[2].Text;
                    snack s = new snack();
                    s.ShowDialog();
                }
            }
            
        }
    }
}
