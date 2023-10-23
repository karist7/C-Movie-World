using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Data.SQLite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WinFormsApp1
{
    public partial class seat : Form
    {
        List<Button> buttonList = new List<Button>();
        List<bool> flag = new List<bool>();
        public static List<string> selected = new List<string>();
        int count = 0;
        public static int select = 0;
        int adultPrice = 0, TeenagerPrice = 0, childPrice = 0;
        public static int price = 0;
        public static int adult = 0, Teenager = 0, child = 0;
        
        string str = "";
        public seat()
        {
            adult = 0;
            Teenager = 0;
            child = 0;
            select = 0; count = 0;
            str = "";
            selected.Clear();
            InitializeComponent();
            InitializeButtons();
            label11.Text = reservation.DATE.ToString();
            label13.Text = reservation.PLACE;
            label14.Text = reservation.TIME.ToString();
            label12.Text = reservation.TITLE;
            for (int i = 0; i < buttonList.Count; i++)
            {
                flag.Add(false);
            }
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/reservation.db");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = $"SELECT seat FROM resv where place = '{label13.Text.Trim()}' AND title = '{label12.Text.Trim()}' AND date = '{label11.Text.Trim()}' AND time = '{label14.Text.Trim()}'";

            SQLiteDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                string[] str = reader["seat"].ToString().Split(" ");
                for (int i = 0; i < str.Length; i++)
                {
                    list.Add(str[i]);

                }
            }
            for (int j = 0; j < list.Count; j++)
            {
                for (int k = 0; k < buttonList.Count; k++)
                {
                    if (buttonList[k].Text == list[j])
                    {
                        buttonList[k].BackColor = Color.Silver;
                        buttonList[k].Enabled = false;

                    }
                }
            }
            reader.Close();
            connection.Close();


        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int k = 0;
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (buttonList[i].Name == clickedButton.Name)
                {
                    k = i;
                }
            }
            if (flag[k])
            {
                // 클릭한 버튼이 이미 활성화된 버튼인 경우
                clickedButton.BackColor = Color.LightGreen; // 버튼 색을 은색으로 변경
                flag[k] = false;
                bool fl;
                selected.Remove(clickedButton.Text);

                selected.Sort();
                str = "";
                for (int i = 0; i < selected.Count; i++)
                {
                    str += selected[i] + " ";
                }
                label21.Text = str;
                select--;
            }
            else
            {
                if (select < count)
                {
                    select++;
                    selected.Add(clickedButton.Text);
                    selected.Sort();
                    str = "";
                    for (int i = 0; i < selected.Count; i++)
                    {
                        str += selected[i] + " ";
                    }
                    label21.Text = str;

                    clickedButton.BackColor = Color.LightBlue; // 버튼 색을 하늘색으로 변경
                    flag[k] = true;
                }
            }
        }

        private void InitializeButtons()
        {

            buttonList.Add(button1);
            buttonList.Add(button3);
            buttonList.Add(button2);
            buttonList.Add(button4);
            buttonList.Add(button5);
            buttonList.Add(button6);
            buttonList.Add(button7);
            buttonList.Add(button8);
            buttonList.Add(button9);
            buttonList.Add(button10);
            buttonList.Add(button11);
            buttonList.Add(button12);
            buttonList.Add(button13);
            buttonList.Add(button14);
            buttonList.Add(button15);
            buttonList.Add(button16);
            buttonList.Add(button17);
            buttonList.Add(button18);
            buttonList.Add(button19);
            buttonList.Add(button20);
            buttonList.Add(button21);
            buttonList.Add(button22);
            buttonList.Add(button23);
            buttonList.Add(button24);
            buttonList.Add(button25);
            buttonList.Add(button26);
            buttonList.Add(button27);
            buttonList.Add(button28);



            foreach (Button button in buttonList)
            {
                button.BackColor = Color.LightGreen;
                button.Click += Button_Click; // 클릭 이벤트 핸들러 등록
            }
        }

        private void plus1_Click(object sender, EventArgs e)
        {
            if (count < 6)
            {
                adult = int.Parse(label4.Text);
                adult += 1;
                label4.Text = adult.ToString();
                count++;
                adultPrice += 10000;
                label25.Text = adultPrice.ToString();
            }

        }

        private void plus2_Click(object sender, EventArgs e)
        {
            if (count < 6)
            {
                Teenager = int.Parse(label5.Text);
                Teenager += 1;
                label5.Text = Teenager.ToString();
                count++;
                TeenagerPrice += 7000;
                label26.Text = TeenagerPrice.ToString();
            }
        }

        private void plus3_Click(object sender, EventArgs e)
        {
            if (count < 6)
            {
                child = int.Parse(label6.Text);
                child += 1;
                label6.Text = child.ToString();
                count++;
                childPrice += 5000;
                label27.Text = childPrice.ToString();
            }
        }

        private void minus1_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                adult = int.Parse(label4.Text);
                if (adult < 0)
                    return;
                adult--;
                label4.Text = adult.ToString();
                count--;
                adultPrice -= 10000;
                label25.Text = adultPrice.ToString();
            }
        }

        private void minus2_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                Teenager = int.Parse(label5.Text);
                if (Teenager < 0)
                    return;
                Teenager--;
                label5.Text = Teenager.ToString();
                count--;
                TeenagerPrice -= 7000;
                label26.Text = TeenagerPrice.ToString();
            }
        }

        private void minus3_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                child = int.Parse(label6.Text);
                if (child < 0)
                    return;
                child--;
                label6.Text = child.ToString();
                count--;
                childPrice -= 5000;
                label27.Text = childPrice.ToString();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            count = 0;
            select = 0;
            for (int i = 0; i < flag.Count; i++)
            {
                flag[i] = false;
                if (buttonList[i].Enabled)
                    buttonList[i].BackColor = Color.LightGreen;


            }
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            selected.Clear();
            label21.Text = "좌석";
            adultPrice = 0;
            TeenagerPrice = 0;
            childPrice = 0;
            label25.Text = adultPrice.ToString();
            label26.Text = TeenagerPrice.ToString();
            label27.Text = childPrice.ToString();

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (count == select)
            {
                price = adultPrice + TeenagerPrice + childPrice;

                payment p = new payment();
                p.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("선택한 좌석의 수가 맞지 않습니다.");
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
