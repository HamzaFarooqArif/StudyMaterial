namespace WindowsFormsApplication11
{
    partial class RegisterAdmin
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
            this.Txt_FirstName = new System.Windows.Forms.TextBox();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.lnklbl_Login = new System.Windows.Forms.LinkLabel();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.btn_Register = new System.Windows.Forms.Button();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_CNIC = new System.Windows.Forms.TextBox();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_CNIC = new System.Windows.Forms.Label();
            this.lbl_Contact = new System.Windows.Forms.Label();
            this.lnklbl_GoToMainPage = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Txt_FirstName
            // 
            this.Txt_FirstName.Location = new System.Drawing.Point(190, 41);
            this.Txt_FirstName.Name = "Txt_FirstName";
            this.Txt_FirstName.Size = new System.Drawing.Size(100, 20);
            this.Txt_FirstName.TabIndex = 0;
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(190, 96);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(100, 20);
            this.Txt_Password.TabIndex = 1;
            // 
            // lnklbl_Login
            // 
            this.lnklbl_Login.AutoSize = true;
            this.lnklbl_Login.Location = new System.Drawing.Point(46, 202);
            this.lnklbl_Login.Name = "lnklbl_Login";
            this.lnklbl_Login.Size = new System.Drawing.Size(33, 13);
            this.lnklbl_Login.TabIndex = 3;
            this.lnklbl_Login.TabStop = true;
            this.lnklbl_Login.Text = "Login";
            this.lnklbl_Login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_Login_LinkClicked);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Location = new System.Drawing.Point(46, 48);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(57, 13);
            this.lbl_UserName.TabIndex = 4;
            this.lbl_UserName.Text = "First Name";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(46, 103);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 5;
            this.lbl_Password.Text = "Password";
            // 
            // btn_Register
            // 
            this.btn_Register.Location = new System.Drawing.Point(190, 202);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(100, 23);
            this.btn_Register.TabIndex = 6;
            this.btn_Register.Text = "Register";
            this.btn_Register.UseVisualStyleBackColor = true;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // txt_LastName
            // 
            this.txt_LastName.Location = new System.Drawing.Point(190, 70);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(100, 20);
            this.txt_LastName.TabIndex = 7;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(190, 122);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(100, 20);
            this.txt_Email.TabIndex = 8;
            // 
            // txt_CNIC
            // 
            this.txt_CNIC.Location = new System.Drawing.Point(190, 148);
            this.txt_CNIC.Name = "txt_CNIC";
            this.txt_CNIC.Size = new System.Drawing.Size(100, 20);
            this.txt_CNIC.TabIndex = 9;
            // 
            // txt_Contact
            // 
            this.txt_Contact.Location = new System.Drawing.Point(190, 174);
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.Size = new System.Drawing.Size(100, 20);
            this.txt_Contact.TabIndex = 10;
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Location = new System.Drawing.Point(48, 77);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(55, 13);
            this.lbl_LastName.TabIndex = 11;
            this.lbl_LastName.Text = "LastName";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(48, 125);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 12;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_CNIC
            // 
            this.lbl_CNIC.AutoSize = true;
            this.lbl_CNIC.Location = new System.Drawing.Point(48, 151);
            this.lbl_CNIC.Name = "lbl_CNIC";
            this.lbl_CNIC.Size = new System.Drawing.Size(32, 13);
            this.lbl_CNIC.TabIndex = 13;
            this.lbl_CNIC.Text = "CNIC";
            // 
            // lbl_Contact
            // 
            this.lbl_Contact.AutoSize = true;
            this.lbl_Contact.Location = new System.Drawing.Point(46, 177);
            this.lbl_Contact.Name = "lbl_Contact";
            this.lbl_Contact.Size = new System.Drawing.Size(44, 13);
            this.lbl_Contact.TabIndex = 14;
            this.lbl_Contact.Text = "Contact";
            // 
            // lnklbl_GoToMainPage
            // 
            this.lnklbl_GoToMainPage.AutoSize = true;
            this.lnklbl_GoToMainPage.Location = new System.Drawing.Point(91, 249);
            this.lnklbl_GoToMainPage.Name = "lnklbl_GoToMainPage";
            this.lnklbl_GoToMainPage.Size = new System.Drawing.Size(91, 13);
            this.lnklbl_GoToMainPage.TabIndex = 15;
            this.lnklbl_GoToMainPage.TabStop = true;
            this.lnklbl_GoToMainPage.Text = "Go To Main Page";
            this.lnklbl_GoToMainPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_GoToMainPage_LinkClicked);
            // 
            // RegisterAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 291);
            this.Controls.Add(this.lnklbl_GoToMainPage);
            this.Controls.Add(this.lbl_Contact);
            this.Controls.Add(this.lbl_CNIC);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_LastName);
            this.Controls.Add(this.txt_Contact);
            this.Controls.Add(this.txt_CNIC);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_LastName);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_UserName);
            this.Controls.Add(this.lnklbl_Login);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.Txt_FirstName);
            this.Name = "RegisterAdmin";
            this.Text = "RegisterAdmin";
            this.Load += new System.EventHandler(this.RegisterAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_FirstName;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.LinkLabel lnklbl_Login;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_CNIC;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_CNIC;
        private System.Windows.Forms.Label lbl_Contact;
        private System.Windows.Forms.LinkLabel lnklbl_GoToMainPage;
    }
}