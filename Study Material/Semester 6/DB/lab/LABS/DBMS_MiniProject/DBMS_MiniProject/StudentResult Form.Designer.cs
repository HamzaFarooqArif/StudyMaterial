namespace DBMS_MiniProject
{
    partial class StudentResult_Form
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
            this.lbl_Assessment = new System.Windows.Forms.Label();
            this.lbl_Student = new System.Windows.Forms.Label();
            this.cb_Assessment = new System.Windows.Forms.ComboBox();
            this.cb_Student = new System.Windows.Forms.ComboBox();
            this.flp_Student = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.dgv_StudentResult = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Heading = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StudentResult)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Assessment
            // 
            this.lbl_Assessment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Assessment.AutoSize = true;
            this.lbl_Assessment.Location = new System.Drawing.Point(3, 9);
            this.lbl_Assessment.Name = "lbl_Assessment";
            this.lbl_Assessment.Size = new System.Drawing.Size(63, 13);
            this.lbl_Assessment.TabIndex = 0;
            this.lbl_Assessment.Text = "Assessment";
            // 
            // lbl_Student
            // 
            this.lbl_Student.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Student.AutoSize = true;
            this.lbl_Student.Location = new System.Drawing.Point(3, 40);
            this.lbl_Student.Name = "lbl_Student";
            this.lbl_Student.Size = new System.Drawing.Size(44, 13);
            this.lbl_Student.TabIndex = 1;
            this.lbl_Student.Text = "Student";
            // 
            // cb_Assessment
            // 
            this.cb_Assessment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Assessment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Assessment.FormattingEnabled = true;
            this.cb_Assessment.Location = new System.Drawing.Point(80, 3);
            this.cb_Assessment.Name = "cb_Assessment";
            this.cb_Assessment.Size = new System.Drawing.Size(480, 21);
            this.cb_Assessment.TabIndex = 0;
            this.cb_Assessment.SelectedIndexChanged += new System.EventHandler(this.cb_Assessment_SelectedIndexChanged);
            // 
            // cb_Student
            // 
            this.cb_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Student.FormattingEnabled = true;
            this.cb_Student.Location = new System.Drawing.Point(80, 34);
            this.cb_Student.Name = "cb_Student";
            this.cb_Student.Size = new System.Drawing.Size(480, 21);
            this.cb_Student.TabIndex = 1;
            this.cb_Student.SelectedIndexChanged += new System.EventHandler(this.cb_Student_SelectedIndexChanged);
            // 
            // flp_Student
            // 
            this.flp_Student.AutoScroll = true;
            this.flp_Student.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flp_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Student.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Student.Location = new System.Drawing.Point(5, 5);
            this.flp_Student.Name = "flp_Student";
            this.flp_Student.Size = new System.Drawing.Size(518, 220);
            this.flp_Student.TabIndex = 0;
            this.flp_Student.WrapContents = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Exit.Location = new System.Drawing.Point(379, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(180, 53);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "Exit To Home";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Confirm.Location = new System.Drawing.Point(5, 5);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(179, 53);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "Confirm";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // dgv_StudentResult
            // 
            this.dgv_StudentResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_StudentResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StudentResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column4,
            this.Column5});
            this.dgv_StudentResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_StudentResult.Location = new System.Drawing.Point(531, 5);
            this.dgv_StudentResult.Name = "dgv_StudentResult";
            this.dgv_StudentResult.Size = new System.Drawing.Size(609, 220);
            this.dgv_StudentResult.TabIndex = 1;
            this.dgv_StudentResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_StudentResult_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "StudentId";
            this.Column1.Name = "Column1";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Assessment";
            this.Column6.Name = "Column6";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Component";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Rubric";
            this.Column3.Name = "Column3";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Level";
            this.Column7.Name = "Column7";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "EvaluationDate";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Modify";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Text = "Edit/Delete";
            this.Column5.UseColumnTextForButtonValue = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Delete.Location = new System.Drawing.Point(192, 5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(179, 53);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Assessment, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_Assessment, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_Student, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Student, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Confirm, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Delete, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exit, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(576, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(564, 63);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lbl_Heading
            // 
            this.lbl_Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Heading.AutoSize = true;
            this.lbl_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Heading.Location = new System.Drawing.Point(471, 9);
            this.lbl_Heading.Name = "lbl_Heading";
            this.lbl_Heading.Size = new System.Drawing.Size(216, 25);
            this.lbl_Heading.TabIndex = 12;
            this.lbl_Heading.Text = "Manage Student Result";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 524F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.flp_Student, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgv_StudentResult, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(123, 116);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1145, 230);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(123, 37);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1145, 73);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(105, 296);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // StudentResult_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 358);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.lbl_Heading);
            this.MinimumSize = new System.Drawing.Size(1296, 397);
            this.Name = "StudentResult_Form";
            this.Text = "StudentResult_Form";
            this.Load += new System.EventHandler(this.StudentResult_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StudentResult)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Assessment;
        private System.Windows.Forms.Label lbl_Student;
        private System.Windows.Forms.ComboBox cb_Assessment;
        private System.Windows.Forms.ComboBox cb_Student;
        private System.Windows.Forms.FlowLayoutPanel flp_Student;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.DataGridView dgv_StudentResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_Heading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}