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
    public partial class StudentAttendance_Form : Form
    {
        private static StudentAttendance_Form studentAttendance_Form  = null;
        public static StudentAttendance_Form getInstance()
        {
            if (studentAttendance_Form == null)
            {
                studentAttendance_Form = new StudentAttendance_Form();
            }
            studentAttendance_Form.ClearControls(studentAttendance_Form);
            Navbar nav = new Navbar("StudentAttendance_Form");
            studentAttendance_Form.flowLayoutPanel1.Controls.Add(nav);
            studentAttendance_Form.refresh();
            studentAttendance_Form.updateDGVStudentAttendance();
            
            return studentAttendance_Form;
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
        public void refresh()
        {
            cb_ClassAttendance.Items.Clear();
            List<ClassAttendance> classAttendanceList = ClassAttendance.retrieveClassAttendance();
            foreach(ClassAttendance ca in classAttendanceList)
            {
                cb_ClassAttendance.Items.Add(ca.AttendanceDate.ToShortDateString());
            }

            if (studentAttendance_Form.cb_ClassAttendance.Items.Count > 0 && studentAttendance_Form.cb_ClassAttendance.Text == "")
            {
                studentAttendance_Form.cb_ClassAttendance.SelectedItem = studentAttendance_Form.cb_ClassAttendance.Items[0];
            }

            flp_StudentAttendance.Controls.Clear();
            List<Student> studentList = Student.retrieveActiveStudents();
            foreach(Student st in studentList)
            {
                if(!string.IsNullOrWhiteSpace(cb_ClassAttendance.Text))
                {
                    int month = Int32.Parse(cb_ClassAttendance.Text.Split('/')[0]);
                    int day = Int32.Parse(cb_ClassAttendance.Text.Split('/')[1]);
                    int year = Int32.Parse(cb_ClassAttendance.Text.Split('/')[2]);

                    DateTime date = new DateTime(year, month, day);
                    studentAttendanceControl ctrl = new studentAttendanceControl(st, ClassAttendance.getClassAttendanceByDate(date));
                    flp_StudentAttendance.Controls.Add(ctrl);
                }
            }
        }
        private StudentAttendance_Form()
        {
            InitializeComponent();
        }

        private void StudentAttendance_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassAttendance classAttendance = new ClassAttendance();
            int result = ClassAttendance.addClassAttendance(classAttendance);
            //if (result == 0) MessageBox.Show("Warning: Attendance Already Exists");
            studentAttendance_Form.refresh();
            cb_ClassAttendance.Text = classAttendance.AttendanceDate.ToShortDateString();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            int added = 0;
            int updated = 0;

            foreach (studentAttendanceControl control in flp_StudentAttendance.Controls)
            {
                int month = Int32.Parse(cb_ClassAttendance.Text.Split('/')[0]);
                int day = Int32.Parse(cb_ClassAttendance.Text.Split('/')[1]);
                int year = Int32.Parse(cb_ClassAttendance.Text.Split('/')[2]);
                DateTime date = new DateTime(year, month, day);

                int temp = control.Confirm(ClassAttendance.getClassAttendanceByDate(date));
                if (temp == 1) added++;
                if (temp == 2) updated++;
            }
            updateDGVStudentAttendance();
            if (added > 0 && updated > 0) MessageBox.Show(added + " Result(s) Added\n" + updated + " Result(s) Updated");
            else if (added > 0) MessageBox.Show(added + " Result(s) Added");
            else if (updated > 0) MessageBox.Show(updated + " Result(s) Updated");
            else MessageBox.Show("0 Result(s) Affected");
        }
        private void updateDGVStudentAttendance()
        {
            dgv_StudentAttendance.Rows.Clear();
            List<StudentAttendance> studentAttendanceList = StudentAttendance.retrieveStudentAttendances();
            foreach (StudentAttendance rslt in studentAttendanceList)
            {
                int n = dgv_StudentAttendance.Rows.Add();
                dgv_StudentAttendance.Rows[n].Cells[0].Value = ClassAttendance.getClassAttendanceById(rslt.AttendanceId).AttendanceDate.ToShortDateString();
                dgv_StudentAttendance.Rows[n].Cells[1].Value = Student.getStudentById(rslt.StudentId).RegistrationNumber.ToString();
                dgv_StudentAttendance.Rows[n].Cells[2].Value = Lookup.getLookupById(rslt.AttendanceStatus).Name;
            }
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(cb_ClassAttendance.Text)
              ) return true;
            else return false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Form1.getInstance().Show();
            this.Hide();
        }

        private void cb_ClassAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgv_StudentAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                cb_ClassAttendance.Text = dgv_StudentAttendance.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                
                flp_StudentAttendance.Controls.Clear();

                int month = Int32.Parse(cb_ClassAttendance.Text.Split('/')[0]);
                int day = Int32.Parse(cb_ClassAttendance.Text.Split('/')[1]);
                int year = Int32.Parse(cb_ClassAttendance.Text.Split('/')[2]);

                DateTime date = new DateTime(year, month, day);

                studentAttendanceControl ctrl = new studentAttendanceControl(Student.getStudentByRegistrationNumber(dgv_StudentAttendance.Rows[e.RowIndex].Cells["Column2"].Value.ToString()), ClassAttendance.getClassAttendanceByDate(date));
                ctrl.setLookup(Lookup.getLookup(dgv_StudentAttendance.Rows[e.RowIndex].Cells["Column3"].Value.ToString(), "ATTENDANCE_STATUS").Name);
                flp_StudentAttendance.Controls.Add(ctrl);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            int result = 0;
            foreach (studentAttendanceControl ctrl in flp_StudentAttendance.Controls)
            {
                int month = Int32.Parse(cb_ClassAttendance.Text.Split('/')[0]);
                int day = Int32.Parse(cb_ClassAttendance.Text.Split('/')[1]);
                int year = Int32.Parse(cb_ClassAttendance.Text.Split('/')[2]);

                DateTime date = new DateTime(year, month, day);

                if (StudentAttendance.deleteStudentAttendance(ClassAttendance.getClassAttendanceByDate(date).Id, Student.getStudentByRegistrationNumber(ctrl.getRegistration()).Id))
                {
                    result++;
                }
            }
            updateDGVStudentAttendance();
            MessageBox.Show(result + " Result(s) Deleted");
        }

        private void btn_Manually_Click(object sender, EventArgs e)
        {

        }
    }
}
