namespace OOAD_lab_3
{
    partial class formShowProducts
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
            this.grdShowProducts = new System.Windows.Forms.DataGridView();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.lnkLoginForm = new System.Windows.Forms.LinkLabel();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShowProducts
            // 
            this.grdShowProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowProducts.Location = new System.Drawing.Point(12, 99);
            this.grdShowProducts.Name = "grdShowProducts";
            this.grdShowProducts.Size = new System.Drawing.Size(240, 150);
            this.grdShowProducts.TabIndex = 0;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(12, 12);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 1;
            this.btnShowAll.Text = "ShowAll";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Items.AddRange(new object[] {
            "Food",
            "Dress",
            "Sport",
            "Kids"});
            this.cmbCategories.Location = new System.Drawing.Point(142, 12);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(121, 21);
            this.cmbCategories.TabIndex = 2;
            // 
            // lnkLoginForm
            // 
            this.lnkLoginForm.AutoSize = true;
            this.lnkLoginForm.Location = new System.Drawing.Point(200, 60);
            this.lnkLoginForm.Name = "lnkLoginForm";
            this.lnkLoginForm.Size = new System.Drawing.Size(52, 13);
            this.lnkLoginForm.TabIndex = 3;
            this.lnkLoginForm.TabStop = true;
            this.lnkLoginForm.Text = "loginForm";
            this.lnkLoginForm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoginForm_LinkClicked);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // formShowProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lnkLoginForm);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.grdShowProducts);
            this.Name = "formShowProducts";
            this.Text = "formShowProducts";
            ((System.ComponentModel.ISupportInitialize)(this.grdShowProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdShowProducts;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.LinkLabel lnkLoginForm;
        private System.Windows.Forms.Button btnRefresh;
    }
}