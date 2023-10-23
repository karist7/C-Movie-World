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
    public partial class RegisterPage : Form
    {
        bool flag;
        SQLiteConnection connection;
        SQLiteCommand command;
        DataTable dataTable;
        public RegisterPage()
        {
            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void 회원가입_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            if (ID.Text != "" && Password.Text != "" && checkPassword.Text != "" && NameTextBox.Text != "" && PhoneNumber.Text != "")
            {
                try
                {

                    connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/account.db");
                    connection.Open();

                    command = new SQLiteCommand(connection);
                    if (Password.Text != checkPassword.Text)
                    {
                        MessageBox.Show("비밀번호가 일치하지 않습니다.", "오류");
                    }
                    else
                    {
                        command.CommandText = $"INSERT INTO account (id, password, name, phonenumber) VALUES (" +
                     $"'{ID.Text.Trim()}', '{Password.Text.Trim()}', '{NameTextBox.Text.Trim()}', '{PhoneNumber.Text.Trim()}'" +
                     $")";
                        command.ExecuteNonQuery();
                        connection.Close();

                        flag = true;
                        MessageBox.Show("환영합니다." + ID.Text + "님", "회원가입 완료");
                        this.Close();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("아이디 중복으로 회원가입에 실패하였습니다.", "오류");
                }
            }

            else
                MessageBox.Show("항목을 모두 입력하시오", "오류");
            if (flag)
                this.Close();

        }
    }
}
