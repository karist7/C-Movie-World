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
    public partial class result : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        DataTable dataTable;
        SQLiteDataReader rdr;
        string phone;
        string str = "";

        public result()
        {
            try
            {

                InitializeComponent();
                if (checkResv.checkNumber == "")
                {
                    phone = LoginPage.number;
                }
                else
                    phone = checkResv.checkNumber;

                connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/reservation.db");
                connection.Open();

                command = new SQLiteCommand(connection);


                command.CommandText = $"SELECT* FROM resv where phoneNumber='{phone}'";
                SQLiteDataReader reader = command.ExecuteReader();

                dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;

                reader.Close();
                dataGridView1.Columns[0].HeaderText = "얘매번호";
                dataGridView1.Columns[1].HeaderText = "이름";
                dataGridView1.Columns[2].HeaderText = "전화번호";
                dataGridView1.Columns[3].HeaderText = "영화관";
                dataGridView1.Columns[4].HeaderText = "제목";
                dataGridView1.Columns[5].HeaderText = "날짜";
                dataGridView1.Columns[6].HeaderText = "시간";
                dataGridView1.Columns[7].HeaderText = "좌석";
                dataGridView1.Columns[8].HeaderText = "성인";
                dataGridView1.Columns[9].HeaderText = "청소년";
                dataGridView1.Columns[10].HeaderText = "어린이";
                dataGridView1.Columns[11].HeaderText = "가격";
                dataGridView1.FirstDisplayedCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                str = dataGridView1.CurrentCell.Value.ToString();
               
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            // 변경된 셀의 값 가져오기
            if (columnIndex >= 0 && rowIndex >= 0)
            {


                DataGridViewCell cell = dataGridView1.Rows[rowIndex].Cells[0];
                str = cell.Value.ToString();

            }

        }

        private void result_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (str != "")
            {
                try
                {
                    DialogResult result = MessageBox.Show("환불하시겠습니까?", "환불 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string s = "";
                        connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/reservation.db");
                        connection.Open();

                        command = new SQLiteCommand(connection);
                        command.CommandText = $"SELECT * FROM resv where num={str}";
                        SQLiteDataReader reader = command.ExecuteReader();
                        string place = "";
                        string date = "";
                        string time = "";
                        string title = "";
                        if (reader.Read())
                        {

                            s = reader["seat"].ToString();
                            place = reader["place"].ToString();
                            date = reader["date"].ToString();
                            time = reader["time"].ToString();
                            title = reader["title"].ToString();
                        }
                        reader.Close();
                        connection.Close();

                        connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/adminpay.db");
                        connection.Open();

                        command = new SQLiteCommand(connection);

                        command.CommandText = $"SELECT * FROM pay where seat = '{s}'";
                        int qlValue = 0;
                        List<string> list = new List<string>(); ;
                        rdr = command.ExecuteReader();
                        if (rdr.Read())
                        {
                            
                            string[] str = rdr["seat"].ToString().Split(" ");
                            for (int i = 0; i < str.Length; i++)
                            {
                                list.Add(str[i]);

                            }
                        }
                        qlValue = list.Count;
                        rdr.Close();
                        
                        
                        connection.Close();

                        connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/theater.db");
                        connection.Open();
                        command = new SQLiteCommand(connection);
                        

                        command.CommandText = $"SELECT * FROM theater where place  = '{place.Trim()}' AND title = '{title.Trim()}' AND date = '{date.Trim()}'AND time = '{time.Trim()}'";
                        int value = 0;
                        rdr = command.ExecuteReader();
                        if (rdr.Read())
                        {
                            value = int.Parse(rdr["seats"].ToString());
                        }
                        int total = qlValue + value;
                        
                        rdr.Close();

                        command.CommandText = $"UPDATE theater set seats='{total}' WHERE place  = '{place.Trim()}' AND title = '{title.Trim()}' AND date = '{date.Trim()}'AND time = '{time.Trim()}'";
                        command.ExecuteNonQuery();
                        connection.Close();
                        

                        connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/reservation.db");
                        connection.Open();

                        command = new SQLiteCommand(connection);
                        command.CommandText = $"DELETE FROM resv where num ='{str}'";
                        command.ExecuteNonQuery();
                        MessageBox.Show("환불이 완료되었습니다.");
                        
                        //데이터 갱신
                        string query = $"SELECT* FROM resv where phoneNumber='{phone}'";
                        command.CommandText = query;
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        connection.Close();

                        connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/adminpay.db");
                        connection.Open();
                        command = new SQLiteCommand(connection);
                        command.CommandText = $"DELETE FROM pay where seat ='{s}'";
                        command.ExecuteNonQuery();
                        
                        connection.Close();
                        list.Clear();

                        dataGridView1.FirstDisplayedCell = dataGridView1.Rows[0].Cells[0];
                        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                        str = dataGridView1.CurrentCell.Value.ToString();
                    } 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
                MessageBox.Show("선택된 항목이 없습니다.");

        }
    }
}
