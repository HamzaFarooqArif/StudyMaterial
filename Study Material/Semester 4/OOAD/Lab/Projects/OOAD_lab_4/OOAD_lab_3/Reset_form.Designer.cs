namespace OOAD_lab_3
{
    partial class Reset_form
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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Secret_Question = new System.Windows.Forms.Label();
            this.lbl_Answer = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Answer = new System.Windows.Forms.TextBox();
            this.cmbo_Secret_Questions = new System.Windows.Forms.ComboBox();
            this.lnk_login_form = new System.Windows.Forms.LinkLabel();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(22, 13);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_Secret_Question
            // 
            this.lbl_Secret_Question.AutoSize = true;
            this.lbl_Secret_Question.Location = new System.Drawing.Point(22, 43);
            this.lbl_Secret_Question.Name = "lbl_Secret_Question";
            this.lbl_Secret_Question.Size = new System.Drawing.Size(83, 13);
            this.lbl_Secret_Question.TabIndex = 1;
            this.lbl_Secret_Question.Text = "Secret Question";
            // 
            // lbl_Answer
            // 
            this.lbl_Answer.AutoSize = true;
            this.lbl_Answer.Location = new System.Drawing.Point(22, 73);
            this.lbl_Answer.Name = "lbl_Answer";
            this.lbl_Answer.Size = new System.Drawing.Size(42, 13);
            this.lbl_Answer.TabIndex = 2;
            this.lbl_Answer.Text = "Answer";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(172, 13);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(100, 20);
            this.txt_Name.TabIndex = 3;
            // 
            // txt_Answer
            // 
            this.txt_Answer.Location = new System.Drawing.Point(172, 73);
            this.txt_Answer.Name = "txt_Answer";
            this.txt_Answer.Size = new System.Drawing.Size(100, 20);
            this.txt_Answer.TabIndex = 5;
            // 
            // cmbo_Secret_Questions
            // 
            this.cmbo_Secret_Questions.FormattingEnabled = true;
            this.cmbo_Secret_Questions.Items.AddRange(new object[] {
            "What is your favourite game name?",
            "What is your favourite sport?",
            "What is your father name?",
            ""});
            this.cmbo_Secret_Questions.Location = new System.Drawing.Point(172, 43);
            this.cmbo_Secret_Questions.Name = "cmbo_Secret_Questions";
            this.cmbo_Secret_Questions.Size = new System.Drawing.Size(121, 21);
            this.cmbo_Secret_Questions.TabIndex = 6;
            // 
            // lnk_login_form
            // 
            this.lnk_login_form.AutoSize = true;
            this.lnk_login_form.Location = new System.Drawing.Point(239, 223);
            this.lnk_login_form.Name = "lnk_login_form";
            this.lnk_login_form.Size = new System.Drawing.Size(33, 13);
            this.lnk_login_form.TabIndex = 7;
            this.lnk_login_form.TabStop = true;
            this.lnk_login_form.Text = "Login";
            this.lnk_login_form.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_login_form_LinkClicked);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(30, 223);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset.TabIndex = 8;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(109, 156);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(87, 13);
            this.lbl_info.TabIndex = 9;
            this.lbl_info.Text = "Enter Credentials";
            // 
            // Reset_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 261);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.lnk_login_form);
            this.Controls.Add(this.cmbo_Secret_Questions);
            this.Controls.Add(this.txt_Answer);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Answer);
            this.Controls.Add(this.lbl_Secret_Question);
            this.Controls.Add(this.lbl_Name);
            this.Name = "Reset_form";
            this.Text = "Reset_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Secret_Question;
        private System.Windows.Forms.Label lbl_Answer;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Answer;
        private System.Windows.Forms.ComboBox cmbo_Secret_Questions;
        private System.Windows.Forms.LinkLabel lnk_login_form;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lbl_info;
    }
}