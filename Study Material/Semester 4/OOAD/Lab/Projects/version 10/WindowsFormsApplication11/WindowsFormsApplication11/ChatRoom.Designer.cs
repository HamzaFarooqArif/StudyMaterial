namespace WindowsFormsApplication11
{
    partial class ChatRoom
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
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl1_Email = new System.Windows.Forms.Label();
            this.lbl2_Email = new System.Windows.Forms.Label();
            this.lbl3_Email = new System.Windows.Forms.Label();
            this.lbl4_Email = new System.Windows.Forms.Label();
            this.btn_AddUsers = new System.Windows.Forms.Button();
            this.lbl_me = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Message
            // 
            this.txt_Message.Location = new System.Drawing.Point(10, 367);
            this.txt_Message.Multiline = true;
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.Size = new System.Drawing.Size(297, 34);
            this.txt_Message.TabIndex = 0;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(348, 367);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(348, 12);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(255, 12);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 2;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 99);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(294, 257);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // lbl1_Email
            // 
            this.lbl1_Email.AutoSize = true;
            this.lbl1_Email.Location = new System.Drawing.Point(26, 37);
            this.lbl1_Email.Name = "lbl1_Email";
            this.lbl1_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl1_Email.TabIndex = 0;
            this.lbl1_Email.Text = "Email";
            // 
            // lbl2_Email
            // 
            this.lbl2_Email.AutoSize = true;
            this.lbl2_Email.Location = new System.Drawing.Point(26, 52);
            this.lbl2_Email.Name = "lbl2_Email";
            this.lbl2_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl2_Email.TabIndex = 6;
            this.lbl2_Email.Text = "Email";
            // 
            // lbl3_Email
            // 
            this.lbl3_Email.AutoSize = true;
            this.lbl3_Email.Location = new System.Drawing.Point(26, 68);
            this.lbl3_Email.Name = "lbl3_Email";
            this.lbl3_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl3_Email.TabIndex = 7;
            this.lbl3_Email.Text = "Email";
            // 
            // lbl4_Email
            // 
            this.lbl4_Email.AutoSize = true;
            this.lbl4_Email.Location = new System.Drawing.Point(26, 83);
            this.lbl4_Email.Name = "lbl4_Email";
            this.lbl4_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl4_Email.TabIndex = 8;
            this.lbl4_Email.Text = "Email";
            // 
            // btn_AddUsers
            // 
            this.btn_AddUsers.Location = new System.Drawing.Point(174, 12);
            this.btn_AddUsers.Name = "btn_AddUsers";
            this.btn_AddUsers.Size = new System.Drawing.Size(75, 23);
            this.btn_AddUsers.TabIndex = 9;
            this.btn_AddUsers.Text = "Add Users";
            this.btn_AddUsers.UseVisualStyleBackColor = true;
            this.btn_AddUsers.Click += new System.EventHandler(this.btn_AddUsers_Click);
            // 
            // lbl_me
            // 
            this.lbl_me.AutoSize = true;
            this.lbl_me.Location = new System.Drawing.Point(27, 13);
            this.lbl_me.Name = "lbl_me";
            this.lbl_me.Size = new System.Drawing.Size(49, 13);
            this.lbl_me.TabIndex = 10;
            this.lbl_me.Text = "My Email";
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 413);
            this.Controls.Add(this.lbl_me);
            this.Controls.Add(this.btn_AddUsers);
            this.Controls.Add(this.lbl4_Email);
            this.Controls.Add(this.lbl3_Email);
            this.Controls.Add(this.lbl2_Email);
            this.Controls.Add(this.lbl1_Email);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Message);
            this.Name = "ChatRoom";
            this.Text = "ChatRoom";
            this.Load += new System.EventHandler(this.ChatRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbl1_Email;
        private System.Windows.Forms.Label lbl2_Email;
        private System.Windows.Forms.Label lbl3_Email;
        private System.Windows.Forms.Label lbl4_Email;
        private System.Windows.Forms.Button btn_AddUsers;
        private System.Windows.Forms.Label lbl_me;
    }
}