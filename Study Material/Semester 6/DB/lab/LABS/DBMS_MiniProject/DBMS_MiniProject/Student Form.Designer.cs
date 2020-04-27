namespace DBMS_MiniProject
{
    partial class Student_Form
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
            this.components = new System.ComponentModel.Container();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.lbl_Contact = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txt_RegistrationNumber = new System.Windows.Forms.TextBox();
            this.lbl_RegistrationNumber = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dgv_Student = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.projectBDataSet = new DBMS_MiniProject.ProjectBDataSet();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableAdapter = new DBMS_MiniProject.ProjectBDataSetTableAdapters.StudentTableAdapter();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Validation1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Heading = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_FirstName.Location = new System.Drawing.Point(3, 3);
            this.txt_FirstName.MaxLength = 50;
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.Size = new System.Drawing.Size(437, 20);
            this.txt_FirstName.TabIndex = 0;
            this.txt_FirstName.TextChanged += new System.EventHandler(this.txt_FirstName_TextChanged);
            // 
            // txt_LastName
            // 
            this.txt_LastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_LastName.Location = new System.Drawing.Point(3, 3);
            this.txt_LastName.MaxLength = 50;
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(437, 20);
            this.txt_LastName.TabIndex = 0;
            this.txt_LastName.TextChanged += new System.EventHandler(this.txt_LastName_TextChanged);
            // 
            // txt_Contact
            // 
            this.txt_Contact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Contact.Location = new System.Drawing.Point(3, 3);
            this.txt_Contact.MaxLength = 50;
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.Size = new System.Drawing.Size(437, 20);
            this.txt_Contact.TabIndex = 0;
            this.txt_Contact.TextChanged += new System.EventHandler(this.txt_Contact_TextChanged);
            // 
            // txt_Email
            // 
            this.txt_Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Email.Location = new System.Drawing.Point(3, 3);
            this.txt_Email.MaxLength = 50;
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(437, 20);
            this.txt_Email.TabIndex = 0;
            this.txt_Email.TextChanged += new System.EventHandler(this.txt_Email_TextChanged);
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_FirstName.AutoSize = true;
            this.lbl_FirstName.Location = new System.Drawing.Point(5, 7);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_FirstName.TabIndex = 1;
            this.lbl_FirstName.Text = "First Name";
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Location = new System.Drawing.Point(5, 32);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_LastName.TabIndex = 5;
            this.lbl_LastName.Text = "Last Name";
            // 
            // lbl_Contact
            // 
            this.lbl_Contact.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Contact.AutoSize = true;
            this.lbl_Contact.Location = new System.Drawing.Point(5, 57);
            this.lbl_Contact.Name = "lbl_Contact";
            this.lbl_Contact.Size = new System.Drawing.Size(44, 13);
            this.lbl_Contact.TabIndex = 6;
            this.lbl_Contact.Text = "Contact";
            // 
            // lbl_Email
            // 
            this.lbl_Email.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(5, 82);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 7;
            this.lbl_Email.Text = "Email";
            this.lbl_Email.Click += new System.EventHandler(this.lbl_Email_Click);
            // 
            // txt_RegistrationNumber
            // 
            this.txt_RegistrationNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RegistrationNumber.Location = new System.Drawing.Point(3, 3);
            this.txt_RegistrationNumber.MaxLength = 50;
            this.txt_RegistrationNumber.Name = "txt_RegistrationNumber";
            this.txt_RegistrationNumber.Size = new System.Drawing.Size(437, 20);
            this.txt_RegistrationNumber.TabIndex = 0;
            this.txt_RegistrationNumber.TextChanged += new System.EventHandler(this.txt_RegistrationNumber_TextChanged);
            // 
            // lbl_RegistrationNumber
            // 
            this.lbl_RegistrationNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_RegistrationNumber.AutoSize = true;
            this.lbl_RegistrationNumber.Location = new System.Drawing.Point(5, 107);
            this.lbl_RegistrationNumber.Name = "lbl_RegistrationNumber";
            this.lbl_RegistrationNumber.Size = new System.Drawing.Size(103, 13);
            this.lbl_RegistrationNumber.TabIndex = 9;
            this.lbl_RegistrationNumber.Text = "Registration Number";
            // 
            // lbl_Status
            // 
            this.lbl_Status.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(5, 132);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(37, 13);
            this.lbl_Status.TabIndex = 10;
            this.lbl_Status.Text = "Status";
            // 
            // cb_status
            // 
            this.cb_status.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Location = new System.Drawing.Point(122, 130);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(493, 21);
            this.cb_status.TabIndex = 5;
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Add.Location = new System.Drawing.Point(5, 5);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(146, 20);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dgv_Student
            // 
            this.dgv_Student.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Student.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Student.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgv_Student.Location = new System.Drawing.Point(123, 232);
            this.dgv_Student.Name = "dgv_Student";
            this.dgv_Student.Size = new System.Drawing.Size(620, 251);
            this.dgv_Student.TabIndex = 13;
            this.dgv_Student.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.FillWeight = 40.60914F;
            this.Column8.HeaderText = "Id";
            this.Column8.Name = "Column8";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 108.4844F;
            this.Column1.HeaderText = "FirstName";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 108.4844F;
            this.Column2.HeaderText = "LastName";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 108.4844F;
            this.Column3.HeaderText = "Contact";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 108.4844F;
            this.Column4.HeaderText = "Email";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 108.4844F;
            this.Column5.HeaderText = "RegistrationNumber";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.FillWeight = 108.4844F;
            this.Column6.HeaderText = "Status";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.FillWeight = 108.4844F;
            this.Column7.HeaderText = "Modify";
            this.Column7.Name = "Column7";
            this.Column7.Text = "Edit/Delete";
            this.Column7.UseColumnTextForButtonValue = true;
            // 
            // projectBDataSet
            // 
            this.projectBDataSet.DataSetName = "ProjectBDataSet";
            this.projectBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.projectBDataSet;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // btn_Update
            // 
            this.btn_Update.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Update.Location = new System.Drawing.Point(159, 5);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(146, 20);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Delete.Location = new System.Drawing.Point(313, 5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(146, 20);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Exit.Location = new System.Drawing.Point(467, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(148, 20);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit to Home";
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FirstName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_LastName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Contact, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Email, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_RegistrationNumber, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Status, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cb_status, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(123, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 153);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lbl_Validation5, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.txt_RegistrationNumber, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(122, 105);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(493, 17);
            this.tableLayoutPanel5.TabIndex = 4;
            this.tableLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // lbl_Validation5
            // 
            this.lbl_Validation5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation5.AutoSize = true;
            this.lbl_Validation5.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation5.Location = new System.Drawing.Point(446, 2);
            this.lbl_Validation5.Name = "lbl_Validation5";
            this.lbl_Validation5.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation5.TabIndex = 0;
            this.lbl_Validation5.Text = "Invalid";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel7.Controls.Add(this.lbl_Validation4, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.txt_Email, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(122, 80);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(493, 17);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // lbl_Validation4
            // 
            this.lbl_Validation4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation4.AutoSize = true;
            this.lbl_Validation4.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation4.Location = new System.Drawing.Point(446, 2);
            this.lbl_Validation4.Name = "lbl_Validation4";
            this.lbl_Validation4.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation4.TabIndex = 0;
            this.lbl_Validation4.Text = "Invalid";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel6.Controls.Add(this.lbl_Validation3, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.txt_Contact, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(122, 55);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(493, 17);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // lbl_Validation3
            // 
            this.lbl_Validation3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation3.AutoSize = true;
            this.lbl_Validation3.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation3.Location = new System.Drawing.Point(446, 2);
            this.lbl_Validation3.Name = "lbl_Validation3";
            this.lbl_Validation3.Size = new System.Drawing.Size(38, 13);
            this.lbl_Validation3.TabIndex = 0;
            this.lbl_Validation3.Text = "Invalid";
            this.lbl_Validation3.Click += new System.EventHandler(this.label4_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lbl_Validation2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txt_LastName, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(122, 30);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(493, 17);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lbl_Validation2
            // 
            this.lbl_Validation2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation2.AutoSize = true;
            this.lbl_Validation2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation2.Location = new System.Drawing.Point(446, 2);
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
            this.tableLayoutPanel3.Controls.Add(this.lbl_Validation1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_FirstName, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(122, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(493, 17);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbl_Validation1
            // 
            this.lbl_Validation1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Validation1.AutoSize = true;
            this.lbl_Validation1.ForeColor = System.Drawing.Color.Red;
            this.lbl_Validation1.Location = new System.Drawing.Point(446, 2);
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
            this.tableLayoutPanel2.Controls.Add(this.btn_Delete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exit, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Add, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Update, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(123, 196);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(620, 30);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // lbl_Heading
            // 
            this.lbl_Heading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Heading.AutoSize = true;
            this.lbl_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Heading.Location = new System.Drawing.Point(305, 9);
            this.lbl_Heading.Name = "lbl_Heading";
            this.lbl_Heading.Size = new System.Drawing.Size(157, 25);
            this.lbl_Heading.TabIndex = 19;
            this.lbl_Heading.Text = "Manage Student";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(105, 296);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // Student_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 495);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbl_Heading);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_Student);
            this.MinimumSize = new System.Drawing.Size(771, 534);
            this.Name = "Student_Form";
            this.Text = "Student_Form";
            this.Load += new System.EventHandler(this.Student_Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Student_Form_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Student_Form_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.Label lbl_Contact;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txt_RegistrationNumber;
        private System.Windows.Forms.Label lbl_RegistrationNumber;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dgv_Student;
        private ProjectBDataSet projectBDataSet;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private ProjectBDataSetTableAdapters.StudentTableAdapter studentTableAdapter;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
        private System.Windows.Forms.Label lbl_Heading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_Validation1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbl_Validation2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lbl_Validation5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lbl_Validation4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lbl_Validation3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}