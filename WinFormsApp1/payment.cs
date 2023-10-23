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
using System.Windows.Input;

namespace WinFormsApp1
{
    public partial class payment : Form
    {
        SQLiteDataReader rdr;
        string str = "";
        public payment()
        {
            InitializeComponent();
            int i;
            for (i = 0; i < seat.selected.Count-1; i++)
            {
                str += seat.selected[i].ToString() + " ";
            }
            str += seat.selected[i].ToString();
            label7.Text = str;
            label6.Text = reservation.DATE + " " + reservation.TIME;
            label5.Text = reservation.TITLE;
            textBox1.Text = seat.price.ToString();
            textBox2.Text = "0";
            textBox3.Text = seat.price.ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                textBox2.Text = "0";
                textBox3.Text = seat.price.ToString();
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                textBox3.Text = (seat.price - (seat.price * 0.05)).ToString();
                textBox2.Text = (seat.price * 0.05).ToString();
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                textBox3.Text = (seat.price - (seat.price * 0.15)).ToString();
                textBox2.Text = (seat.price * 0.15).ToString();
            }
            else
            {
                textBox3.Text = (seat.price - (seat.price * 0.3)).ToString();
                textBox2.Text = (seat.price * 0.3).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && maskedTextBox1.MaskFull)
            {
                try
                {
                    string name = "";
                    string phoneNumber = "";
                    SQLiteConnection connection;
                    SQLiteCommand command;
                    connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/account.db");
                    connection.Open();
                    command = new SQLiteCommand(connection);
                    command.CommandText = $"SELECT * FROM account where id = '{LoginPage.user.Trim()}'";
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        name = reader["name"].ToString();
                        phoneNumber = reader["phoneNumber"].ToString();

                    }

                    reader.Close();
                    connection.Close();



                    connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/reservation.db");
                    connection.Open();

                    command = new SQLiteCommand(connection);
                    command.CommandText = $"INSERT INTO resv (name, phoneNumber,title , date, seat,time,place,adult,teen,child,price) VALUES (" +
                          $"'{name.Trim()}', '{phoneNumber.Trim()}', '{reservation.TITLE.Trim()}', '{reservation.DATE.Trim()}', '{label7.Text.Trim()}', '{reservation.TIME.Trim()}', '{reservation.PLACE.Trim()}'" +
                          $",'{seat.adult.ToString()}','{seat.Teenager.ToString()}','{seat.child.ToString()}','{textBox3.Text}'" +
                             $")";
                    command.ExecuteNonQuery();
                    

                    command = new SQLiteCommand(connection);
                    command.CommandText = $"SELECT num FROM resv where place  = '{reservation.PLACE.Trim()}' AND title = '{reservation.TITLE.Trim()}' AND date = '{reservation.DATE.Trim()}'AND time = '{reservation.TIME.Trim()}'"+
                        $"AND name = '{name.Trim()}'AND phoneNumber = '{phoneNumber.Trim()}'AND adult = '{seat.adult.ToString()}'AND teen = '{seat.Teenager.ToString().Trim()}'AND child = '{seat.child.ToString().Trim()}'AND price = '{textBox3.Text.Trim()}'";
                    int num = 0;
                    rdr = command.ExecuteReader();
                    if (rdr.Read())
                    {
                        num = int.Parse(rdr["num"].ToString());
                    }
                    rdr.Close();
                    connection.Close();

                    connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/theater.db");
                    connection.Open();

                    command = new SQLiteCommand(connection);

                    command.CommandText = $"SELECT * FROM theater where place  = '{reservation.PLACE.Trim()}' AND title = '{reservation.TITLE.Trim()}' AND date = '{reservation.DATE.Trim()}'AND time = '{reservation.TIME.Trim()}'";
                    int value = 0;
                    rdr = command.ExecuteReader();
                    if (rdr.Read())
                    {
                        value = int.Parse(rdr["seats"].ToString());
                    }
                    rdr.Close();
                    int seats = value - seat.select;
                    command = new SQLiteCommand(connection);
                    command.CommandText = $"UPDATE theater set seats='{seats.ToString()}' WHERE place  = '{reservation.PLACE.Trim()}' AND title = '{reservation.TITLE.Trim()}' AND date = '{reservation.DATE.Trim()}'AND time = '{reservation.TIME.Trim()}'";
                    command.ExecuteNonQuery();
                    connection.Close();

                    connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/adminpay.db");
                    connection.Open();
                    command = new SQLiteCommand(connection);
                    command.CommandText = $"INSERT INTO pay (movie,snack,seat) VALUES ('{textBox3.Text}','0','{str}')";
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("예약이 완료되었습니다.");
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("모든 정보를 기입하십시오.");
            }

        }
    }
}
