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
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public partial class LoginPage : Form
    {
        public static string user;
        public static bool success;
        public static string number;
        private MainPage mainPage; // MainPage 인스턴스 변수 추가

        public LoginPage(MainPage mainPage) // MainPage를 생성자 매개변수로 받음
        {
            InitializeComponent();
            this.mainPage = mainPage; // MainPage 인스턴스 저장
        }

        private void Register_Click(object sender, EventArgs e)
        {
            RegisterPage r = new RegisterPage();
            r.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                success = false;
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/account.db");
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = $"SELECT * FROM account where id = '{Text_ID.Text.Trim()}'";
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string storedPassword = reader["password"].ToString();
                    if (storedPassword == Text_Passwd.Text.Trim())
                    {
                        success = true;
                        user = reader["id"].ToString();
                        number = reader["phoneNumber"].ToString();
                        MessageBox.Show(Text_ID.Text + "님 반갑습니다.", "환영합니다.");

                        mainPage.UpdateInformation(); // MainPage의 UpdateInformation() 호출

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("잘못된 패스워드입니다.");
                    }

               
                }
                else if(Text_ID.Text == "root" && Text_Passwd.Text == "1234")
                {
                    MessageBox.Show("관리자 모드로 접속합니다.");
                    admin a = new admin();
                    a.ShowDialog();
                }
                else
                {
                    MessageBox.Show("일치하는 정보가 없습니다.");
                }
                reader.Close();

                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            if (success)
            {
                this.Close();
            }
        }
    }
}
