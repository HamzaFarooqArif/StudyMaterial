namespace WindowsFormsApplication11
{
    partial class UserControl4
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_User = new System.Windows.Forms.PictureBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.btn_Block = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_User)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_User
            // 
            this.pb_User.Location = new System.Drawing.Point(3, 3);
            this.pb_User.Name = "pb_User";
            this.pb_User.Size = new System.Drawing.Size(75, 61);
            this.pb_User.TabIndex = 0;
            this.pb_User.TabStop = false;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(14, 122);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(55, 21);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(22, 79);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 2;
            this.lbl_Email.Text = "Email";
            // 
            // btn_Block
            // 
            this.btn_Block.Location = new System.Drawing.Point(14, 95);
            this.btn_Block.Name = "btn_Block";
            this.btn_Block.Size = new System.Drawing.Size(60, 21);
            this.btn_Block.TabIndex = 3;
            this.btn_Block.Text = "Block";
            this.btn_Block.UseVisualStyleBackColor = true;
            this.btn_Block.Click += new System.EventHandler(this.btn_Block_Click);
            // 
            // UserControl4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Block);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.pb_User);
            this.Name = "UserControl4";
            this.Size = new System.Drawing.Size(94, 148);
            this.Load += new System.EventHandler(this.UserControl4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_User)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_User;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Button btn_Block;
    }
}
