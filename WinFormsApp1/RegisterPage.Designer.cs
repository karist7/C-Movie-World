namespace WinFormsApp1
{
    partial class RegisterPage
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            PhoneNumber = new MaskedTextBox();
            NameTextBox = new TextBox();
            Password = new TextBox();
            ID = new TextBox();
            button1 = new Button();
            button2 = new Button();
            checkPassword = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(179, 41);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 0;
            label1.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(179, 109);
            label2.Name = "label2";
            label2.Size = new Size(97, 30);
            label2.TabIndex = 1;
            label2.Text = "비밀번호";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(179, 255);
            label3.Name = "label3";
            label3.Size = new Size(55, 30);
            label3.TabIndex = 2;
            label3.Text = "이름";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(179, 317);
            label4.Name = "label4";
            label4.Size = new Size(97, 30);
            label4.TabIndex = 3;
            label4.Text = "전화번호";
            // 
            // PhoneNumber
            // 
            PhoneNumber.Location = new Point(402, 327);
            PhoneNumber.Mask = "000-9000-0000";
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Size = new Size(184, 23);
            PhoneNumber.TabIndex = 9;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(402, 265);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(184, 23);
            NameTextBox.TabIndex = 8;
            // 
            // Password
            // 
            Password.Location = new Point(402, 119);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(184, 23);
            Password.TabIndex = 6;
            // 
            // ID
            // 
            ID.Location = new Point(402, 51);
            ID.Name = "ID";
            ID.Size = new Size(184, 23);
            ID.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(230, 375);
            button1.Name = "button1";
            button1.Size = new Size(129, 54);
            button1.TabIndex = 10;
            button1.Text = "완료";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(422, 375);
            button2.Name = "button2";
            button2.Size = new Size(129, 54);
            button2.TabIndex = 11;
            button2.Text = "취소";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkPassword
            // 
            checkPassword.Location = new Point(402, 190);
            checkPassword.Name = "checkPassword";
            checkPassword.PasswordChar = '*';
            checkPassword.Size = new Size(184, 23);
            checkPassword.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(179, 183);
            label5.Name = "label5";
            label5.Size = new Size(146, 30);
            label5.TabIndex = 12;
            label5.Text = "비밀번호 확인";
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkPassword);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ID);
            Controls.Add(Password);
            Controls.Add(NameTextBox);
            Controls.Add(PhoneNumber);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterPage";
            Text = "회원가입";
            Load += 회원가입_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private MaskedTextBox PhoneNumber;
        private TextBox NameTextBox; // 'Name' 변수명을 'NameTextBox'로 변경
        private TextBox Password;
        private TextBox ID;
        private Button button1;
        private Button button2;
        private TextBox checkPassword;
        private Label label5;
    }
}