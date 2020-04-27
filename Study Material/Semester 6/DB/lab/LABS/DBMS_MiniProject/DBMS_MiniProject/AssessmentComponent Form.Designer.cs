namespace DBMS_MiniProject
{
    partial class AssessmentComponent_Form
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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_TotalMarks = new System.Windows.Forms.Label();
            this.lbl_Rubric = new System.Windows.Forms.Label();
            this.lbl_Assessment = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_TotalMarks = new System.Windows.Forms.TextBox();
            this.cb_Rubric = new System.Windows.Forms.ComboBox();
            this.cb_Assessment = new System.Windows.Forms.ComboBox();
            this.dgv_AssessmentComponent = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lbl_RubricDetails = new System.Windows.Forms.Label();
            this.txt_RubricDetails = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Heading = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AssessmentComponent)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(5, 7);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_TotalMarks
            // 
            this.lbl_TotalMarks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_TotalMarks.AutoSize = true;
            this.lbl_TotalMarks.Location = new System.Drawing.Point(5, 33);
            this.lbl_TotalMarks.Name = "lbl_TotalMarks";
            this.lbl_TotalMarks.Size = new System.Drawing.Size(63, 13);
            this.lbl_TotalMarks.TabIndex = 1;
            this.lbl_TotalMarks.Text = "Total Marks";
            // 
            // lbl_Rubric
            // 
            this.lbl_Rubric.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Rubric.AutoSize = true;
            this.lbl_Rubric.Location = new System.Drawing.Point(5, 59);
            this.lbl_Rubric.Name = "lbl_Rubric";
            this.lbl_Rubric.Size = new System.Drawing.Size(47, 13);
            this.lbl_Rubric.TabIndex = 2;
            this.lbl_Rubric.Text = "RubricId";
            // 
            // lbl_Assessment
            // 
            this.lbl_Assessment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Assessment.AutoSize = true;
            this.lbl_Assessment.Location = new System.Drawing.Point(5, 113);
            this.lbl_Assessment.Name = "lbl_Assessment";
            this.lbl_Assessment.Size = new System.Drawing.Size(63, 13);
            this.lbl_Assessment.TabIndex = 3;
            this.lbl_Assessment.Text = "Assessment";
            // 
            // txt_Name
            // 
            this.txt_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Name.Location = new System.Drawing.Point(3, 3);
            this.txt_Name.MaxLength = 50;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(598, 20);
            this.txt_Name.TabIndex = 4;
            this.txt_Name.TextChanged += new System.EventHandler(this.txt_Name_TextChanged);
            // 
            // txt_TotalMarks
            // 
            this.txt_TotalMarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_TotalMarks.Location = new System.Drawing.Point(3, 3);
            this.txt_TotalMarks.MaxLength = 3;
            this.txt_TotalMarks.Name = "txt_TotalMarks";
            this.txt_TotalMarks.Size = new System.Drawing.Size(598, 20);
            this.txt_TotalMarks.TabIndex = 5;
            this.txt_TotalMarks.TextChanged += new System.EventHandler(this.txt_TotalMarks_TextChanged);
            // 
            // cb_Rubric
            // 
            this.cb_Rubric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Rubric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Rubric.FormattingEnabled = true;
            this.cb_Rubric.Location = new System.Drawing.Point(85, 57);
            this.cb_Rubric.Name = "cb_Rubric";
            this.cb_Rubric.Size = new System.Drawing.Size(654, 21);
            this.cb_Rubric.TabIndex = 2;
            this.cb_Rubric.SelectedIndexChanged += new System.EventHandler(this.cb_Rubric_SelectedIndexChanged);
            // 
            // cb_Assessment
            // 
            this.cb_Assessment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Assessment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Assessment.FormattingEnabled = true;
            this.cb_Assessment.Location = new System.Drawing.Point(85, 109);
            this.cb_Assessment.Name = "cb_Assessment";
            this.cb_Assessment.Size = new System.Drawing.Size(654, 21);
            this.cb_Assessment.TabIndex = 4;
            // 
            // dgv_AssessmentComponent
            // 
            this.dgv_AssessmentComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_AssessmentComponent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_AssessmentComponent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AssessmentComponent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgv_AssessmentComponent.Location = new System.Drawing.Point(123, 224);
            this.dgv_AssessmentComponent.Name = "dgv_AssessmentComponent";
            this.dgv_AssessmentComponent.Size = new System.Drawing.Size(744, 137);
            this.dgv_AssessmentComponent.TabIndex = 0;
            this.dgv_AssessmentComponent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AssessmentComponent_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "RubricId";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "TotalMarks";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DateCreated";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "DateUpdated";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "AssessmentId";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Modify";
            this.Column8.Name = "Column8";
            this.Column8.Text = "Edit/Delete";
            this.Column8.UseColumnTextForButtonValue = true;
            // 
            // lbl_RubricDetails
            // 
            this.lbl_RubricDetails.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_RubricDetails.AutoSize = true;
            this.lbl_RubricDetails.Location = new System.Drawing.Point(5, 85);
            this.lbl_RubricDetails.Name = "lbl_RubricDetails";
            this.lbl_RubricDetails.Size = new System.Drawing.Size(39, 13);
            this.lbl_RubricDetails.TabIndex = 9;
            this.lbl_RubricDetails.Text = "Details";
            this.lbl_RubricDetails.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_RubricDetails
            // 
            this.txt_RubricDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RubricDetails.Location = new System.Drawing.Point(85, 83);
            this.txt_RubricDetails.Name = "txt_RubricDetails";
            this.txt_RubricDetails.ReadOnly = true;
            this.txt_RubricDetails.Size = new System.Drawing.Size(654, 20);
            this.txt_RubricDetails.TabIndex = 3;
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.Location = new System.Drawing.Point(5, 5);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(177, 20);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Update.Location = new System.Drawing.Point(190, 5);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(177, 20);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Delete.Location = new System.Drawing.Point(375, 5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(177, 20);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Exit.Location = new System.Drawing.Point(560, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(179, 20);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Name, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_TotalMarks, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Rubric, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_RubricDetails, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_RubricDetails, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Assessment, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cb_Rubric, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cb_Assessment, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(123, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 136);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_Validation2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_TotalMarks, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(85, 31);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(654, 18);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lbl_Validation2
            // 
            this.lbl_Validation2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation2.AutoSize = true;
            this.lbl_Validation2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation2.Location = new System.Drawing.Point(607, 2);
            this.lbl_Validation2.Name = "lbl_Validation2";
            this.lbl_Validation2.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation2.TabIndex = 0;
            this.lbl_Validation2.Text = "Invalid";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lbl_Validation1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txt_Name, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(85, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(654, 18);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lbl_Validation1
            // 
            this.lbl_Validation1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation1.AutoSize = true;
            this.lbl_Validation1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation1.Location = new System.Drawing.Point(607, 2);
            this.lbl_Validation1.Name = "lbl_Validation1";
            this.lbl_Validation1.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation1.TabIndex = 0;
            this.lbl_Validation1.Text = "Invalid";
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
            this.tableLayoutPanel2.Controls.Add(this.btn_Exit, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Delete, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(123, 188);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(744, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_Heading
            // 
            this.lbl_Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Heading.AutoSize = true;
            this.lbl_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Heading.Location = new System.Drawing.Point(289, 9);
            this.lbl_Heading.Name = "lbl_Heading";
            this.lbl_Heading.Size = new System.Drawing.Size(304, 25);
            this.lbl_Heading.TabIndex = 21;
            this.lbl_Heading.Text = "Manage Assessment Component";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(105, 296);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // AssessmentComponent_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 373);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbl_Heading);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_AssessmentComponent);
            this.MinimumSize = new System.Drawing.Size(895, 412);
            this.Name = "AssessmentComponent_Form";
            this.Text = "AssessmentComponent_Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AssessmentComponent)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_TotalMarks;
        private System.Windows.Forms.Label lbl_Rubric;
        private System.Windows.Forms.Label lbl_Assessment;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_TotalMarks;
        private System.Windows.Forms.ComboBox cb_Rubric;
        private System.Windows.Forms.ComboBox cb_Assessment;
        private System.Windows.Forms.DataGridView dgv_AssessmentComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.Label lbl_RubricDetails;
        private System.Windows.Forms.TextBox txt_RubricDetails;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_Heading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_Validation2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbl_Validation1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}