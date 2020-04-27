namespace WindowsFormsApplication11
{
    partial class UsersForGroupChat
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_EnterUser = new System.Windows.Forms.LinkLabel();
            this.btn_StartGroupChat = new System.Windows.Forms.Button();
            this.lbl_me = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 181);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbl_EnterUser
            // 
            this.lbl_EnterUser.AutoSize = true;
            this.lbl_EnterUser.Location = new System.Drawing.Point(29, 225);
            this.lbl_EnterUser.Name = "lbl_EnterUser";
            this.lbl_EnterUser.Size = new System.Drawing.Size(32, 13);
            this.lbl_EnterUser.TabIndex = 1;
            this.lbl_EnterUser.TabStop = true;
            this.lbl_EnterUser.Text = "Back";
            this.lbl_EnterUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_EnterUser_LinkClicked);
            // 
            // btn_StartGroupChat
            // 
            this.btn_StartGroupChat.Location = new System.Drawing.Point(134, 221);
            this.btn_StartGroupChat.Name = "btn_StartGroupChat";
            this.btn_StartGroupChat.Size = new System.Drawing.Size(121, 27);
            this.btn_StartGroupChat.TabIndex = 2;
            this.btn_StartGroupChat.Text = "Start Group Chat";
            this.btn_StartGroupChat.UseVisualStyleBackColor = true;
            this.btn_StartGroupChat.Click += new System.EventHandler(this.btn_StartGroupChat_Click);
            // 
            // lbl_me
            // 
            this.lbl_me.AutoSize = true;
            this.lbl_me.Location = new System.Drawing.Point(12, 9);
            this.lbl_me.Name = "lbl_me";
            this.lbl_me.Size = new System.Drawing.Size(49, 13);
            this.lbl_me.TabIndex = 3;
            this.lbl_me.Text = "My Email";
            // 
            // UsersForGroupChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbl_me);
            this.Controls.Add(this.btn_StartGroupChat);
            this.Controls.Add(this.lbl_EnterUser);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UsersForGroupChat";
            this.Text = "UsersForGroupChat";
            this.Load += new System.EventHandler(this.UsersForGroupChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel lbl_EnterUser;
        private System.Windows.Forms.Button btn_StartGroupChat;
        private System.Windows.Forms.Label lbl_me;
    }
}