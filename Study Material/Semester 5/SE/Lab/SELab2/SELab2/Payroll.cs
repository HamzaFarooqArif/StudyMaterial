using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELab2
{
    /// <summary>
    /// Payroll class that has control of all employees
    /// </summary>
    class Payroll
    {
        /// <summary>
        /// Data members of Payroll class
        /// </summary>
        private List<Employee> employeeList;
        private static Payroll payRoll;

        /// <summary>
        /// Null constructor of Payroll class
        /// </summary>
        private Payroll()
        {
            EmployeeList = new List<Employee>();
        }

        /// <summary>
        /// Mutators of Payroll class
        /// </summary>
        internal List<Employee> EmployeeList
        {
            get
            {
                return employeeList;
            }

            set
            {
                employeeList = value;
            }
        }

        /// <summary>
        /// Add a given employee into EmployeeList
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>True if employee is successfully added in EmployeeList</returns>
        public bool AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
            foreach (Employee employe in EmployeeList)
            {
                if(employee != employe)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Getter for ListOfEmployees
        /// </summary>
        public List<Employee> ListOfEmployees()
        {
            return employeeList;
        }

        /// <summary>
        /// Filter Employees that have short attendance with respect to others
        /// </summary>
        /// <param name="startDate">Starting Date</param>
        /// <param name="endDate">Ending Date</param>
        /// <returns>EmployeeList that includes employees with short attendance</returns>
        public List<Employee> ListOfEmployeesWithShortAttendance(DateTime startDate, DateTime endDate)
        {
            List<Employee> resultList = new List<Employee>();

            foreach(Employee e in employeeList)
            {
                DateTime d = startDate;
                int day = 0;
                while(d < endDate)
                {
                    d = new DateTime(startDate.Year, startDate.Month, startDate.Day + day);
                    foreach (Attendance atn in e.AttendanceRecord)
                    {
                        if(atn.AttendanceDate.ToShortDateString() == d.ToShortDateString())
                        {
                            TimeSpan t1 = new TimeSpan(8, 0, 0);
                            TimeSpan t2 = new TimeSpan(0, 0, 1);
                            TimeSpan t3 = new TimeSpan(0, 0, 2);

                            if ((atn.getOfficeTime() < t1 && atn.getOfficeTime() > t3))
                            {
                                resultList.Add(e);
                            }
                            else if((atn.getOfficeTime() == t2))
                            {
                                resultList.Add(e);
                            }
                        }
                    }
                    day++;
                }
            }

            return resultList;
        }
        
        /// <summary>
        /// Singleton Design Pattern Implementation
        /// </summary>
        /// <returns>Payroll Instance</returns>
        public static Payroll getInstance()
        {
            if(payRoll == null)
            {
                payRoll = new Payroll();
                return payRoll;
            }
            else
            {
                return payRoll;
            }
            
        }


    }
}
