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
    public partial class CLO_Form : Form
    {
        private static CLO_Form clo_Form = null;
        private static Clo currentObject = new Clo("Empty");
        public static CLO_Form getInstance()
        {
            if (clo_Form == null)
            {
                clo_Form = new CLO_Form();
            }
            clo_Form.ClearControls(clo_Form);
            Navbar nav = new Navbar("CLO_Form");
            clo_Form.flowLayoutPanel1.Controls.Add(nav);
            clo_Form.updateDGVClo();
            return clo_Form;
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
        private CLO_Form()
        {
            InitializeComponent();
        }

        private void CLO_Form_Load(object sender, EventArgs e)
        {

        }
        private void updateDGVClo()
        {
            dgv_Clo.Rows.Clear();
            List<Clo> cloList = Clo.retrieveClos();
            foreach (Clo cl in cloList)
            {
                int n = dgv_Clo.Rows.Add();
                dgv_Clo.Rows[n].Cells[0].Value = cl.Id;
                dgv_Clo.Rows[n].Cells[1].Value = cl.Name;
                dgv_Clo.Rows[n].Cells[2].Value = cl.DateCreated.ToString();
                dgv_Clo.Rows[n].Cells[3].Value = cl.DateUpdated.ToString();
            }
        }
        private void loadCurrentObject()
        {
            txt_Name.Text = currentObject.Name;
        }

        private void setCurrentObject()
        {
            currentObject.Name = txt_Name.Text;
            currentObject.DateUpdated = DateTime.Now;
        }
        private void loadBlank()
        {
            txt_Name.Clear();
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(txt_Name.Text) ||
                !validateForm()
              ) return true;
            else return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            currentObject.Name = txt_Name.Text;
            if (Clo.addClo(currentObject) == 1) MessageBox.Show("Added Successfully");
            else MessageBox.Show("Error: Add Failed");

            updateDGVClo();
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
                setCurrentObject();
                int msg = Clo.addClo(currentObject);
                if (msg == 0) MessageBox.Show("Error: Update Unsuccessful!");
                if (msg == 1) MessageBox.Show("Added Successfully!");
                if (msg == 2) MessageBox.Show("Updated Successfully!");
                updateDGVClo();
                loadBlank();
                currentObject.Id = -1;
            }
        }

        private void dgv_Clo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                currentObject.Id = Convert.ToInt32(dgv_Clo.Rows[e.RowIndex].Cells["Column1"].Value);
                currentObject.Name = dgv_Clo.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();

                Clo clo = Clo.getClobyId(currentObject.Id);

                currentObject.DateCreated = clo.DateCreated;
                currentObject.DateUpdated = clo.DateUpdated;

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
            if (Clo.deleteCloById(currentObject.Id)) MessageBox.Show("Deleted Successfully");
            else MessageBox.Show("Error: Delete Failed");
            updateDGVClo();
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
            return isValid;
        }
    }
}
