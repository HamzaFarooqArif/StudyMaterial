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
    public partial class Rubric_Form : Form
    {
        private static Rubric_Form rubric_Form = null;
        private static Rubric currentObject = new Rubric("Empty", -1);

        public static Rubric_Form getInstance()
        {
            if (rubric_Form == null)
            {
                rubric_Form = new Rubric_Form();
            }
            //-------------------------------------------------------------------------------
            rubric_Form.ClearControls(rubric_Form);
            Navbar nav = new Navbar("Rubric_Form");
            rubric_Form.flowLayoutPanel1.Controls.Add(nav);
            rubric_Form.updateDGVRubric();
            rubric_Form.cb_Clo.Items.Clear();
            List<Clo> cloList = Clo.retrieveClos();
            foreach (Clo cl in cloList)
            {
                rubric_Form.cb_Clo.Items.Add(cl.Name);
            }
            if(rubric_Form.cb_Clo.Items.Count > 0) rubric_Form.cb_Clo.SelectedItem = rubric_Form.cb_Clo.Items[0];
            //-------------------------------------------------------------------------------
            return rubric_Form;
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
        private Rubric_Form()
        {
            InitializeComponent();
        }

        private void updateDGVRubric()
        {
            dgv_Rubric.Rows.Clear();
            List<Rubric> rubricList = Rubric.retrieveRubrics();
            foreach (Rubric rb in rubricList)
            {
                int n = dgv_Rubric.Rows.Add();
                dgv_Rubric.Rows[n].Cells[0].Value = rb.Id;
                dgv_Rubric.Rows[n].Cells[1].Value = rb.Details;
                dgv_Rubric.Rows[n].Cells[2].Value = Clo.getClobyId(rb.CloId).Name;
            }
        }

        private void cb_Clo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Rubric_Form_Load(object sender, EventArgs e)
        {

        }
        private void loadCurrentObject()
        {
            txt_Details.Text = currentObject.Details;
            cb_Clo.Text = Clo.getClobyId(currentObject.CloId).Name;
        }
        private void setCurrentObject()
        {
            currentObject.Details = txt_Details.Text;
            currentObject.CloId = Clo.getClo(cb_Clo.Text).Id;
        }
        private void loadBlank()
        {
            txt_Details.Clear();
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(txt_Details.Text) ||
                string.IsNullOrWhiteSpace(cb_Clo.Text) ||
                !validateForm()
               ) return true;
            else return false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            currentObject.Id = -1;
            currentObject.Details = txt_Details.Text;
            currentObject.CloId = Clo.getClo(cb_Clo.Text).Id;

            if (currentObject.CloId == -1) MessageBox.Show("Warning: Select a valid CLO!");
            else
            {
                if (Rubric.addRubric(currentObject) == 1) MessageBox.Show("Added Successfully");
                else MessageBox.Show("Error: Add Failed");
            }
            updateDGVRubric();
            loadBlank();
            currentObject.Id = -1;
        }

        private void dgv_Rubric_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                currentObject.Id = Convert.ToInt32(dgv_Rubric.Rows[e.RowIndex].Cells["Column1"].Value);
                currentObject.Details = dgv_Rubric.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                currentObject.CloId = Clo.getClo(dgv_Rubric.Rows[e.RowIndex].Cells["Column3"].FormattedValue.ToString()).Id;

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
                if (currentObject.CloId == -1) MessageBox.Show("Warning: Select a valid CLO!");
                setCurrentObject();
                int msg = Rubric.addRubric(currentObject);
                if (msg == 0) MessageBox.Show("Error: Update Unsuccessful!");
                if (msg == 1) MessageBox.Show("Added Successfully!");
                if (msg == 2) MessageBox.Show("Updated Successfully!");
                updateDGVRubric();
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
            if (Rubric.deleteRubricById(currentObject.Id)) MessageBox.Show("Deleted Successfully");
            else MessageBox.Show("Error: Delete Failed");
            updateDGVRubric();
            loadBlank();
            currentObject.Id = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.getInstance().Show();
            this.Hide();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
            return isValid;
        }

        private void txt_Details_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }
    }
}
