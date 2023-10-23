namespace WinFormsApp1
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            Text_ID = new TextBox();
            Text_Passwd = new TextBox();
            label3 = new Label();
            Login = new Button();
            Register = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(201, 109);
            label1.Name = "label1";
            label1.Size = new Size(32, 25);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(201, 176);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // Text_ID
            // 
            Text_ID.Location = new Point(413, 114);
            Text_ID.Multiline = true;
            Text_ID.Name = "Text_ID";
            Text_ID.Size = new Size(190, 23);
            Text_ID.TabIndex = 2;
            // 
            // Text_Passwd
            // 
            Text_Passwd.Location = new Point(413, 181);
            Text_Passwd.Multiline = true;
            Text_Passwd.Name = "Text_Passwd";
            Text_Passwd.PasswordChar = '*';
            Text_Passwd.Size = new Size(190, 23);
            Text_Passwd.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕 Semilight", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(327, 34);
            label3.Name = "label3";
            label3.Size = new Size(134, 32);
            label3.TabIndex = 4;
            label3.Text = "어서오세요";
            // 
            // Login
            // 
            Login.Location = new Point(218, 278);
            Login.Name = "Login";
            Login.Size = new Size(139, 75);
            Login.TabIndex = 5;
            Login.Text = "로그인";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // Register
            // 
            Register.Location = new Point(464, 278);
            Register.Name = "Register";
            Register.Size = new Size(139, 75);
            Register.TabIndex = 6;
            Register.Text = "회원가입";
            Register.UseVisualStyleBackColor = true;
            Register.Click += Register_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Register);
            Controls.Add(Login);
            Controls.Add(label3);
            Controls.Add(Text_Passwd);
            Controls.Add(Text_ID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginPage";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox Text_ID;
        private TextBox Text_Passwd;
        private Label label3;
        private Button Login;
        private Button Register;
    }
}