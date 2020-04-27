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
    public partial class studentAttendanceControl : UserControl
    {
        private ClassAttendance currentClassAttendance = null;
        public studentAttendanceControl(Student student, ClassAttendance classAttendance)
        {
            InitializeComponent();

            currentClassAttendance = classAttendance;

            lbl_Registration.Text = student.RegistrationNumber.ToString();
            List<Lookup> lookupList = Lookup.retrieveLookups();
            foreach(Lookup lu in lookupList)
            {
                if(lu.Category.Equals("ATTENDANCE_STATUS"))
                {
                    cb_Lookup.Items.Add(lu.Name);
                }
            }
            cb_Lookup.SelectedItem = cb_Lookup.Items[0];
        }
        public int Confirm(ClassAttendance classAttendance)
        {
            StudentAttendance rslt = new StudentAttendance(-1, -1, -1);
            rslt.StudentId = Student.getStudentByRegistrationNumber(lbl_Registration.Text).Id;
            //rslt.AttendanceId = currentClassAttendance.Id;
            rslt.AttendanceId = classAttendance.Id;
            rslt.AttendanceStatus = Lookup.getLookup(cb_Lookup.Text, "ATTENDANCE_STATUS").LookupId;
            
            int result = StudentAttendance.addStudentAttendance(rslt, rslt);
            return result;
        }
        public void setLookup(string lookup)
        {
            cb_Lookup.Text = lookup;
        }
        public string getRegistration()
        {
            return lbl_Registration.Text;
        }
    }
}
