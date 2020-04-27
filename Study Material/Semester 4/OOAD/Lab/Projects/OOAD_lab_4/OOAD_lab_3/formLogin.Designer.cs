namespace OOAD_lab_3
{
    partial class formLogin
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
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.lnk_formRegistration = new System.Windows.Forms.LinkLabel();
            this.lbl_info = new System.Windows.Forms.Label();
            this.lnk_Forgot_Password = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(172, 32);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(100, 20);
            this.txt_UserName.TabIndex = 0;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(172, 67);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(100, 20);
            this.txt_Password.TabIndex = 1;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(10, 39);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(83, 13);
            this.lbl_username.TabIndex = 2;
            this.lbl_username.Text = "Enter Username";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(10, 67);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(81, 13);
            this.lbl_password.TabIndex = 3;
            this.lbl_password.Text = "Enter Password";
            // 
            // cmdLogin
            // 
            this.cmdLogin.Location = new System.Drawing.Point(187, 226);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(75, 23);
            this.cmdLogin.TabIndex = 4;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // lnk_formRegistration
            // 
            this.lnk_formRegistration.AutoSize = true;
            this.lnk_formRegistration.Location = new System.Drawing.Point(13, 127);
            this.lnk_formRegistration.Name = "lnk_formRegistration";
            this.lnk_formRegistration.Size = new System.Drawing.Size(45, 13);
            this.lnk_formRegistration.TabIndex = 5;
            this.lnk_formRegistration.TabStop = true;
            this.lnk_formRegistration.Text = "Sign Up";
            this.lnk_formRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_formRegistration_LinkClicked);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(79, 7);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(87, 13);
            this.lbl_info.TabIndex = 6;
            this.lbl_info.Text = "Enter Credentials";
            // 
            // lnk_Forgot_Password
            // 
            this.lnk_Forgot_Password.AutoSize = true;
            this.lnk_Forgot_Password.Location = new System.Drawing.Point(13, 236);
            this.lnk_Forgot_Password.Name = "lnk_Forgot_Password";
            this.lnk_Forgot_Password.Size = new System.Drawing.Size(86, 13);
            this.lnk_Forgot_Password.TabIndex = 7;
            this.lnk_Forgot_Password.TabStop = true;
            this.lnk_Forgot_Password.Text = "Forgot Password";
            this.lnk_Forgot_Password.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Forgot_Password_LinkClicked);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lnk_Forgot_Password);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lnk_formRegistration);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_UserName);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "formLogin";
            this.Text = "formLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.LinkLabel lnk_formRegistration;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.LinkLabel lnk_Forgot_Password;
    }
}