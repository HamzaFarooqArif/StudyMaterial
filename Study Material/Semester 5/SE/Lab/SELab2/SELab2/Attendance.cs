using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab2
{
    /// <summary>
    /// Attendance class creates Attendance type objects for Employees
    /// </summary>   
    class Attendance
    {
        /// <summary>
        /// Data members of Attendance class
        /// </summary>
        public static DateTime todayDate = DateTime.Now;

        private static int attenceId = 0;
        private DateTime loginTime;
        private DateTime logoutTime;
        private DateTime attendanceDate;

        /// <summary>
        /// Mutators of Attendance class
        /// </summary>
        public int AttenceId
        {
            get
            {
                return attenceId;
            }

            set
            {
                attenceId = value;
            }
        }
        public DateTime AttendanceDate
        {
            get
            {
                return attendanceDate;
            }

            set
            {
                attendanceDate = value;
            }
        }

        public DateTime LoginTime
        {
            get
            {
                return loginTime;
            }

            set
            {
                loginTime = value;
            }
        }

        public DateTime LogoutTime
        {
            get
            {
                return logoutTime;
            }

            set
            {
                logoutTime = value;
            }
        }

        public Attendance()
        {
            attenceId++;
            AttendanceDate = todayDate;
            LoginTime = new DateTime(1, 1, 1);
            LogoutTime = new DateTime(1, 1, 1);
        }

        /// <summary>
        /// Calculates the total time that employee has spent in office from login to logout
        /// </summary>
        /// <returns>Timespan of total office working hours</returns>
        public TimeSpan getOfficeTime()
        {
            TimeSpan t = new TimeSpan(0, 0, 1);
            TimeSpan t1 = new TimeSpan(0, 0, 2);
            
            DateTime d = new DateTime(1, 1, 2);
            DateTime d1 = new DateTime(1, 1, 1);

            //Employee marked both Login and Logout
            if (loginTime > d && LogoutTime > loginTime)
            {
                t = LogoutTime - LoginTime;
                return t;
            }

            //Employee marked only Login and not Logout
            else if (loginTime > d && logoutTime == d1)
            {
                return t;
            }

            //Employee marked not yet marked Login or Logout
            else
            {
                return t1;
            }
        }

    }
}
