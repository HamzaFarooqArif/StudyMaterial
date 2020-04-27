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
    public partial class AssessmentComponent_Form : Form
    {
        private static AssessmentComponent_Form assessmentComponent_Form = null;
        private static AssessmentComponent currentObject = new AssessmentComponent("Empty", -1, -1, -1);

        public static AssessmentComponent_Form getInstance()
        {
            if (assessmentComponent_Form == null)
            {
                assessmentComponent_Form = new AssessmentComponent_Form();
            }
            //-------------------------------------------------------------------------------
            assessmentComponent_Form.ClearControls(assessmentComponent_Form);
            Navbar nav = new Navbar("AssessmentComponent_Form");
            assessmentComponent_Form.flowLayoutPanel1.Controls.Add(nav);
            assessmentComponent_Form.updateDGVAssessmentComponent();
            assessmentComponent_Form.cb_Assessment.Items.Clear();

            List<Rubric> rubricList = Rubric.retrieveRubrics();
            assessmentComponent_Form.cb_Rubric.Items.Clear();
            foreach (Rubric rb in rubricList)
            {
                assessmentComponent_Form.cb_Rubric.Items.Add(rb.Id);
            }

            List<Assessment> assessmentList = Assessment.retrieveAssessments();
            foreach (Assessment ast in assessmentList)
            {
                assessmentComponent_Form.cb_Assessment.Items.Add(ast.Title);
            }
            if (assessmentComponent_Form.cb_Rubric.Items.Count > 0) assessmentComponent_Form.cb_Rubric.SelectedItem = assessmentComponent_Form.cb_Rubric.Items[0];
            if (assessmentComponent_Form.cb_Assessment.Items.Count > 0) assessmentComponent_Form.cb_Assessment.SelectedItem = assessmentComponent_Form.cb_Assessment.Items[0];
            //-------------------------------------------------------------------------------
            return assessmentComponent_Form;
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
        private AssessmentComponent_Form()
        {
            InitializeComponent();
        }
        private void updateDGVAssessmentComponent()
        {
            dgv_AssessmentComponent.Rows.Clear();
            List<AssessmentComponent> assessmentComponentList = AssessmentComponent.retrieveAssessmentComponents();
            foreach (AssessmentComponent asc in assessmentComponentList)
            {
                int n = dgv_AssessmentComponent.Rows.Add();
                dgv_AssessmentComponent.Rows[n].Cells[0].Value = asc.Id;
                dgv_AssessmentComponent.Rows[n].Cells[1].Value = asc.Name;
                dgv_AssessmentComponent.Rows[n].Cells[2].Value = asc.RubricId;
                dgv_AssessmentComponent.Rows[n].Cells[3].Value = asc.TotalMarks;
                dgv_AssessmentComponent.Rows[n].Cells[4].Value = asc.DateCreated;
                dgv_AssessmentComponent.Rows[n].Cells[5].Value = asc.DateUpdated;
                dgv_AssessmentComponent.Rows[n].Cells[6].Value = asc.AssessmentId;
            }
        }
        private void loadCurrentObject()
        {
            txt_Name.Text = currentObject.Name;
            txt_TotalMarks.Text = currentObject.TotalMarks.ToString();
            cb_Rubric.Text = Rubric.getRubricById(currentObject.RubricId).Id.ToString();
            txt_RubricDetails.Text = Rubric.getRubricById(currentObject.RubricId).Details;
            cb_Assessment.Text = Assessment.getAssessmentById(currentObject.AssessmentId).Title;
        }
        private void setCurrentObject()
        {
            currentObject.Name = txt_Name.Text;
            currentObject.TotalMarks = Int32.Parse(txt_TotalMarks.Text);
            currentObject.RubricId = Int32.Parse(cb_Rubric.Text);
            currentObject.AssessmentId = Assessment.getAssessment(cb_Assessment.Text).Id;
        }
        private void loadBlank()
        {
            txt_Name.Clear();
            txt_TotalMarks.Clear();
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(txt_Name.Text) ||
                string.IsNullOrWhiteSpace(txt_TotalMarks.Text) ||
                string.IsNullOrWhiteSpace(cb_Rubric.Text) ||
                string.IsNullOrWhiteSpace(cb_Assessment.Text) ||
                !validateForm()
               ) return true;
            else return false;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_Rubric_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Rubric.Text.Length > 0)
            {
                txt_RubricDetails.Text = Rubric.getRubricById(Int32.Parse(cb_Rubric.Text)).Details;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            currentObject.Id = -1;
            currentObject.Name = txt_Name.Text;
            currentObject.RubricId = Int32.Parse(cb_Rubric.Text);
            currentObject.TotalMarks = Int32.Parse(txt_TotalMarks.Text);
            currentObject.AssessmentId = Assessment.getAssessment(cb_Assessment.Text).Id;


            if (currentObject.RubricId == -1) MessageBox.Show("Warning: Select a valid CLO!");
            if (currentObject.AssessmentId == -1) MessageBox.Show("Warning: Select a valid Assessment!");
            else
            {
                if (AssessmentComponent.addAssessmentComponent(currentObject) == 1) MessageBox.Show("Added Successfully");
                else MessageBox.Show("Error: Add Failed");
            }
            updateDGVAssessmentComponent();
            loadBlank();
            currentObject.Id = -1;
        }

        private void dgv_AssessmentComponent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                currentObject.Id = Convert.ToInt32(dgv_AssessmentComponent.Rows[e.RowIndex].Cells["Column1"].Value);
                currentObject.Name = dgv_AssessmentComponent.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                currentObject.RubricId = Convert.ToInt32(dgv_AssessmentComponent.Rows[e.RowIndex].Cells["Column3"].Value);
                currentObject.TotalMarks = Convert.ToInt32(dgv_AssessmentComponent.Rows[e.RowIndex].Cells["Column4"].Value);

                AssessmentComponent asc = AssessmentComponent.getAssessmentComponentById(currentObject.Id);

                currentObject.DateCreated = asc.DateCreated;
                currentObject.DateUpdated = asc.DateUpdated;

                currentObject.AssessmentId = Convert.ToInt32(dgv_AssessmentComponent.Rows[e.RowIndex].Cells["Column7"].Value);

                loadCurrentObject();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            if (currentObject.Id == -1) MessageBox.Show("Warning: Select An Object First!");
            else
            {
                if (currentObject.RubricId == -1) MessageBox.Show("Warning: Select a valid Rubric!");
                if (currentObject.AssessmentId == -1) MessageBox.Show("Warning: Select a valid Assessment!");
                setCurrentObject();
                int msg = AssessmentComponent.addAssessmentComponent(currentObject);
                if (msg == 0) MessageBox.Show("Error: Update Unsuccessful!");
                if (msg == 1) MessageBox.Show("Added Successfully!");
                if (msg == 2) MessageBox.Show("Updated Successfully!");
                updateDGVAssessmentComponent();
                loadBlank();
                currentObject.Id = -1;
            }
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
            if (AssessmentComponent.deleteAssessmentComponentById(currentObject.Id)) MessageBox.Show("Deleted Successfully");
            else MessageBox.Show("Error: Delete Failed");
            updateDGVAssessmentComponent();
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

            if (Validation.validateTitle(txt_Name.Text))
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
            return isValid;
        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void txt_TotalMarks_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }
    }
}
