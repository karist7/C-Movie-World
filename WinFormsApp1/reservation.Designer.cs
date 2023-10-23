namespace WinFormsApp1
{
    partial class reservation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("강남");
            TreeNode treeNode2 = new TreeNode("서울", new TreeNode[] { treeNode1 });
            TreeNode treeNode3 = new TreeNode("송도");
            TreeNode treeNode4 = new TreeNode("수원");
            TreeNode treeNode5 = new TreeNode("경기/인천", new TreeNode[] { treeNode3, treeNode4 });
            TreeNode treeNode6 = new TreeNode("천안");
            TreeNode treeNode7 = new TreeNode("온양온천");
            TreeNode treeNode8 = new TreeNode("충남", new TreeNode[] { treeNode6, treeNode7 });
            dataGridView1 = new DataGridView();
            treeView1 = new TreeView();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label1 = new Label();
            label3 = new Label();
            label5 = new Label();
            label2 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(207, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 60;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(574, 233);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeNode1.Name = "노드1";
            treeNode1.Text = "강남";
            treeNode2.Name = "노드0";
            treeNode2.Text = "서울";
            treeNode3.Name = "노드5";
            treeNode3.Text = "송도";
            treeNode4.Name = "노드6";
            treeNode4.Text = "수원";
            treeNode5.Name = "노드4";
            treeNode5.Text = "경기/인천";
            treeNode6.Name = "노드9";
            treeNode6.Text = "천안";
            treeNode7.Name = "노드10";
            treeNode7.Text = "온양온천";
            treeNode8.Name = "노드8";
            treeNode8.Text = "충남";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode2, treeNode5, treeNode8 });
            treeView1.Size = new Size(189, 233);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(810, 12);
            dateTimePicker1.MaxDate = new DateTime(2023, 6, 25, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2023, 6, 21, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Value = new DateTime(2023, 6, 21, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(793, 59);
            button1.Name = "button1";
            button1.Size = new Size(77, 45);
            button1.TabIndex = 3;
            button1.Text = "08 : 00";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(921, 59);
            button2.Name = "button2";
            button2.Size = new Size(76, 45);
            button2.TabIndex = 4;
            button2.Text = "11 : 00";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Silver;
            button3.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(793, 133);
            button3.Name = "button3";
            button3.Size = new Size(77, 45);
            button3.TabIndex = 5;
            button3.Text = "14 : 00";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Silver;
            button4.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(921, 133);
            button4.Name = "button4";
            button4.Size = new Size(76, 45);
            button4.TabIndex = 6;
            button4.Text = "17 : 00";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Silver;
            button5.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(793, 200);
            button5.Name = "button5";
            button5.Size = new Size(77, 45);
            button5.TabIndex = 7;
            button5.Text = "20 : 00";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Silver;
            button6.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(921, 200);
            button6.Name = "button6";
            button6.Size = new Size(76, 45);
            button6.TabIndex = 8;
            button6.Text = "23 : 00";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(921, 274);
            button7.Name = "button7";
            button7.Size = new Size(89, 43);
            button7.TabIndex = 9;
            button7.Text = "다음";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(876, 89);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(876, 163);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 11;
            label3.Text = "label2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(876, 230);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 12;
            label5.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(994, 89);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 13;
            label2.Text = "label4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(994, 163);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 14;
            label4.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(994, 230);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 15;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(12, 248);
            label7.Name = "label7";
            label7.Size = new Size(116, 21);
            label7.TabIndex = 16;
            label7.Text = "선택된 영화관:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(125, 249);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 17;
            label8.Text = "강남";
            // 
            // reservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 329);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(treeView1);
            Controls.Add(dataGridView1);
            Name = "reservation";
            Text = "reservation";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TreeView treeView1;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Label label1;
        private Label label3;
        private Label label5;
        private Label label2;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}