using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_MiniProject
{
    public partial class Navbar : UserControl
    {
        private static string currentForm = null;
        public Navbar(string formName)
        {
            InitializeComponent();
            currentForm = formName;
        }
        private void hideCurrentForm()
        {
            if (currentForm == "Index_Form") Form1.getInstance().Hide();
            if (currentForm == "Assessment_Form") Assessment_Form.getInstance().Hide();
            if (currentForm == "AssessmentComponent_Form") AssessmentComponent_Form.getInstance().Hide();
            if (currentForm == "ClassAttendance_Form") Class_Attendance_Form.getInstance().Hide();
            if (currentForm == "CLO_Form") CLO_Form.getInstance().Hide();
            if (currentForm == "Reports_Form") Reports_Form.getInstance().Hide();
            if (currentForm == "Rubric_Form") Rubric_Form.getInstance().Hide();
            if (currentForm == "RubricLevel_Form") RubricLevel_Form.getInstance().Hide();
            if (currentForm == "Student_Form") Student_Form.getInstance().Hide();
            if (currentForm == "StudentAttendance_Form") StudentAttendance_Form.getInstance().Hide();
            if (currentForm == "StudentResult_Form") StudentResult_Form.getInstance().Hide();
        }
        private void btn_Student_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                Student_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
            
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                StudentResult_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }

        private void btn_Attendance_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                StudentAttendance_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
            
        }

        private void btn_ClassAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                Class_Attendance_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }

        private void btn_Assessment_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                Assessment_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }

        private void btn_AssessmentComponent_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                AssessmentComponent_Form.getInstance().Show();
            }
            catch(ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }

        private void btn_CLO_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                CLO_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }

        private void btn_Rubric_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                Rubric_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }

        private void btn_RubricLevel_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                RubricLevel_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            try
            {
                hideCurrentForm();
                Reports_Form.getInstance().Show();
            }
            catch (ArgumentNullException ex)
            {
                Form1.getInstance().Show();
            }
        }
    }
}
