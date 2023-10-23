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
        private MainPage mainPage; // MainPage �ν��Ͻ� ���� �߰�

        public LoginPage(MainPage mainPage) // MainPage�� ������ �Ű������� ����
        {
            InitializeComponent();
            this.mainPage = mainPage; // MainPage �ν��Ͻ� ����
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
                        MessageBox.Show(Text_ID.Text + "�� �ݰ����ϴ�.", "ȯ���մϴ�.");

                        mainPage.UpdateInformation(); // MainPage�� UpdateInformation() ȣ��

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("�߸��� �н������Դϴ�.");
                    }

               
                }
                else if(Text_ID.Text == "root" && Text_Passwd.Text == "1234")
                {
                    MessageBox.Show("������ ���� �����մϴ�.");
                    admin a = new admin();
                    a.ShowDialog();
                }
                else
                {
                    MessageBox.Show("��ġ�ϴ� ������ �����ϴ�.");
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
