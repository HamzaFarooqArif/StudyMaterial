namespace WindowsFormsApplication11
{
    partial class LoginAdmin
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
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lnklbl_SignUp = new System.Windows.Forms.LinkLabel();
            this.lnklbl_GoToMainPage = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(188, 175);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(100, 22);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(188, 43);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(100, 20);
            this.txt_Email.TabIndex = 1;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(188, 105);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(100, 20);
            this.txt_Password.TabIndex = 2;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(41, 46);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 3;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(41, 108);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 4;
            this.lbl_Password.Text = "Password";
            // 
            // lnklbl_SignUp
            // 
            this.lnklbl_SignUp.AutoSize = true;
            this.lnklbl_SignUp.Location = new System.Drawing.Point(41, 180);
            this.lnklbl_SignUp.Name = "lnklbl_SignUp";
            this.lnklbl_SignUp.Size = new System.Drawing.Size(42, 13);
            this.lnklbl_SignUp.TabIndex = 5;
            this.lnklbl_SignUp.TabStop = true;
            this.lnklbl_SignUp.Text = "SignUp";
            this.lnklbl_SignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_SignUp_LinkClicked);
            // 
            // lnklbl_GoToMainPage
            // 
            this.lnklbl_GoToMainPage.AutoSize = true;
            this.lnklbl_GoToMainPage.Location = new System.Drawing.Point(108, 220);
            this.lnklbl_GoToMainPage.Name = "lnklbl_GoToMainPage";
            this.lnklbl_GoToMainPage.Size = new System.Drawing.Size(91, 13);
            this.lnklbl_GoToMainPage.TabIndex = 6;
            this.lnklbl_GoToMainPage.TabStop = true;
            this.lnklbl_GoToMainPage.Text = "Go To Main Page";
            this.lnklbl_GoToMainPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_GoToMainPage_LinkClicked);
            // 
            // LoginAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 267);
            this.Controls.Add(this.lnklbl_GoToMainPage);
            this.Controls.Add(this.lnklbl_SignUp);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.btn_Login);
            this.Name = "LoginAdmin";
            this.Text = "LoginAdmin";
            this.Load += new System.EventHandler(this.LoginAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.LinkLabel lnklbl_SignUp;
        private System.Windows.Forms.LinkLabel lnklbl_GoToMainPage;
    }
}