namespace DBMS_MiniProject
{
    partial class Reports_Form
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
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_CLO = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Assessment = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.lbl_Validation1 = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Heading = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Browse
            // 
            this.btn_Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Browse.Location = new System.Drawing.Point(136, 5);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(123, 19);
            this.btn_Browse.TabIndex = 0;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_CLO
            // 
            this.btn_CLO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CLO.Location = new System.Drawing.Point(5, 59);
            this.btn_CLO.Name = "btn_CLO";
            this.btn_CLO.Size = new System.Drawing.Size(123, 22);
            this.btn_CLO.TabIndex = 1;
            this.btn_CLO.Text = "CLO Report";
            this.btn_CLO.UseVisualStyleBackColor = true;
            this.btn_CLO.Click += new System.EventHandler(this.btn_CLO_Click);
            // 
            // btn_Assessment
            // 
            this.btn_Assessment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Assessment.Location = new System.Drawing.Point(136, 59);
            this.btn_Assessment.Name = "btn_Assessment";
            this.btn_Assessment.Size = new System.Drawing.Size(123, 22);
            this.btn_Assessment.TabIndex = 2;
            this.btn_Assessment.Text = "Assessment Report";
            this.btn_Assessment.UseVisualStyleBackColor = true;
            this.btn_Assessment.Click += new System.EventHandler(this.btn_Assessment_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Path.Location = new System.Drawing.Point(5, 5);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(123, 20);
            this.txt_Path.TabIndex = 3;
            // 
            // txt_FileName
            // 
            this.txt_FileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_FileName.Location = new System.Drawing.Point(5, 32);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(123, 20);
            this.txt_FileName.TabIndex = 4;
            this.txt_FileName.TextChanged += new System.EventHandler(this.txt_FileName_TextChanged);
            // 
            // lbl_Validation1
            // 
            this.lbl_Validation1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation1.AutoSize = true;
            this.lbl_Validation1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation1.Location = new System.Drawing.Point(136, 35);
            this.lbl_Validation1.Name = "lbl_Validation1";
            this.lbl_Validation1.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation1.TabIndex = 5;
            this.lbl_Validation1.Text = "Invalid";
            // 
            // lbl_Status
            // 
            this.lbl_Status.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(90, 96);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(93, 13);
            this.lbl_Status.TabIndex = 6;
            this.lbl_Status.Text = "Choose An Option";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txt_Path, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Browse, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Assessment, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Validation1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_CLO, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_FileName, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 86);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Status, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(123, 37);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(274, 115);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // lbl_Heading
            // 
            this.lbl_Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Heading.AutoSize = true;
            this.lbl_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Heading.Location = new System.Drawing.Point(133, 9);
            this.lbl_Heading.Name = "lbl_Heading";
            this.lbl_Heading.Size = new System.Drawing.Size(156, 25);
            this.lbl_Heading.TabIndex = 21;
            this.lbl_Heading.Text = "Manage Reports";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 37);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(105, 296);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(105, 296);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // Reports_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 346);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbl_Heading);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(425, 385);
            this.Name = "Reports_Form";
            this.Text = "Reports_Form";
            this.Load += new System.EventHandler(this.Reports_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_CLO;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_Assessment;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Label lbl_Validation1;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_Heading;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}