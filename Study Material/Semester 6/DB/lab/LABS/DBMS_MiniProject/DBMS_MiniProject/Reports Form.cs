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
    public partial class Reports_Form : Form
    {
        private static Reports_Form reports_Form = null;
        private static string path = Environment.CurrentDirectory;
        private static string fileName = "pdfdoc";
        public static Reports_Form getInstance()
        {
            if (reports_Form == null)
            {
                reports_Form = new Reports_Form();
            }
            reports_Form.ClearControls(reports_Form);
            Navbar nav = new Navbar("Reports_Form");
            reports_Form.flowLayoutPanel1.Controls.Add(nav);
            setCurrentAttributes(reports_Form);
            return reports_Form;
        }
        private static void setCurrentAttributes(Reports_Form reports_Form)
        {
            reports_Form.txt_Path.Text = path;
            reports_Form.txt_FileName.Text = fileName;
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
        private Reports_Form()
        {
            InitializeComponent();
        }
        private bool validateForm()
        {
            bool isValid = true;

            if (Validation.validateTitle(txt_FileName.Text))
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

        private void Reports_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_Path.Text = fbd.SelectedPath;
            }
        }

        private void txt_FileName_TextChanged(object sender, EventArgs e)
        {
            validateForm();
        }

        private void btn_CLO_Click(object sender, EventArgs e)
        {
            if(validateForm())
            {
                lbl_Status.Text = "Working. Please Wait";
                MessageBox.Show("Process Started!");
                Report.writeAssessmentReport(txt_Path.Text, txt_FileName.Text);
                lbl_Status.Text = "CLO Report Generated Successfully!";
            }
            else
            {
                MessageBox.Show("Error: Check Input Fields");
            }
        }

        private void btn_Assessment_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                lbl_Status.Text = "Working. Please Wait";
                MessageBox.Show("Process Started!");
                Report.writeAssessmentReport(txt_Path.Text, txt_FileName.Text);
                lbl_Status.Text = "Assessment Report Generated Successfully!";
            }
            else
            {
                MessageBox.Show("Error: Check Input Fields");
            }
        }
    }
}
