namespace WindowsFormsApplication11
{
    partial class LoginUser
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
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lnklbl_ForgetPassword = new System.Windows.Forms.LinkLabel();
            this.lnklbl_Register = new System.Windows.Forms.LinkLabel();
            this.lnklbl_GoToMainPage = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(199, 34);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(100, 20);
            this.txt_Email.TabIndex = 0;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(199, 81);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(100, 20);
            this.txt_Password.TabIndex = 1;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(47, 37);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 2;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(47, 84);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 3;
            this.lbl_Password.Text = "Password";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(224, 191);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lnklbl_ForgetPassword
            // 
            this.lnklbl_ForgetPassword.AutoSize = true;
            this.lnklbl_ForgetPassword.Location = new System.Drawing.Point(36, 161);
            this.lnklbl_ForgetPassword.Name = "lnklbl_ForgetPassword";
            this.lnklbl_ForgetPassword.Size = new System.Drawing.Size(86, 13);
            this.lnklbl_ForgetPassword.TabIndex = 5;
            this.lnklbl_ForgetPassword.TabStop = true;
            this.lnklbl_ForgetPassword.Text = "Forget Password";
            // 
            // lnklbl_Register
            // 
            this.lnklbl_Register.AutoSize = true;
            this.lnklbl_Register.Location = new System.Drawing.Point(36, 196);
            this.lnklbl_Register.Name = "lnklbl_Register";
            this.lnklbl_Register.Size = new System.Drawing.Size(46, 13);
            this.lnklbl_Register.TabIndex = 6;
            this.lnklbl_Register.TabStop = true;
            this.lnklbl_Register.Text = "Register";
            this.lnklbl_Register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_Register_LinkClicked);
            // 
            // lnklbl_GoToMainPage
            // 
            this.lnklbl_GoToMainPage.AutoSize = true;
            this.lnklbl_GoToMainPage.Location = new System.Drawing.Point(136, 241);
            this.lnklbl_GoToMainPage.Name = "lnklbl_GoToMainPage";
            this.lnklbl_GoToMainPage.Size = new System.Drawing.Size(91, 13);
            this.lnklbl_GoToMainPage.TabIndex = 7;
            this.lnklbl_GoToMainPage.TabStop = true;
            this.lnklbl_GoToMainPage.Text = "Go To Main Page";
            this.lnklbl_GoToMainPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_GoToMainPage_LinkClicked);
            // 
            // LoginUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 279);
            this.Controls.Add(this.lnklbl_GoToMainPage);
            this.Controls.Add(this.lnklbl_Register);
            this.Controls.Add(this.lnklbl_ForgetPassword);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Email);
            this.Name = "LoginUser";
            this.Text = "LoginUser";
            this.Load += new System.EventHandler(this.LoginUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.LinkLabel lnklbl_ForgetPassword;
        private System.Windows.Forms.LinkLabel lnklbl_Register;
        private System.Windows.Forms.LinkLabel lnklbl_GoToMainPage;
    }
}