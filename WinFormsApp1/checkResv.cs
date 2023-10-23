using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class checkResv : Form
    {
        public static string checkNumber="";
        public checkResv()
        {
            InitializeComponent();
            checkNumber = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                checkNumber = maskedTextBox1.Text;
                result r = new result();
                r.ShowDialog();
            }
            else
                MessageBox.Show("전화번호를 입력해주세요.");

        }
    }
}
