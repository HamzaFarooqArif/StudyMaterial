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
    public partial class Class_Attendance_Form : Form
    {
        private static Class_Attendance_Form classAttendanceForm = null;
        private static ClassAttendance currentObject = new ClassAttendance();

        public static Class_Attendance_Form getInstance()
        {
            if (classAttendanceForm == null)
            {
                classAttendanceForm = new Class_Attendance_Form();
            }
            Navbar nav = new Navbar("ClassAttendance_Form");
            classAttendanceForm.flowLayoutPanel1.Controls.Add(nav);
            classAttendanceForm.updateDGVClassAttendance();
            return classAttendanceForm;
        }

        public Class_Attendance_Form()
        {
            InitializeComponent();
        }
        private void updateDGVClassAttendance()
        {
            dgv_ClassAttendance.Rows.Clear();
            List<ClassAttendance> classAttendanceList = ClassAttendance.retrieveClassAttendance();
            foreach (ClassAttendance cl in classAttendanceList)
            {
                int n = dgv_ClassAttendance.Rows.Add();
                dgv_ClassAttendance.Rows[n].Cells[0].Value = cl.Id;
                dgv_ClassAttendance.Rows[n].Cells[1].Value = cl.AttendanceDate.ToShortDateString();
            }
        }
        private void loadCurrentObject()
        {
            dtp_ClassAttendance.Value = currentObject.AttendanceDate;
        }
        private void setCurrentObject()
        {
            currentObject.AttendanceDate = dtp_ClassAttendance.Value;
        }
        private void loadBlank()
        {
            dtp_ClassAttendance.Value = DateTime.Now;
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(dtp_ClassAttendance.Text)
              ) return true;
            else return false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Form1.getInstance().Show();
            this.Hide();
        }

        private void Class_Attendance_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }

            currentObject.AttendanceDate = dtp_ClassAttendance.Value;

            if (ClassAttendance.addClassAttendance(currentObject) == 1) MessageBox.Show("Added Successfully");
            else MessageBox.Show("Error: Add Failed");

            updateDGVClassAttendance();
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
                int msg = ClassAttendance.addClassAttendance(currentObject);
                if (msg == 0) MessageBox.Show("Error: Update Unsuccessful!");
                if (msg == 1) MessageBox.Show("Added Successfully!");
                if (msg == 2) MessageBox.Show("Updated Successfully!");
                updateDGVClassAttendance();
                loadBlank();
                currentObject.Id = -1;
            }
        }

        private void dgv_ClassAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                currentObject.Id = Convert.ToInt32(dgv_ClassAttendance.Rows[e.RowIndex].Cells["Column1"].Value);
                
                ClassAttendance classAttendance = ClassAttendance.getClassAttendanceById(currentObject.Id);
                currentObject.AttendanceDate= classAttendance.AttendanceDate;
                
                loadCurrentObject();
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
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
            if (ClassAttendance.deleteClassAttendanceById(currentObject.Id)) MessageBox.Show("Deleted Successfully");
            else MessageBox.Show("Error: Delete Failed");
            updateDGVClassAttendance();
            loadBlank();
            currentObject.Id = -1;
        }
    }
}
