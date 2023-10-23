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

namespace WinFormsApp1
{
    public partial class admin : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        int price = 0;
        public static string adminCheck;
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/adminpay.db");
            connection.Open();
            command = new SQLiteCommand(connection);
            command.CommandText = $"SELECT movie FROM pay";
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                price += int.Parse(rdr["movie"].ToString());
            }
            rdr.Close();
            MessageBox.Show(price.ToString() + "원");
            price = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/adminpay.db");
            connection.Open();
            command = new SQLiteCommand(connection);
            command.CommandText = $"SELECT snack FROM pay";
            SQLiteDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                price += int.Parse(rdr["snack"].ToString());
            }
            rdr.Close();
            MessageBox.Show(price.ToString() + "원");
            price = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminCheck = comboBox1.Text;
            adminResult r = new adminResult();
            r.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminInquery q = new adminInquery();
            q.ShowDialog();
        }
    }
}
