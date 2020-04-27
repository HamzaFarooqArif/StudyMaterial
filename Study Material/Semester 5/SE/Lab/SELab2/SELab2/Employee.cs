using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab2
{
    class Employee
    {
        /// <summary>
        /// Data members of Employee class
        /// </summary>
        private string name;
        private string employeeId;
        private string cNIC;
        private List<Attendance> attendanceRecord;
        private double monthlySalary;
        private string emailId;
        private string mailingAddress;


        /// <summary>
        /// Null constructor of Employee Class
        /// </summary>
        public Employee()
        {
            Name = "";
            EmployeeId = "";
            CNIC = "";
            AttendanceRecord = new List<Attendance>();
            MonthlySalary = 0.0;
            EmailId = "";
            MailingAddress = "";

            Attendance e = new Attendance();
            AttendanceRecord.Add(e);

        }


        /// <summary>
        /// Mutators of Employee Class
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string EmployeeId
        {
            get
            {
                return employeeId;
            }

            set
            {
                employeeId = value;
            }
        }

        public string CNIC
        {
            get
            {
                return cNIC;
            }

            set
            {
                cNIC = value;
            }
        }

        internal List<Attendance> AttendanceRecord
        {
            get
            {
                return attendanceRecord;
            }

            set
            {
                attendanceRecord = value;
            }
        }

        public double MonthlySalary
        {
            get
            {
                return monthlySalary;
            }

            set
            {
                monthlySalary = value;
            }
        }

        public string EmailId
        {
            get
            {
                return emailId;
            }

            set
            {
                emailId = value;
            }
        }

        public string MailingAddress
        {
            get
            {
                return mailingAddress;
            }

            set
            {
                mailingAddress = value;
            }
        }

        
        /// <summary>
        /// Marks the attendance of Employee on appropriate Date
        /// </summary>
        /// <param name="sign">Sign for login or logout</param>
        /// <returns>True if Successfully performed operation and false otherwise</returns>
        public bool MarkAttendance(string sign)
        {
            foreach (Attendance attendance in AttendanceRecord)
            {
                if(attendance.AttendanceDate == Attendance.todayDate)
                {
                    if(sign == "login")
                    {
                        attendance.LoginTime = Attendance.todayDate;
                        return true;
                    }
                    else if (sign == "logout")
                    {
                        attendance.LogoutTime = Attendance.todayDate;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Calculates Timespan of working hours of an Employee in single day
        /// </summary>
        /// <param name="employeeId">Corresponding Input Id</param>
        /// <returns>Timespan of working hours of an Employee in single day</returns>
        public TimeSpan GetTotalService(string employeeId)
        {
            TimeSpan t = new TimeSpan();

            foreach(Attendance attendance in AttendanceRecord)
            {
                t += attendance.getOfficeTime();
            }
            return t;
        }

        /// <summary>
        /// Check if Employee is Male or Female
        /// </summary>
        /// <returns>True if Male and False otherwise</returns>
        public bool GetGender()
        {
            if (Int32.Parse(CNIC.Substring(12)) % 2 != 0)
            {
                return true;
            }
            return false;
        }
        
    }
}
