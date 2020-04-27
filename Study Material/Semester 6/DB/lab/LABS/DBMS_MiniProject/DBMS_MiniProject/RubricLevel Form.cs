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
    public partial class RubricLevel_Form : Form
    {
        private static RubricLevel_Form rubricLevel_Form = null;
        private static RubricLevel currentObject = new RubricLevel(-1, "Empty", -1);

        public static RubricLevel_Form getInstance()
        {
            if (rubricLevel_Form == null)
            {
                rubricLevel_Form = new RubricLevel_Form();
            }
            //-------------------------------------------------------------------------------
            rubricLevel_Form.ClearControls(rubricLevel_Form);
            Navbar nav = new Navbar("RubricLevel_Form");
            rubricLevel_Form.flowLayoutPanel1.Controls.Add(nav);
            rubricLevel_Form.updateDGVRubricLevel();
            rubricLevel_Form.cb_Rubric.Items.Clear();

            List<Rubric> rubricList = Rubric.retrieveRubrics();
            foreach (Rubric rb in rubricList)
            {
                rubricLevel_Form.cb_Rubric.Items.Add(rb.Id);
            }

            if (rubricLevel_Form.cb_Rubric.Items.Count > 0) rubricLevel_Form.cb_Rubric.SelectedItem = rubricLevel_Form.cb_Rubric.Items[0];
            //-------------------------------------------------------------------------------
            return rubricLevel_Form;
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
        private void updateDGVRubricLevel()
        {
            dgv_RubricLevel.Rows.Clear();
            List<RubricLevel> rubricLevelList = RubricLevel.retrieveRubricLevels();
            foreach (RubricLevel rbl in rubricLevelList)
            {
                int n = dgv_RubricLevel.Rows.Add();
                dgv_RubricLevel.Rows[n].Cells[0].Value = rbl.Id;
                dgv_RubricLevel.Rows[n].Cells[1].Value = rbl.RubricId;
                dgv_RubricLevel.Rows[n].Cells[2].Value = rbl.Details;
                dgv_RubricLevel.Rows[n].Cells[3].Value = rbl.MeasurementLevel;
            }
        }
        private RubricLevel_Form()
        {
            InitializeComponent();
        }
        private void loadCurrentObject()
        {
            txt_Details.Text = currentObject.Details;
            txt_MeasurementLevel.Text = currentObject.MeasurementLevel.ToString();
            cb_Rubric.Text = Rubric.getRubricById(currentObject.RubricId).Id.ToString();
            txt_RubricDetails.Text = Rubric.getRubricById(currentObject.RubricId).Details.ToString();
        }
        private void setCurrentObject()
        {
            currentObject.Details = txt_Details.Text;
            currentObject.MeasurementLevel = Int32.Parse(txt_MeasurementLevel.Text);
            currentObject.RubricId = Int32.Parse(cb_Rubric.Text);
        }
        private void loadBlank()
        {
            txt_Details.Clear();
            txt_MeasurementLevel.Clear();
            txt_RubricDetails.Clear();
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(txt_Details.Text) ||
                string.IsNullOrWhiteSpace(txt_MeasurementLevel.Text) ||
                string.IsNullOrWhiteSpace(txt_RubricDetails.Text) ||
                string.IsNullOrWhiteSpace(cb_Rubric.Text) ||
                !validateForm()
               ) return true;
            else return false;
        }

        private void cb_Rubric_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_Rubric.Text.Length > 0)
            {
                txt_RubricDetails.Text = Rubric.getRubricById(Int32.Parse(cb_Rubric.Text)).Details;
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
            currentObject.RubricId = Int32.Parse(cb_Rubric.Text);
            currentObject.Details = txt_Details.Text;
            currentObject.MeasurementLevel = Int32.Parse(txt_MeasurementLevel.Text);

            if (currentObject.RubricId == -1) MessageBox.Show("Warning: Select a valid CLO!");
            else
            {
                if (RubricLevel.addRubricLevel(currentObject) == 1) MessageBox.Show("Added Successfully");
                else MessageBox.Show("Error: Add Failed");
            }
            updateDGVRubricLevel();
            loadBlank();
            currentObject.Id = -1;
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
                setCurrentObject();
                int msg = RubricLevel.addRubricLevel(currentObject);
                if (msg == 0) MessageBox.Show("Error: Update Unsuccessful!");
                if (msg == 1) MessageBox.Show("Added Successfully!");
                if (msg == 2) MessageBox.Show("Updated Successfully!");
                updateDGVRubricLevel();
                loadBlank();
                currentObject.Id = -1;
            }
        }

        private void dgv_RubricLevel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                currentObject.Id = Convert.ToInt32(dgv_RubricLevel.Rows[e.RowIndex].Cells["Column1"].Value);
                currentObject.RubricId = Convert.ToInt32(dgv_RubricLevel.Rows[e.RowIndex].Cells["Column2"].Value);
                currentObject.Details = dgv_RubricLevel.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                currentObject.MeasurementLevel = Convert.ToInt32(dgv_RubricLevel.Rows[e.RowIndex].Cells["Column4"].Value);

                loadCurrentObject();
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
            if (RubricLevel.deleteRubricLevelById(currentObject.Id)) MessageBox.Show("Deleted Successfully");
            else MessageBox.Show("Error: Delete Failed");
            updateDGVRubricLevel();
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

            if (Validation.validateTitle(txt_Details.Text))
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

            if (Validation.validateMarks(txt_MeasurementLevel.Text))
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

        private void txt_Details_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void txt_MeasurementLevel_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }
    }
}
