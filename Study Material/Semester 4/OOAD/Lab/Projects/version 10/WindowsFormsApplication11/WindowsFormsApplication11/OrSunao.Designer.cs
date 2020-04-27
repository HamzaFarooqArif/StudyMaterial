namespace WindowsFormsApplication11
{
    partial class OrSunao
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
            this.registeradmin = new System.Windows.Forms.LinkLabel();
            this.registeruser = new System.Windows.Forms.LinkLabel();
            this.loginadmin = new System.Windows.Forms.LinkLabel();
            this.loginuser = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // registeradmin
            // 
            this.registeradmin.AutoSize = true;
            this.registeradmin.Location = new System.Drawing.Point(46, 204);
            this.registeradmin.Name = "registeradmin";
            this.registeradmin.Size = new System.Drawing.Size(110, 13);
            this.registeradmin.TabIndex = 0;
            this.registeradmin.TabStop = true;
            this.registeradmin.Text = "Register as an  Admin";
            this.registeradmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registeradmin_LinkClicked);
            // 
            // registeruser
            // 
            this.registeruser.AutoSize = true;
            this.registeruser.Location = new System.Drawing.Point(273, 204);
            this.registeruser.Name = "registeruser";
            this.registeruser.Size = new System.Drawing.Size(94, 13);
            this.registeruser.TabIndex = 1;
            this.registeruser.TabStop = true;
            this.registeruser.Text = "Register as a User";
            this.registeruser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registeruser_LinkClicked);
            // 
            // loginadmin
            // 
            this.loginadmin.AutoSize = true;
            this.loginadmin.Location = new System.Drawing.Point(46, 262);
            this.loginadmin.Name = "loginadmin";
            this.loginadmin.Size = new System.Drawing.Size(97, 13);
            this.loginadmin.TabIndex = 2;
            this.loginadmin.TabStop = true;
            this.loginadmin.Text = "Log in as an Admin";
            this.loginadmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loginadmin_LinkClicked);
            // 
            // loginuser
            // 
            this.loginuser.AutoSize = true;
            this.loginuser.Location = new System.Drawing.Point(273, 262);
            this.loginuser.Name = "loginuser";
            this.loginuser.Size = new System.Drawing.Size(84, 13);
            this.loginuser.TabIndex = 3;
            this.loginuser.TabStop = true;
            this.loginuser.Text = "Log in as a User";
            this.loginuser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loginuser_LinkClicked);
            // 
            // OrSunao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication11.Properties.Resources.t1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(422, 299);
            this.Controls.Add(this.loginuser);
            this.Controls.Add(this.loginadmin);
            this.Controls.Add(this.registeruser);
            this.Controls.Add(this.registeradmin);
            this.Name = "OrSunao";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OrSunao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel registeradmin;
        private System.Windows.Forms.LinkLabel registeruser;
        private System.Windows.Forms.LinkLabel loginadmin;
        private System.Windows.Forms.LinkLabel loginuser;
    }
}

