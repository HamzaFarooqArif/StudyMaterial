namespace WindowsFormsApplication11
{
    partial class RegisterUser
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
            this.btn_Register = new System.Windows.Forms.Button();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_CNIC = new System.Windows.Forms.Label();
            this.lbl_Contact = new System.Windows.Forms.Label();
            this.lbl_SecretQuestion = new System.Windows.Forms.Label();
            this.lbl_SecretAnswqer = new System.Windows.Forms.Label();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_CNIC = new System.Windows.Forms.TextBox();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.txt_SecretAnswer = new System.Windows.Forms.TextBox();
            this.lnklbl_Login = new System.Windows.Forms.LinkLabel();
            this.lnklbl_GoToMainPage = new System.Windows.Forms.LinkLabel();
            this.txt_SecretQuestion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Register
            // 
            this.btn_Register.Location = new System.Drawing.Point(277, 235);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(75, 23);
            this.btn_Register.TabIndex = 0;
            this.btn_Register.Text = "Register";
            this.btn_Register.UseVisualStyleBackColor = true;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.AutoSize = true;
            this.lbl_FirstName.Location = new System.Drawing.Point(20, 19);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_FirstName.TabIndex = 1;
            this.lbl_FirstName.Text = "First Name";
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Location = new System.Drawing.Point(23, 45);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_LastName.TabIndex = 2;
            this.lbl_LastName.Text = "Last Name";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(24, 71);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 3;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(24, 97);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 4;
            this.lbl_Password.Text = "Password";
            // 
            // lbl_CNIC
            // 
            this.lbl_CNIC.AutoSize = true;
            this.lbl_CNIC.Location = new System.Drawing.Point(24, 123);
            this.lbl_CNIC.Name = "lbl_CNIC";
            this.lbl_CNIC.Size = new System.Drawing.Size(32, 13);
            this.lbl_CNIC.TabIndex = 5;
            this.lbl_CNIC.Text = "CNIC";
            // 
            // lbl_Contact
            // 
            this.lbl_Contact.AutoSize = true;
            this.lbl_Contact.Location = new System.Drawing.Point(20, 149);
            this.lbl_Contact.Name = "lbl_Contact";
            this.lbl_Contact.Size = new System.Drawing.Size(44, 13);
            this.lbl_Contact.TabIndex = 6;
            this.lbl_Contact.Text = "Contact";
            // 
            // lbl_SecretQuestion
            // 
            this.lbl_SecretQuestion.AutoSize = true;
            this.lbl_SecretQuestion.Location = new System.Drawing.Point(17, 175);
            this.lbl_SecretQuestion.Name = "lbl_SecretQuestion";
            this.lbl_SecretQuestion.Size = new System.Drawing.Size(83, 13);
            this.lbl_SecretQuestion.TabIndex = 7;
            this.lbl_SecretQuestion.Text = "Secret Question";
            // 
            // lbl_SecretAnswqer
            // 
            this.lbl_SecretAnswqer.AutoSize = true;
            this.lbl_SecretAnswqer.Location = new System.Drawing.Point(20, 203);
            this.lbl_SecretAnswqer.Name = "lbl_SecretAnswqer";
            this.lbl_SecretAnswqer.Size = new System.Drawing.Size(76, 13);
            this.lbl_SecretAnswqer.TabIndex = 8;
            this.lbl_SecretAnswqer.Text = "Secret Answer";
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.Location = new System.Drawing.Point(198, 16);
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.Size = new System.Drawing.Size(118, 20);
            this.txt_FirstName.TabIndex = 9;
            // 
            // txt_LastName
            // 
            this.txt_LastName.Location = new System.Drawing.Point(198, 42);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(118, 20);
            this.txt_LastName.TabIndex = 10;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(198, 68);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(118, 20);
            this.txt_Email.TabIndex = 11;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(198, 94);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(118, 20);
            this.txt_Password.TabIndex = 12;
            // 
            // txt_CNIC
            // 
            this.txt_CNIC.Location = new System.Drawing.Point(198, 120);
            this.txt_CNIC.Name = "txt_CNIC";
            this.txt_CNIC.Size = new System.Drawing.Size(118, 20);
            this.txt_CNIC.TabIndex = 13;
            // 
            // txt_Contact
            // 
            this.txt_Contact.Location = new System.Drawing.Point(198, 146);
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.Size = new System.Drawing.Size(118, 20);
            this.txt_Contact.TabIndex = 14;
            // 
            // txt_SecretAnswer
            // 
            this.txt_SecretAnswer.Location = new System.Drawing.Point(198, 200);
            this.txt_SecretAnswer.Name = "txt_SecretAnswer";
            this.txt_SecretAnswer.Size = new System.Drawing.Size(118, 20);
            this.txt_SecretAnswer.TabIndex = 16;
            // 
            // lnklbl_Login
            // 
            this.lnklbl_Login.AutoSize = true;
            this.lnklbl_Login.Location = new System.Drawing.Point(33, 235);
            this.lnklbl_Login.Name = "lnklbl_Login";
            this.lnklbl_Login.Size = new System.Drawing.Size(33, 13);
            this.lnklbl_Login.TabIndex = 17;
            this.lnklbl_Login.TabStop = true;
            this.lnklbl_Login.Text = "Login";
            this.lnklbl_Login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_Login_LinkClicked);
            // 
            // lnklbl_GoToMainPage
            // 
            this.lnklbl_GoToMainPage.AutoSize = true;
            this.lnklbl_GoToMainPage.Location = new System.Drawing.Point(131, 248);
            this.lnklbl_GoToMainPage.Name = "lnklbl_GoToMainPage";
            this.lnklbl_GoToMainPage.Size = new System.Drawing.Size(91, 13);
            this.lnklbl_GoToMainPage.TabIndex = 18;
            this.lnklbl_GoToMainPage.TabStop = true;
            this.lnklbl_GoToMainPage.Text = "Go To Main Page";
            this.lnklbl_GoToMainPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_GoToMainPage_LinkClicked);
            // 
            // txt_SecretQuestion
            // 
            this.txt_SecretQuestion.FormattingEnabled = true;
            this.txt_SecretQuestion.Items.AddRange(new object[] {
            "Childhoods best friend name ?",
            "Your Favourite teacher name?",
            "Your favourite food name ?",
            "Your favourite place name?"});
            this.txt_SecretQuestion.Location = new System.Drawing.Point(198, 175);
            this.txt_SecretQuestion.Name = "txt_SecretQuestion";
            this.txt_SecretQuestion.Size = new System.Drawing.Size(118, 21);
            this.txt_SecretQuestion.TabIndex = 19;
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 270);
            this.Controls.Add(this.txt_SecretQuestion);
            this.Controls.Add(this.lnklbl_GoToMainPage);
            this.Controls.Add(this.lnklbl_Login);
            this.Controls.Add(this.txt_SecretAnswer);
            this.Controls.Add(this.txt_Contact);
            this.Controls.Add(this.txt_CNIC);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_LastName);
            this.Controls.Add(this.txt_FirstName);
            this.Controls.Add(this.lbl_SecretAnswqer);
            this.Controls.Add(this.lbl_SecretQuestion);
            this.Controls.Add(this.lbl_Contact);
            this.Controls.Add(this.lbl_CNIC);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_LastName);
            this.Controls.Add(this.lbl_FirstName);
            this.Controls.Add(this.btn_Register);
            this.Name = "RegisterUser";
            this.Text = "RegisterUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_CNIC;
        private System.Windows.Forms.Label lbl_Contact;
        private System.Windows.Forms.Label lbl_SecretQuestion;
        private System.Windows.Forms.Label lbl_SecretAnswqer;
        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_CNIC;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.TextBox txt_SecretAnswer;
        private System.Windows.Forms.LinkLabel lnklbl_Login;
        private System.Windows.Forms.LinkLabel lnklbl_GoToMainPage;
        private System.Windows.Forms.ComboBox txt_SecretQuestion;
    }
}