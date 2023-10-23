namespace WinFormsApp1
{
    partial class admin
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(307, 151);
            button1.Name = "button1";
            button1.Size = new Size(88, 51);
            button1.TabIndex = 0;
            button1.Text = "영 화";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(431, 151);
            button2.Name = "button2";
            button2.Size = new Size(88, 51);
            button2.TabIndex = 1;
            button2.Text = "스 낵";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(99, 155);
            label1.Name = "label1";
            label1.Size = new Size(174, 32);
            label1.TabIndex = 2;
            label1.Text = "판매 금액 조회";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(285, 9);
            label2.Name = "label2";
            label2.Size = new Size(166, 32);
            label2.TabIndex = 3;
            label2.Text = "관리자 페이지";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(99, 246);
            label3.Name = "label3";
            label3.Size = new Size(118, 32);
            label3.TabIndex = 4;
            label3.Text = "좌석 조회";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "2023-06-21", "2023-06-22", "2023-06-23", "2023-06-24", "2023-06-25" });
            comboBox1.Location = new Point(307, 246);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(99, 23);
            comboBox1.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(431, 245);
            button3.Name = "button3";
            button3.Size = new Size(88, 40);
            button3.TabIndex = 6;
            button3.Text = "조 회";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(307, 318);
            button4.Name = "button4";
            button4.Size = new Size(99, 48);
            button4.TabIndex = 7;
            button4.Text = "조 회";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(99, 321);
            label4.Name = "label4";
            label4.Size = new Size(118, 32);
            label4.TabIndex = 8;
            label4.Text = "예매 조회";
            // 
            // admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "admin";
            Text = "admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private Button button3;
        private Button button4;
        private Label label4;
    }
}