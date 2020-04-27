namespace DBMS_MiniProject
{
    partial class studentResultControl
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
            this.lbl_AssessmentComponent = new System.Windows.Forms.Label();
            this.lbl_Rubric = new System.Windows.Forms.Label();
            this.cb_MeasurementLevel = new System.Windows.Forms.ComboBox();
            this.lbl_RubricLevelDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_AssessmentComponent
            // 
            this.lbl_AssessmentComponent.AutoSize = true;
            this.lbl_AssessmentComponent.Location = new System.Drawing.Point(3, 0);
            this.lbl_AssessmentComponent.Name = "lbl_AssessmentComponent";
            this.lbl_AssessmentComponent.Size = new System.Drawing.Size(120, 13);
            this.lbl_AssessmentComponent.TabIndex = 0;
            this.lbl_AssessmentComponent.Text = "Assessment Component";
            // 
            // lbl_Rubric
            // 
            this.lbl_Rubric.AutoSize = true;
            this.lbl_Rubric.Location = new System.Drawing.Point(157, 0);
            this.lbl_Rubric.Name = "lbl_Rubric";
            this.lbl_Rubric.Size = new System.Drawing.Size(38, 13);
            this.lbl_Rubric.TabIndex = 1;
            this.lbl_Rubric.Text = "Rubric";
            // 
            // cb_MeasurementLevel
            // 
            this.cb_MeasurementLevel.FormattingEnabled = true;
            this.cb_MeasurementLevel.Location = new System.Drawing.Point(235, 0);
            this.cb_MeasurementLevel.Name = "cb_MeasurementLevel";
            this.cb_MeasurementLevel.Size = new System.Drawing.Size(121, 21);
            this.cb_MeasurementLevel.TabIndex = 2;
            this.cb_MeasurementLevel.SelectedIndexChanged += new System.EventHandler(this.cb_MeasurementLevel_SelectedIndexChanged);
            // 
            // lbl_RubricLevelDetails
            // 
            this.lbl_RubricLevelDetails.AutoSize = true;
            this.lbl_RubricLevelDetails.Location = new System.Drawing.Point(371, 0);
            this.lbl_RubricLevelDetails.Name = "lbl_RubricLevelDetails";
            this.lbl_RubricLevelDetails.Size = new System.Drawing.Size(102, 13);
            this.lbl_RubricLevelDetails.TabIndex = 3;
            this.lbl_RubricLevelDetails.Text = "Rubric Level Details";
            // 
            // studentResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_RubricLevelDetails);
            this.Controls.Add(this.cb_MeasurementLevel);
            this.Controls.Add(this.lbl_Rubric);
            this.Controls.Add(this.lbl_AssessmentComponent);
            this.Name = "studentResultControl";
            this.Size = new System.Drawing.Size(503, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_AssessmentComponent;
        private System.Windows.Forms.Label lbl_Rubric;
        private System.Windows.Forms.ComboBox cb_MeasurementLevel;
        private System.Windows.Forms.Label lbl_RubricLevelDetails;
    }
}
