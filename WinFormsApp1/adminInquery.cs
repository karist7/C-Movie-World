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
    public partial class adminInquery : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        DataTable dataTable;
        SQLiteDataReader rdr;
        public adminInquery()
        {
            InitializeComponent();
            connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/reservation.db");
            connection.Open();

            command = new SQLiteCommand(connection);


            command.CommandText = $"SELECT* FROM resv";
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


            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
