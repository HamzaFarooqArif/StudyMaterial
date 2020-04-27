namespace WindowsFormsApplication11
{
    partial class chatbox
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
            this.lbl_me = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_connecteduser = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_sendimage = new System.Windows.Forms.Button();
            this.opendirectory = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lbl_me
            // 
            this.lbl_me.AutoSize = true;
            this.lbl_me.Location = new System.Drawing.Point(12, 18);
            this.lbl_me.Name = "lbl_me";
            this.lbl_me.Size = new System.Drawing.Size(0, 13);
            this.lbl_me.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Connected User:";
            // 
            // lbl_connecteduser
            // 
            this.lbl_connecteduser.AutoSize = true;
            this.lbl_connecteduser.Location = new System.Drawing.Point(341, 18);
            this.lbl_connecteduser.Name = "lbl_connecteduser";
            this.lbl_connecteduser.Size = new System.Drawing.Size(0, 13);
            this.lbl_connecteduser.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(396, 312);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(28, 368);
            this.txt_message.Multiline = true;
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(304, 48);
            this.txt_message.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(338, 366);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(148, 12);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(67, 12);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 7;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_sendimage
            // 
            this.btn_sendimage.Location = new System.Drawing.Point(338, 393);
            this.btn_sendimage.Name = "btn_sendimage";
            this.btn_sendimage.Size = new System.Drawing.Size(75, 23);
            this.btn_sendimage.TabIndex = 8;
            this.btn_sendimage.Text = "Send Image";
            this.btn_sendimage.UseVisualStyleBackColor = true;
            this.btn_sendimage.Click += new System.EventHandler(this.btn_sendimage_Click);
            // 
            // opendirectory
            // 
            this.opendirectory.FileName = "openFileDialog1";
            this.opendirectory.FileOk += new System.ComponentModel.CancelEventHandler(this.opendirectory_FileOk);
            // 
            // chatbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 428);
            this.Controls.Add(this.btn_sendimage);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbl_connecteduser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_me);
            this.Name = "chatbox";
            this.Text = "chatbox";
            this.Load += new System.EventHandler(this.chatbox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_me;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_connecteduser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_sendimage;
        private System.Windows.Forms.OpenFileDialog opendirectory;
    }
}