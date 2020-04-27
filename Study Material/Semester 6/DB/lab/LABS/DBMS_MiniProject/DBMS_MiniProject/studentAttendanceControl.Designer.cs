namespace DBMS_MiniProject
{
    partial class studentAttendanceControl
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
            this.lbl_Registration = new System.Windows.Forms.Label();
            this.cb_Lookup = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_Registration
            // 
            this.lbl_Registration.AutoSize = true;
            this.lbl_Registration.Location = new System.Drawing.Point(3, 6);
            this.lbl_Registration.Name = "lbl_Registration";
            this.lbl_Registration.Size = new System.Drawing.Size(103, 13);
            this.lbl_Registration.TabIndex = 0;
            this.lbl_Registration.Text = "Registration Number";
            // 
            // cb_Lookup
            // 
            this.cb_Lookup.FormattingEnabled = true;
            this.cb_Lookup.Location = new System.Drawing.Point(124, 3);
            this.cb_Lookup.Name = "cb_Lookup";
            this.cb_Lookup.Size = new System.Drawing.Size(121, 21);
            this.cb_Lookup.TabIndex = 1;
            // 
            // studentAttendanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_Lookup);
            this.Controls.Add(this.lbl_Registration);
            this.Name = "studentAttendanceControl";
            this.Size = new System.Drawing.Size(250, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Registration;
        private System.Windows.Forms.ComboBox cb_Lookup;
    }
}
