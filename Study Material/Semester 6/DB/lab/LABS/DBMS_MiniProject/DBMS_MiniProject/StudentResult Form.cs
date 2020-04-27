using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DBMS_MiniProject
{
    public partial class StudentResult_Form : Form
    {
        private static StudentResult_Form studentResult_Form = null;
        private static StudentResult currentObject = new StudentResult(-1, -1, -1, DateTime.Now);

        public static StudentResult_Form getInstance()
        {
            if (studentResult_Form == null)
            {
                studentResult_Form = new StudentResult_Form();
            }
            //-------------------------------------------------------------------------------
            studentResult_Form.ClearControls(studentResult_Form);
            Navbar nav = new Navbar("StudentResult_Form");
            studentResult_Form.flowLayoutPanel1.Controls.Add(nav);
            studentResult_Form.updateDGVStudentResult();
            studentResult_Form.cb_Assessment.Items.Clear();
            studentResult_Form.cb_Student.Items.Clear();

            List<Assessment> assessmentList = Assessment.retrieveAssessments();
            foreach (Assessment ast in assessmentList)
            {
                studentResult_Form.cb_Assessment.Items.Add(ast.Title);
            }

            List<Student> studentList = Student.retrieveStudents();
            foreach (Student std in studentList)
            {
                studentResult_Form.cb_Student.Items.Add(std.RegistrationNumber);
            }
            if (studentResult_Form.cb_Assessment.Items.Count > 0) studentResult_Form.cb_Assessment.SelectedItem = studentResult_Form.cb_Assessment.Items[0];
            if (studentResult_Form.cb_Student.Items.Count > 0) studentResult_Form.cb_Student.SelectedItem = studentResult_Form.cb_Student.Items[0];
            //-------------------------------------------------------------------------------
            if (studentResult_Form.cb_Assessment.Items.Count > 0 && studentResult_Form.cb_Student.Items.Count > 0)
            {
                studentResult_Form.flp_Student.Controls.Clear();
                Assessment asta = StudentResult_Form.getAssessment();
                List<AssessmentComponent> assessmentComponentList = AssessmentComponent.retrieveAssessmentComponents(asta.Id);
                foreach (AssessmentComponent asca in assessmentComponentList)
                {
                    studentResultControl ctrl = new studentResultControl(asca, Rubric.getRubricById(asca.RubricId), Student.getStudentByRegistrationNumber(studentResult_Form.cb_Student.Text));
                    studentResult_Form.flp_Student.Controls.Add(ctrl);
                }
            }
            //-------------------------------------------------------------------------------
            return studentResult_Form;
        }
        public static Assessment getAssessment()
        {
            if (studentResult_Form.cb_Assessment.Items.Count > 0)
            {
                if (studentResult_Form.cb_Assessment.SelectedItem == null)
                {
                    studentResult_Form.cb_Assessment.SelectedItem = studentResult_Form.cb_Assessment.Items[0];
                }
                Assessment result = Assessment.getAssessment(studentResult_Form.cb_Assessment.SelectedItem.ToString());
                return result;
            }
            Assessment ast = new Assessment("Empty", -1, -1);
            return ast;
        }

        public StudentResult_Form()
        {
            InitializeComponent();
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
        private void updateDGVStudentResult()
        {
            dgv_StudentResult.Rows.Clear();
            List<StudentResult> studentResultList = StudentResult.retrieveStudentResults();
            foreach (StudentResult rslt in studentResultList)
            {
                int n = dgv_StudentResult.Rows.Add();
                dgv_StudentResult.Rows[n].Cells[0].Value = Student.getStudentById(rslt.StudentId).RegistrationNumber.ToString();
                dgv_StudentResult.Rows[n].Cells[1].Value = Assessment.getAssessmentById(AssessmentComponent.getAssessmentComponentById(rslt.AssessmentComponentId).AssessmentId).Title;
                dgv_StudentResult.Rows[n].Cells[2].Value = AssessmentComponent.getAssessmentComponentById(rslt.AssessmentComponentId).Name;
                dgv_StudentResult.Rows[n].Cells[3].Value = Rubric.getRubricById(RubricLevel.getRubricLevelById(rslt.RubricMeasurementId).RubricId).Details;
                dgv_StudentResult.Rows[n].Cells[4].Value = RubricLevel.getRubricLevelById(rslt.RubricMeasurementId).MeasurementLevel.ToString();
                dgv_StudentResult.Rows[n].Cells[5].Value = rslt.EvaluationDate.ToShortDateString();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Form1.getInstance().Show();
            this.Hide();
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

            foreach (studentResultControl control in flp_Student.Controls)
            {
                int temp = control.Confirm();
                if (temp == 1) added++;
                if (temp == 2) updated++;
            }
            updateDGVStudentResult();
            if (added > 0 && updated > 0) MessageBox.Show(added + " Result(s) Added\n" + updated + " Result(s) Updated");
            else if (added > 0) MessageBox.Show(added + " Result(s) Added");
            else if (updated > 0) MessageBox.Show(updated + " Result(s) Updated");
            else MessageBox.Show("0 Result(s) Affected");
        }

        private void cb_Assessment_SelectedIndexChanged(object sender, EventArgs e)
        {
            flp_Student.Controls.Clear();
            Assessment ast = StudentResult_Form.getAssessment();
            List<AssessmentComponent> assessmentComponentList = AssessmentComponent.retrieveAssessmentComponents(ast.Id);
            foreach (AssessmentComponent asc in assessmentComponentList)
            {
                studentResultControl ctrl = new studentResultControl(asc, Rubric.getRubricById(asc.RubricId), Student.getStudentByRegistrationNumber(cb_Student.Text));
                flp_Student.Controls.Add(ctrl);
            }
        }

        private void StudentResult_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (isBlank())
            {
                MessageBox.Show("Warning: Check Input Fields");
                return;
            }
            int result = 0;
            foreach (studentResultControl ctrl in flp_Student.Controls)
            {
                if (StudentResult.deleteStudentResult(Student.getStudentByRegistrationNumber(cb_Student.Text).Id, ctrl.getAssessmentComponent().Id))
                {
                    result++;
                }
            }
            updateDGVStudentResult();
            MessageBox.Show(result + " Result(s) Deleted");
        }

        private void cb_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            flp_Student.Controls.Clear();
            Assessment ast = StudentResult_Form.getAssessment();
            List<AssessmentComponent> assessmentComponentList = AssessmentComponent.retrieveAssessmentComponents(ast.Id);
            foreach (AssessmentComponent asc in assessmentComponentList)
            {
                studentResultControl ctrl = new studentResultControl(asc, Rubric.getRubricById(asc.RubricId), Student.getStudentByRegistrationNumber(cb_Student.Text));
                flp_Student.Controls.Add(ctrl);
            }
        }

        private void dgv_StudentResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                cb_Assessment.Text = dgv_StudentResult.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
                cb_Student.Text = dgv_StudentResult.Rows[e.RowIndex].Cells["Column1"].Value.ToString();

                flp_Student.Controls.Clear();
                Assessment ast = StudentResult_Form.getAssessment();
                List<AssessmentComponent> assessmentComponentList = AssessmentComponent.retrieveAssessmentComponents(ast.Id);
                foreach (AssessmentComponent asc in assessmentComponentList)
                {
                    studentResultControl ctrl = new studentResultControl(asc, Rubric.getRubricById(asc.RubricId), Student.getStudentByRegistrationNumber(cb_Student.Text));
                    flp_Student.Controls.Add(ctrl);
                }
            }
        }
        private bool isBlank()
        {
            if (
                string.IsNullOrWhiteSpace(cb_Assessment.Text) ||
                string.IsNullOrWhiteSpace(cb_Student.Text)
              ) return true;
            else return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Report.writeCloReport();
        }
    }
}
