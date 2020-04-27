using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_MiniProject
{
    public partial class Assessment_Form : Form
    {
        private static Assessment_Form assessment_Form = null;
        private static Assessment currentObject = new Assessment("Empty", -1, -1);

        public static Assessment_Form getInstance()
        {
            if (assessment_Form == null)
            {
                assessment_Form = new Assessment_Form();
            }
            //-------------------------------------------------------------------------------
            assessment_Form.ClearControls(assessment_Form);
            Navbar nav = new Navbar("Assessment_Form");
            assessment_Form.flowLayoutPanel1.Controls.Add(nav);
            assessment_Form.updateDGVAssessment();
            //-------------------------------------------------------------------------------
            return assessment_Form;
        }
        private void ClearControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
                else if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = -1;

                if (c.HasChildren)
                    ClearControls(c);
            }
        }
        private Assessment_Form()
        {
            InitializeComponent();
        }
        private void updateDGVAssessment()
        {
            dgv_Assessment.Rows.Clear();
            List<Assessment> assessmentList = Assessment.retrieveAssessments();
            foreach (Assessment ast in assessmentList)
            {
                int n = dgv_Assessment.Rows.Add();
                dgv_Assessment.Rows[n].Cells[0].Value = ast.Id;
                dgv_Assessment.Rows[n].Cells[1].Value = ast.Title;
                dgv_Assessment.Rows[n].Cells[2].Value = ast.DateCreated.ToShortDateString();
                dgv_Assessment.Rows[n].Cells[3].Value = ast.TotalMarks;
                dgv_Assessment.Rows[n].Cells[4].Value = ast.TotalWeightage;
            }
        }

        private void Assessment_Form_Load(object sender, EventArgs e)
        {

        }

        private void loadCurrentObject()
        {
            txt_Title.Text = currentObject.Title;
            txt_TotalMarks.Text = currentObject.TotalMarks.ToString();
            txt_TotalWeightage.Text = currentObject.TotalWeightage.ToString();
        }
        private void setCurrentObject()
        {
            currentObject.Title = txt_Title.Text;
            currentObject.TotalMarks = Int32.Parse(txt_TotalMarks.Text);
            currentObject.TotalWeightage = Int32.Parse(txt_TotalWeightage.Text);
        }
        private void loadBlank()
        {
            txt_Title.Clear();
            txt_TotalMarks.Clear();
            txt_TotalWeightage.Clear();
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(txt_Title.Text) ||
                string.IsNullOrWhiteSpace(txt_TotalMarks.Text) ||
                string.IsNullOrWhiteSpace(txt_TotalWeightage.Text) ||
                !validateForm()
               ) return true;
            else return false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                currentObject.Id = Convert.ToInt32(dgv_Assessment.Rows[e.RowIndex].Cells["Column1"].Value);
                currentObject.Title = dgv_Assessment.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                currentObject.TotalMarks = Convert.ToInt32(dgv_Assessment.Rows[e.RowIndex].Cells["Column4"].Value);
                currentObject.TotalWeightage = Convert.ToInt32(dgv_Assessment.Rows[e.RowIndex].Cells["Column5"].Value);

                Assessment ast = Assessment.getAssessmentById(currentObject.Id);

                currentObject.DateCreated = ast.DateCreated;
                
                loadCurrentObject();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            currentObject.Id = -1;
            currentObject.Title = txt_Title.Text;
            currentObject.TotalMarks = Int32.Parse(txt_TotalMarks.Text);
            currentObject.TotalWeightage = Int32.Parse(txt_TotalWeightage.Text);

            if (Assessment.addAssessment(currentObject) == 1) MessageBox.Show("Added Successfully");
            else MessageBox.Show("Error: Add Failed");

            updateDGVAssessment();
            loadBlank();
            currentObject.Id = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            if (currentObject.Id == -1) MessageBox.Show("Warning: Select An Object First!");
            else
            {
                setCurrentObject();
                int msg = Assessment.addAssessment(currentObject);
                if (msg == 0) MessageBox.Show("Error: Update Unsuccessful!");
                if (msg == 1) MessageBox.Show("Added Successfully!");
                if (msg == 2) MessageBox.Show("Updated Successfully!");
                updateDGVAssessment();
                loadBlank();
                currentObject.Id = -1;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (currentObject.Id == -1)
            {
                MessageBox.Show("Warning: Select An Object First!");
                return;
            }
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            if (Assessment.deleteAssessmentById(currentObject.Id)) MessageBox.Show("Deleted Successfully");
            else MessageBox.Show("Error: Delete Failed");
            updateDGVAssessment();
            loadBlank();
            currentObject.Id = -1;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Form1.getInstance().Show();
            this.Hide();
        }
        private bool validateForm()
        {
            bool isValid = true;

            if (Validation.validateTitle(txt_Title.Text))
            {
                lbl_Validation1.Text = "Valid";
                lbl_Validation1.ForeColor = Color.Green;
            }
            else
            {
                lbl_Validation1.Text = "Invalid";
                lbl_Validation1.ForeColor = Color.Red;
                isValid = false;
            }

            if (Validation.validateMarks(txt_TotalMarks.Text))
            {
                lbl_Validation2.Text = "Valid";
                lbl_Validation2.ForeColor = Color.Green;
            }
            else
            {
                lbl_Validation2.Text = "Invalid";
                lbl_Validation2.ForeColor = Color.Red;
                isValid = false;
            }

            if (Validation.validateMarks(txt_TotalWeightage.Text))
            {
                lbl_Validation3.Text = "Valid";
                lbl_Validation3.ForeColor = Color.Green;
            }
            else
            {
                lbl_Validation3.Text = "Invalid";
                lbl_Validation3.ForeColor = Color.Red;
                isValid = false;
            }
            return isValid;
        }

        private void txt_TotalMarks_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void txt_TotalWeightage_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }
    }
}
