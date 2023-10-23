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
    public partial class adminResult : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        DataTable dataTable;
        public adminResult()
        {
            InitializeComponent();
            connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "/theater.db");
            connection.Open();

            command = new SQLiteCommand(connection);


            command.CommandText = $"SELECT* FROM theater where date='{admin.adminCheck}'";
            SQLiteDataReader reader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;
            
            reader.Close();
            dataGridView1.Columns[0].HeaderText = "지역";
            dataGridView1.Columns[1].HeaderText = "날짜";
            dataGridView1.Columns[2].HeaderText = "시간";
            dataGridView1.Columns[3].HeaderText = "제목";
            dataGridView1.Columns[4].HeaderText = "좌석수";
        }
    }
}
