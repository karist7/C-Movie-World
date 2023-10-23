using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WinFormsApp1
{
    public partial class MoreInformation : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        DataTable dataTable;

        public MoreInformation()
        {
            InitializeComponent();
            title.Text = MainPage.title;
            res.Text = MainPage.rate;
            date.Text = MainPage.date;

            connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/movie.db");
            connection.Open();
            String sql = "select * from movie where Title='" + title.Text + "'";
            command = new SQLiteCommand(sql, connection);
            SQLiteDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                byte[] img = (byte[])(rdr["image"]);
                director.Text = rdr["director"].ToString();
                actor.Text = rdr["actor"].ToString();
                genre.Text = rdr["genre"].ToString();
                basic.Text = rdr["grade"].ToString() + rdr["basicInformation"].ToString();
                label1.Text = rdr["intro"].ToString();
                MemoryStream mstream = new MemoryStream(img);
                Image image = Image.FromStream(mstream);
                pictureBox1.Image = image;
            }
            rdr.Close();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        private void res1_Click(object sender, EventArgs e)
        {
            if (LoginPage.success == true)
            {

                reservation resv = new reservation();
                resv.ShowDialog();
            }
            else
            {
                MainPage mainPage = Application.OpenForms.OfType<MainPage>().FirstOrDefault();


                MessageBox.Show("로그인을 해주세요.");
                LoginPage l = new LoginPage(mainPage);
                l.ShowDialog();
                if (LoginPage.success == true)
                {
                    reservation resv = new reservation();
                    resv.ShowDialog();
                }

            }


        }
    }
}
