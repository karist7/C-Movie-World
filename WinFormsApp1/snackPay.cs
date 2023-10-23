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
using System.Xml.Schema;

namespace WinFormsApp1
{
    public partial class snackPay : Form
    {
        public snackPay()
        {
            InitializeComponent();
            textBox1.Text = snack.total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "" && maskedTextBox1.MaskFull)
            {
                try
                {

                    SQLiteConnection connection;
                    SQLiteCommand command;
                    connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/adminpay.db");
                    connection.Open();
                    command = new SQLiteCommand(connection);
                    command.CommandText = $"INSERT INTO pay (movie,snack) VALUES ('0','{snack.total}')";
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("결제 완료되었습니다.");
                    this.Close();

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("기입하지 않은 정보가 존재합니다.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.SelectedItem.ToString();
        }
    }
}
