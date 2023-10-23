using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WinFormsApp1
{

    public partial class snack : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;

        Label[] price = new Label[12];
        Label[] name = new Label[12];
        Label[] sub = new Label[12];
        public static int total=0;
        PictureBox[] Picture = new PictureBox[12];
        public snack()
        {
            InitializeComponent();
            initial();
            try
            {
                connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/snack.db");
                connection.Open();
                String sql = "select * from snack";
                command = new SQLiteCommand(sql, connection);
                SQLiteDataReader rdr = command.ExecuteReader();
                int i = 0;
                while (rdr.Read())
                {
                    name[i].Text = rdr["name"].ToString();
                    price[i].Text = rdr["price"].ToString();


                    byte[] img = (byte[])(rdr["image"]);
                    MemoryStream mstream = new MemoryStream(img);
                    Image image = Image.FromStream(mstream);
                    Picture[i].Image = image;



                    i++;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void initial()
        {
            name[0] = label1;
            name[1] = label2;
            name[2] = label3;
            name[3] = label4;
            name[4] = label5;
            name[5] = label6;
            name[6] = label7;
            name[7] = label8;
            name[8] = label9;
            name[9] = label10;
            name[10] = label11;
            name[11] = label12;
            price[0] = label13;
            price[1] = label14;
            price[2] = label15;
            price[3] = label16;
            price[4] = label17;
            price[5] = label18;
            price[6] = label19;
            price[7] = label20;
            price[8] = label21;
            price[9] = label22;
            price[10] = label23;
            price[11] = label24;
            Picture[0] = pictureBox1;
            Picture[1] = pictureBox2;
            Picture[2] = pictureBox3;
            Picture[3] = pictureBox4;
            Picture[4] = pictureBox5;
            Picture[5] = pictureBox6;
            Picture[6] = pictureBox7;
            Picture[7] = pictureBox8;
            Picture[8] = pictureBox9;
            Picture[9] = pictureBox10;
            Picture[10] = pictureBox11;
            Picture[11] = pictureBox12;
            sub[0] = label27;
            sub[1] = label28;
            sub[2] = label29;
            sub[3] = label30;
            sub[4] = label31;
            sub[5] = label32;
            sub[6] = label33;
            sub[7] = label34;
            sub[8] = label35;
            sub[9] = label36;
            sub[10] = label37;
            sub[11] = label38;


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox1.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label13.Text);
                label27.Text = (labelValue * int.Parse(comboBox1.Text)).ToString();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox2.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label14.Text);
                label28.Text = (labelValue * int.Parse(comboBox2.Text)).ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox3.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label15.Text);
                label29.Text = (labelValue * int.Parse(comboBox3.Text)).ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox4.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label16.Text);
                label30.Text = (labelValue * int.Parse(comboBox4.Text)).ToString();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox5.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label17.Text);
                label31.Text = (labelValue * int.Parse(comboBox5.Text)).ToString();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox6.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label18.Text);
                label32.Text = (labelValue * int.Parse(comboBox6.Text)).ToString();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox7.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label19.Text);
                label33.Text = (labelValue * int.Parse(comboBox7.Text)).ToString();
            }
        }



        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox8.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label20.Text);
                label34.Text = (labelValue * int.Parse(comboBox8.Text)).ToString();
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox9.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label21.Text);
                label35.Text = (labelValue * int.Parse(comboBox9.Text)).ToString();
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox10.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label22.Text);
                label36.Text = (labelValue * int.Parse(comboBox10.Text)).ToString();
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox11.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label23.Text);
                label37.Text = (labelValue * int.Parse(comboBox11.Text)).ToString();
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxValue;
            if (int.TryParse(comboBox12.Text, out comboBoxValue))
            {
                int labelValue = int.Parse(label24.Text);
                label38.Text = (labelValue * int.Parse(comboBox12.Text)).ToString();
            }
        }

        private void snack_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            total = 0;
            for (int i = 0; i < sub.Length; i++)
            {
                total += int.Parse(sub[i].Text);
            }
            label26.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label26.Text == "0")
            {
                MessageBox.Show("장바구니가 비었습니다.");
            }
            else
            {
                snackPay s = new snackPay();
                s.ShowDialog();
                
            }
        }
    }

}
