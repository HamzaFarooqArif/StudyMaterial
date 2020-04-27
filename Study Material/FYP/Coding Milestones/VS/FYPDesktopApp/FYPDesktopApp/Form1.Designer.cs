namespace FYPDesktopApp
{
    partial class Form1
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
            this.IBCam = new Emgu.CV.UI.ImageBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.CB_PortNames = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_Serial = new System.Windows.Forms.Button();
            this.CB_CameraNames = new System.Windows.Forms.ComboBox();
            this.txt_Roll = new System.Windows.Forms.TextBox();
            this.lbl_Roll = new System.Windows.Forms.Label();
            this.txt_Pitch = new System.Windows.Forms.TextBox();
            this.txt_Yaw = new System.Windows.Forms.TextBox();
            this.lbl_Pitch = new System.Windows.Forms.Label();
            this.lbl_Yaw = new System.Windows.Forms.Label();
            this.IBCam2 = new Emgu.CV.UI.ImageBox();
            this.btn_Start2 = new System.Windows.Forms.Button();
            this.CB_CameraNames2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.IBCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IBCam2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // IBCam
            // 
            this.IBCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IBCam.InitialImage = null;
            this.IBCam.Location = new System.Drawing.Point(3, 3);
            this.IBCam.Name = "IBCam";
            this.IBCam.Size = new System.Drawing.Size(640, 478);
            this.IBCam.TabIndex = 2;
            this.IBCam.TabStop = false;
            // 
            // btn_Start
            // 
            this.btn_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Start.Location = new System.Drawing.Point(3, 36);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(101, 28);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start Capture";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // CB_PortNames
            // 
            this.CB_PortNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_PortNames.FormattingEnabled = true;
            this.CB_PortNames.Location = new System.Drawing.Point(3, 3);
            this.CB_PortNames.Name = "CB_PortNames";
            this.CB_PortNames.Size = new System.Drawing.Size(104, 21);
            this.CB_PortNames.TabIndex = 5;
            // 
            // btn_Serial
            // 
            this.btn_Serial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Serial.Location = new System.Drawing.Point(3, 36);
            this.btn_Serial.Name = "btn_Serial";
            this.btn_Serial.Size = new System.Drawing.Size(104, 28);
            this.btn_Serial.TabIndex = 7;
            this.btn_Serial.Text = "Start Serial";
            this.btn_Serial.UseVisualStyleBackColor = true;
            this.btn_Serial.Click += new System.EventHandler(this.button1_Click);
            // 
            // CB_CameraNames
            // 
            this.CB_CameraNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_CameraNames.FormattingEnabled = true;
            this.CB_CameraNames.Location = new System.Drawing.Point(3, 3);
            this.CB_CameraNames.Name = "CB_CameraNames";
            this.CB_CameraNames.Size = new System.Drawing.Size(101, 21);
            this.CB_CameraNames.TabIndex = 8;
            // 
            // txt_Roll
            // 
            this.txt_Roll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Roll.Location = new System.Drawing.Point(248, 3);
            this.txt_Roll.Name = "txt_Roll";
            this.txt_Roll.Size = new System.Drawing.Size(46, 20);
            this.txt_Roll.TabIndex = 9;
            // 
            // lbl_Roll
            // 
            this.lbl_Roll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Roll.AutoSize = true;
            this.lbl_Roll.Location = new System.Drawing.Point(208, 5);
            this.lbl_Roll.Name = "lbl_Roll";
            this.lbl_Roll.Size = new System.Drawing.Size(25, 13);
            this.lbl_Roll.TabIndex = 10;
            this.lbl_Roll.Text = "Roll";
            // 
            // txt_Pitch
            // 
            this.txt_Pitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Pitch.Location = new System.Drawing.Point(150, 3);
            this.txt_Pitch.Name = "txt_Pitch";
            this.txt_Pitch.Size = new System.Drawing.Size(43, 20);
            this.txt_Pitch.TabIndex = 11;
            // 
            // txt_Yaw
            // 
            this.txt_Yaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Yaw.Location = new System.Drawing.Point(52, 3);
            this.txt_Yaw.Name = "txt_Yaw";
            this.txt_Yaw.Size = new System.Drawing.Size(43, 20);
            this.txt_Yaw.TabIndex = 12;
            // 
            // lbl_Pitch
            // 
            this.lbl_Pitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Pitch.AutoSize = true;
            this.lbl_Pitch.Location = new System.Drawing.Point(107, 5);
            this.lbl_Pitch.Name = "lbl_Pitch";
            this.lbl_Pitch.Size = new System.Drawing.Size(31, 13);
            this.lbl_Pitch.TabIndex = 13;
            this.lbl_Pitch.Text = "Pitch";
            // 
            // lbl_Yaw
            // 
            this.lbl_Yaw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Yaw.AutoSize = true;
            this.lbl_Yaw.Location = new System.Drawing.Point(10, 5);
            this.lbl_Yaw.Name = "lbl_Yaw";
            this.lbl_Yaw.Size = new System.Drawing.Size(28, 13);
            this.lbl_Yaw.TabIndex = 14;
            this.lbl_Yaw.Text = "Yaw";
            // 
            // IBCam2
            // 
            this.IBCam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IBCam2.InitialImage = null;
            this.IBCam2.Location = new System.Drawing.Point(649, 3);
            this.IBCam2.Name = "IBCam2";
            this.IBCam2.Size = new System.Drawing.Size(641, 478);
            this.IBCam2.TabIndex = 15;
            this.IBCam2.TabStop = false;
            // 
            // btn_Start2
            // 
            this.btn_Start2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Start2.Location = new System.Drawing.Point(110, 36);
            this.btn_Start2.Name = "btn_Start2";
            this.btn_Start2.Size = new System.Drawing.Size(102, 28);
            this.btn_Start2.TabIndex = 16;
            this.btn_Start2.Text = "Start Capture";
            this.btn_Start2.UseVisualStyleBackColor = true;
            this.btn_Start2.Click += new System.EventHandler(this.btn_Start2_Click);
            // 
            // CB_CameraNames2
            // 
            this.CB_CameraNames2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_CameraNames2.FormattingEnabled = true;
            this.CB_CameraNames2.Location = new System.Drawing.Point(110, 3);
            this.CB_CameraNames2.Name = "CB_CameraNames2";
            this.CB_CameraNames2.Size = new System.Drawing.Size(102, 21);
            this.CB_CameraNames2.TabIndex = 17;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.IBCam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.IBCam2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1293, 563);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.53125F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.46875F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 487);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(640, 73);
            this.tableLayoutPanel5.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CB_CameraNames, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Start, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_Start2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.CB_CameraNames2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(215, 67);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.68329F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.31671F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Serial, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.CB_PortNames, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(224, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(413, 67);
            this.tableLayoutPanel3.TabIndex = 19;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Controls.Add(this.txt_Yaw, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbl_Pitch, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txt_Roll, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbl_Roll, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.txt_Pitch, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbl_Yaw, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(113, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(297, 24);
            this.tableLayoutPanel4.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.IBCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IBCam2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox IBCam;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ComboBox CB_PortNames;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_Serial;
        private System.Windows.Forms.ComboBox CB_CameraNames;
        private System.Windows.Forms.TextBox txt_Roll;
        private System.Windows.Forms.Label lbl_Roll;
        private System.Windows.Forms.TextBox txt_Pitch;
        private System.Windows.Forms.TextBox txt_Yaw;
        private System.Windows.Forms.Label lbl_Pitch;
        private System.Windows.Forms.Label lbl_Yaw;
        private Emgu.CV.UI.ImageBox IBCam2;
        private System.Windows.Forms.Button btn_Start2;
        private System.Windows.Forms.ComboBox CB_CameraNames2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}

