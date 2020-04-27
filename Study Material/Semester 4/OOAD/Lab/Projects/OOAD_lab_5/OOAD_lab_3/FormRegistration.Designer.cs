namespace OOAD_lab_3
{
    partial class formRegistration
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
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.cmdRegister = new System.Windows.Forms.Button();
            this.lnk_formLogin = new System.Windows.Forms.LinkLabel();
            this.lbl_info = new System.Windows.Forms.Label();
            this.cmbo_Secret_Questions = new System.Windows.Forms.ComboBox();
            this.lbl_SecretQuestion = new System.Windows.Forms.Label();
            this.lbl_Answer = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(172, 26);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(100, 20);
            this.txt_UserName.TabIndex = 0;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(172, 59);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(100, 20);
            this.txt_Password.TabIndex = 1;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(12, 33);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(83, 13);
            this.lbl_Username.TabIndex = 2;
            this.lbl_Username.Text = "Enter Username";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(12, 66);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(81, 13);
            this.lbl_Password.TabIndex = 3;
            this.lbl_Password.Text = "Enter Password";
            this.lbl_Password.Click += new System.EventHandler(this.lbl_Password_Click);
            // 
            // cmdRegister
            // 
            this.cmdRegister.Location = new System.Drawing.Point(197, 219);
            this.cmdRegister.Name = "cmdRegister";
            this.cmdRegister.Size = new System.Drawing.Size(75, 23);
            this.cmdRegister.TabIndex = 4;
            this.cmdRegister.Text = "Register";
            this.cmdRegister.UseVisualStyleBackColor = true;
            this.cmdRegister.Click += new System.EventHandler(this.cmdRegister_Click);
            // 
            // lnk_formLogin
            // 
            this.lnk_formLogin.AutoSize = true;
            this.lnk_formLogin.Location = new System.Drawing.Point(12, 224);
            this.lnk_formLogin.Name = "lnk_formLogin";
            this.lnk_formLogin.Size = new System.Drawing.Size(33, 13);
            this.lnk_formLogin.TabIndex = 5;
            this.lnk_formLogin.TabStop = true;
            this.lnk_formLogin.Text = "Login";
            this.lnk_formLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_formLogin_LinkClicked);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(80, 9);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(87, 13);
            this.lbl_info.TabIndex = 6;
            this.lbl_info.Text = "Enter Credentials";
            // 
            // cmbo_Secret_Questions
            // 
            this.cmbo_Secret_Questions.FormattingEnabled = true;
            this.cmbo_Secret_Questions.Items.AddRange(new object[] {
            "What is your favourite game name?",
            "What is your favourite sport?",
            "What is your father name?"});
            this.cmbo_Secret_Questions.Location = new System.Drawing.Point(101, 85);
            this.cmbo_Secret_Questions.Name = "cmbo_Secret_Questions";
            this.cmbo_Secret_Questions.Size = new System.Drawing.Size(171, 21);
            this.cmbo_Secret_Questions.TabIndex = 7;
            // 
            // lbl_SecretQuestion
            // 
            this.lbl_SecretQuestion.AutoSize = true;
            this.lbl_SecretQuestion.Location = new System.Drawing.Point(12, 93);
            this.lbl_SecretQuestion.Name = "lbl_SecretQuestion";
            this.lbl_SecretQuestion.Size = new System.Drawing.Size(83, 13);
            this.lbl_SecretQuestion.TabIndex = 8;
            this.lbl_SecretQuestion.Text = "Secret Question";
            // 
            // lbl_Answer
            // 
            this.lbl_Answer.AutoSize = true;
            this.lbl_Answer.Location = new System.Drawing.Point(15, 132);
            this.lbl_Answer.Name = "lbl_Answer";
            this.lbl_Answer.Size = new System.Drawing.Size(42, 13);
            this.lbl_Answer.TabIndex = 9;
            this.lbl_Answer.Text = "Answer";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 125);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            // 
            // formRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_Answer);
            this.Controls.Add(this.lbl_SecretQuestion);
            this.Controls.Add(this.cmbo_Secret_Questions);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lnk_formLogin);
            this.Controls.Add(this.cmdRegister);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_UserName);
            this.Name = "formRegistration";
            this.Text = "FormRegistration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button cmdRegister;
        private System.Windows.Forms.LinkLabel lnk_formLogin;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.ComboBox cmbo_Secret_Questions;
        private System.Windows.Forms.Label lbl_SecretQuestion;
        private System.Windows.Forms.Label lbl_Answer;
        private System.Windows.Forms.TextBox textBox1;
    }
}