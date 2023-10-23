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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using Button = System.Windows.Forms.Button;
using System.Reflection;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Label = System.Windows.Forms.Label;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Input;

namespace WinFormsApp1
{
    public partial class reservation : Form
    {
        private Button[] buttons; // 버튼 배열
        private Button activeButton; // 현재 활성화된 버튼
        SQLiteConnection connection;
        SQLiteCommand command;
        DataTable dataTable;
        public static string TIME = "";
        public static string DATE = "2023-06-21";
        public static string PLACE = "강남";
        public static string TITLE = MainPage.title;
        Label[] list = new Label[6];

        public reservation()
        {
            try
            {

                InitializeComponent();
                InitializeButtons();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/movie.db");
                connection.Open();

                command = new SQLiteCommand(connection);


                command.CommandText = "SELECT grade,title,genre FROM movie";
                SQLiteDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
                reader.Close();

                dataGridView1.Columns[0].HeaderText = "등급";
                dataGridView1.Columns[1].HeaderText = "제목";
                dataGridView1.Columns[2].HeaderText = "장르";
                TreeNode rootNode1 = treeView1.Nodes[0];
                treeView1.SelectedNode = rootNode1.Nodes[0];
                connection.Close();


                list[0] = label1;
                list[1] = label2;
                list[2] = label3;
                list[3] = label4;
                list[4] = label5;
                list[5] = label6;
                SQLiteConnection connection2 = new SQLiteConnection("Data Source=" + Application.StartupPath + "/theater.db");
                connection2.Open();

                SQLiteCommand command2 = new SQLiteCommand(connection2);
                command2.CommandText = $"SELECT * FROM theater where place  = '{PLACE.Trim()}' AND title = '{MainPage.title.Trim()}' AND date = '{DATE.Trim()}'";
                SQLiteDataReader readers = command2.ExecuteReader();
                int i = 0;
                while (readers.Read() && i < list.Length)
                {

                    string str = readers["seats"].ToString();
                    list[i].Text = str + "석";
                    if (list[i] == null)
                    {
                        MessageBox.Show($"list[{i}] is null");
                    }

                    i++;
                }
                readers.Close();
                connection2.Close();



                DataGridViewRow row = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["title"].Value.ToString() == MainPage.title);

                DATE = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                if (row != null)
                {
                    // 값이 존재할 경우 해당 셀을 선택
                    dataGridView1.CurrentCell = row.Cells["title"];

                }
                else
                {
                    // 값이 없을 경우 선택을 해제
                    dataGridView1.ClearSelection();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton == activeButton)
            {
                // 클릭한 버튼이 이미 활성화된 버튼인 경우
                clickedButton.BackColor = Color.Silver; // 버튼 색을 은색으로 변경
                activeButton = null; // 활성화된 버튼을 해제
            }
            else if (activeButton == null)
            {
                TIME = clickedButton.Text;
                // 아무 버튼도 활성화되어 있지 않은 경우
                clickedButton.BackColor = Color.LightBlue; // 버튼 색을 하늘색으로 변경
                activeButton = clickedButton; // 클릭한 버튼을 활성화
            }
        }

        private void InitializeButtons()
        {
            buttons = new Button[] { button1, button2, button3, button4, button5, button6 };

            foreach (Button button in buttons)
            {
                button.Click += Button_Click; // 클릭 이벤트 핸들러 등록
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1.HideSelection = false;
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = selectedNode.Parent;

            // 부모 노드가 루트 노드가 아닌 경우에만 처리
            if (parentNode != null)
            {

                PLACE = selectedNode.Text;
                label8.Text = PLACE;
                SQLiteConnection connection2 = new SQLiteConnection("Data Source=" + Application.StartupPath + "/theater.db");
                connection2.Open();
                SQLiteCommand command2 = new SQLiteCommand(connection2);
                command2.CommandText = $"SELECT * FROM theater where place  = '{PLACE.Trim()}' AND title = '{TITLE.Trim()}' AND date = '{DATE.Trim()}'";
                SQLiteDataReader readers = command2.ExecuteReader();
                int i = 0;

                while (readers.Read() && i < list.Length)
                {

                    string str = readers["seats"].ToString();
                    list[i].Text = str + "석";
                    if (list[i] == null)
                    {
                        MessageBox.Show($"list[{i}] is null");
                    }

                    i++;
                }
                readers.Close();
                connection2.Close();

            }
            else
            {

                PLACE = "";
                label8.Text = PLACE;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            DateTime currentDate = DateTime.Now.Date;

            DATE = selectedDate.Date.ToString("yyyy-MM-dd");

            SQLiteConnection connection2 = new SQLiteConnection("Data Source=" + Application.StartupPath + "/theater.db");
            connection2.Open();

            SQLiteCommand command2 = new SQLiteCommand(connection2);

            if (TITLE == "")
                TITLE = MainPage.title;
            command2.CommandText = $"SELECT * FROM theater where place  = '{PLACE.Trim()}' AND title = '{TITLE.Trim()}' AND date = '{DATE.Trim()}'";
            SQLiteDataReader readers = command2.ExecuteReader();
            int i = 0;
            while (readers.Read() && i < list.Length)
            {

                string str = readers["seats"].ToString();
                list[i].Text = str + "석";
                if (list[i] == null)
                {
                    MessageBox.Show($"list[{i}] is null");
                }

                i++;
            }
            readers.Close();
            connection2.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;
            TITLE = row["title"].ToString();
            if (TIME != "" && DATE != "" && PLACE != "" && TITLE != "")
            {
                seat s = new seat();
                s.ShowDialog();
                this.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            // 변경된 셀의 값 가져오기
            if (columnIndex >= 0 && rowIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[rowIndex].Cells[1];
                TITLE = cell.Value.ToString();

            }
            SQLiteConnection connection2 = new SQLiteConnection("Data Source=" + Application.StartupPath + "/theater.db");
            connection2.Open();

            SQLiteCommand command2 = new SQLiteCommand(connection2);
            command2.CommandText = $"SELECT * FROM theater where place  = '{PLACE.Trim()}' AND title = '{TITLE.Trim()}' AND date = '{DATE.Trim()}'";
            SQLiteDataReader readers = command2.ExecuteReader();
            int i = 0;
            while (readers.Read() && i < list.Length)
            {

                string str = readers["seats"].ToString();
                list[i].Text = str + "석";
                if (list[i] == null)
                {
                    MessageBox.Show($"list[{i}] is null");
                }

                i++;
            }
            readers.Close();
            connection2.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





