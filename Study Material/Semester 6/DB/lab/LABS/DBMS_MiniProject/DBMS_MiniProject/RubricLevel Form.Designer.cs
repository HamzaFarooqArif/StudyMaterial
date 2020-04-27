namespace DBMS_MiniProject
{
    partial class RubricLevel_Form
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
            this.lbl_Details = new System.Windows.Forms.Label();
            this.lbl_MeasurementLevel = new System.Windows.Forms.Label();
            this.txt_Details = new System.Windows.Forms.TextBox();
            this.txt_MeasurementLevel = new System.Windows.Forms.TextBox();
            this.lbl_Rubric = new System.Windows.Forms.Label();
            this.cb_Rubric = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_RubricDetails = new System.Windows.Forms.TextBox();
            this.dgv_RubricLevel = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation1 = new System.Windows.Forms.Label();
            this.lbl_Heading = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.projectBDataSet1 = new DBMS_MiniProject.ProjectBDataSet();
            this.tableAdapterManager1 = new DBMS_MiniProject.ProjectBDataSetTableAdapters.TableAdapterManager();
            this.tableAdapterManager2 = new DBMS_MiniProject.ProjectBDataSetTableAdapters.TableAdapterManager();
            this.tableAdapterManager3 = new DBMS_MiniProject.ProjectBDataSetTableAdapters.TableAdapterManager();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RubricLevel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Details
            // 
            this.lbl_Details.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Details.AutoSize = true;
            this.lbl_Details.Location = new System.Drawing.Point(5, 6);
            this.lbl_Details.Name = "lbl_Details";
            this.lbl_Details.Size = new System.Drawing.Size(39, 13);
            this.lbl_Details.TabIndex = 0;
            this.lbl_Details.Text = "Details";
            // 
            // lbl_MeasurementLevel
            // 
            this.lbl_MeasurementLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_MeasurementLevel.AutoSize = true;
            this.lbl_MeasurementLevel.Location = new System.Drawing.Point(5, 30);
            this.lbl_MeasurementLevel.Name = "lbl_MeasurementLevel";
            this.lbl_MeasurementLevel.Size = new System.Drawing.Size(100, 13);
            this.lbl_MeasurementLevel.TabIndex = 1;
            this.lbl_MeasurementLevel.Text = "Measurement Level";
            // 
            // txt_Details
            // 
            this.txt_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Details.Location = new System.Drawing.Point(3, 3);
            this.txt_Details.MaxLength = 50;
            this.txt_Details.Name = "txt_Details";
            this.txt_Details.Size = new System.Drawing.Size(314, 20);
            this.txt_Details.TabIndex = 0;
            this.txt_Details.TextChanged += new System.EventHandler(this.txt_Details_TextChanged);
            // 
            // txt_MeasurementLevel
            // 
            this.txt_MeasurementLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MeasurementLevel.Location = new System.Drawing.Point(3, 3);
            this.txt_MeasurementLevel.MaxLength = 1;
            this.txt_MeasurementLevel.Name = "txt_MeasurementLevel";
            this.txt_MeasurementLevel.Size = new System.Drawing.Size(314, 20);
            this.txt_MeasurementLevel.TabIndex = 0;
            this.txt_MeasurementLevel.TextChanged += new System.EventHandler(this.txt_MeasurementLevel_TextChanged);
            // 
            // lbl_Rubric
            // 
            this.lbl_Rubric.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Rubric.AutoSize = true;
            this.lbl_Rubric.Location = new System.Drawing.Point(5, 54);
            this.lbl_Rubric.Name = "lbl_Rubric";
            this.lbl_Rubric.Size = new System.Drawing.Size(47, 13);
            this.lbl_Rubric.TabIndex = 4;
            this.lbl_Rubric.Text = "RubricId";
            // 
            // cb_Rubric
            // 
            this.cb_Rubric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Rubric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Rubric.FormattingEnabled = true;
            this.cb_Rubric.Location = new System.Drawing.Point(122, 53);
            this.cb_Rubric.Name = "cb_Rubric";
            this.cb_Rubric.Size = new System.Drawing.Size(370, 21);
            this.cb_Rubric.TabIndex = 2;
            this.cb_Rubric.SelectedIndexChanged += new System.EventHandler(this.cb_Rubric_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Details";
            // 
            // txt_RubricDetails
            // 
            this.txt_RubricDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RubricDetails.Location = new System.Drawing.Point(122, 77);
            this.txt_RubricDetails.Name = "txt_RubricDetails";
            this.txt_RubricDetails.ReadOnly = true;
            this.txt_RubricDetails.Size = new System.Drawing.Size(370, 20);
            this.txt_RubricDetails.TabIndex = 3;
            // 
            // dgv_RubricLevel
            // 
            this.dgv_RubricLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_RubricLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RubricLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RubricLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgv_RubricLevel.Location = new System.Drawing.Point(123, 180);
            this.dgv_RubricLevel.Name = "dgv_RubricLevel";
            this.dgv_RubricLevel.Size = new System.Drawing.Size(497, 154);
            this.dgv_RubricLevel.TabIndex = 2;
            this.dgv_RubricLevel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RubricLevel_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "RubricId";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Details";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Measurement Level";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Modify";
            this.Column5.Name = "Column5";
            this.Column5.Text = "Edit/Delete";
            this.Column5.UseColumnTextForButtonValue = true;
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.Location = new System.Drawing.Point(5, 5);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(115, 21);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Update.Location = new System.Drawing.Point(128, 5);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(115, 21);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Delete.Location = new System.Drawing.Point(251, 5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(115, 21);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Exit.Location = new System.Drawing.Point(374, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(118, 21);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit To Home";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cb_Rubric, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_RubricDetails, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Rubric, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Details, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_MeasurementLevel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(123, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Controls.Add(this.txt_MeasurementLevel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbl_Validation2, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(122, 29);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(370, 16);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lbl_Validation2
            // 
            this.lbl_Validation2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation2.AutoSize = true;
            this.lbl_Validation2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation2.Location = new System.Drawing.Point(323, 1);
            this.lbl_Validation2.Name = "lbl_Validation2";
            this.lbl_Validation2.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation2.TabIndex = 0;
            this.lbl_Validation2.Text = "Invalid";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txt_Details, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Validation1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(122, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(370, 16);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbl_Validation1
            // 
            this.lbl_Validation1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation1.AutoSize = true;
            this.lbl_Validation1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation1.Location = new System.Drawing.Point(323, 1);
            this.lbl_Validation1.Name = "lbl_Validation1";
            this.lbl_Validation1.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation1.TabIndex = 0;
            this.lbl_Validation1.Text = "Invalid";
            // 
            // lbl_Heading
            // 
            this.lbl_Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Heading.AutoSize = true;
            this.lbl_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Heading.Location = new System.Drawing.Point(218, 9);
            this.lbl_Heading.Name = "lbl_Heading";
            this.lbl_Heading.Size = new System.Drawing.Size(196, 25);
            this.lbl_Heading.TabIndex = 22;
            this.lbl_Heading.Text = "Manage Rubric Level";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Add, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Update, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Delete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exit, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(123, 143);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(497, 31);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // projectBDataSet1
            // 
            this.projectBDataSet1.DataSetName = "ProjectBDataSet";
            this.projectBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.StudentTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = DBMS_MiniProject.ProjectBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.Connection = null;
            this.tableAdapterManager2.StudentTableAdapter = null;
            this.tableAdapterManager2.UpdateOrder = DBMS_MiniProject.ProjectBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tableAdapterManager3
            // 
            this.tableAdapterManager3.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager3.Connection = null;
            this.tableAdapterManager3.StudentTableAdapter = null;
            this.tableAdapterManager3.UpdateOrder = DBMS_MiniProject.ProjectBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(105, 296);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // RubricLevel_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 346);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.lbl_Heading);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_RubricLevel);
            this.MinimumSize = new System.Drawing.Size(648, 385);
            this.Name = "RubricLevel_Form";
            this.Text = "RubricLevel_Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RubricLevel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Details;
        private System.Windows.Forms.Label lbl_MeasurementLevel;
        private System.Windows.Forms.TextBox txt_Details;
        private System.Windows.Forms.TextBox txt_MeasurementLevel;
        private System.Windows.Forms.Label lbl_Rubric;
        private System.Windows.Forms.ComboBox cb_Rubric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_RubricDetails;
        private System.Windows.Forms.DataGridView dgv_RubricLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Heading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbl_Validation2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_Validation1;
        private ProjectBDataSet projectBDataSet1;
        private ProjectBDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private ProjectBDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
        private ProjectBDataSetTableAdapters.TableAdapterManager tableAdapterManager3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}