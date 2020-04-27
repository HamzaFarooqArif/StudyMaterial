using System;

namespace WindowsFormsApplication11
{
    partial class EnterUser
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
            this.lbl_login = new System.Windows.Forms.LinkLabel();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_Deactivate = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_GroupChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(31, 43);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(296, 235);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(12, 295);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(37, 13);
            this.lbl_login.TabIndex = 0;
            this.lbl_login.TabStop = true;
            this.lbl_login.Text = "Log In";
            this.lbl_login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_login_LinkClicked);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(30, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(33, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "name";
            this.lbl_name.Click += new System.EventHandler(this.lbl_name_Click);
            // 
            // btn_Deactivate
            // 
            this.btn_Deactivate.Location = new System.Drawing.Point(252, 295);
            this.btn_Deactivate.Name = "btn_Deactivate";
            this.btn_Deactivate.Size = new System.Drawing.Size(75, 23);
            this.btn_Deactivate.TabIndex = 1;
            this.btn_Deactivate.Text = "Deactivate";
            this.btn_Deactivate.UseVisualStyleBackColor = true;
            this.btn_Deactivate.Click += new System.EventHandler(this.btn_Deactivate_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(156, 295);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 2;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_GroupChat
            // 
            this.btn_GroupChat.Location = new System.Drawing.Point(65, 295);
            this.btn_GroupChat.Name = "btn_GroupChat";
            this.btn_GroupChat.Size = new System.Drawing.Size(75, 23);
            this.btn_GroupChat.TabIndex = 3;
            this.btn_GroupChat.Text = "Group Chat";
            this.btn_GroupChat.UseVisualStyleBackColor = true;
            this.btn_GroupChat.Click += new System.EventHandler(this.btn_GroupChat_Click);
            // 
            // EnterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 326);
            this.Controls.Add(this.btn_GroupChat);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Deactivate);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "EnterUser";
            this.Text = "EnterUser";
            this.Load += new System.EventHandler(this.EnterUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lbl_name_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel lbl_login;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_Deactivate;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_GroupChat;
    }
}