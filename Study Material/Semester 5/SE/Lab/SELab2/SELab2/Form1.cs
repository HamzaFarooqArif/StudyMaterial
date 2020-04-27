using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SELab2
{
    public partial class Form1 : Form
    {
        private static Form1 form1 = null;


        /// <summary>
        /// Singleton Design Pattern Implementation
        /// </summary>
        /// <returns>Form1 Instance</returns>
        public static Form1 getInstance()
        {
            if (form1 == null)
            {
                form1 = new Form1();
                return form1;
            }
            else
            {
                return form1;
            }
        }
        private Form1()
        {
            InitializeComponent();
            /*----------Date Initializiation----------*/
            string dateStr = "Today Date: ";
            dateStr += DateTime.Now.ToString();
                
            label1.Text = dateStr;
            /*----------Date Initializiation----------*/

            /*----------Employee Initializiation----------*/
            Payroll.getInstance();

            string str = "000";
            for(int i = 0; i < 3; i++)
            {
                if (i < 10) str = "00";
                else if (i < 100) str = "0";
                else if (i < 1000) str = "";

                Employee e = new Employee();
                e.Name = "EMP-" + str + i.ToString();

                Payroll.getInstance().EmployeeList.Add(e);
            }

            foreach (Employee e in Payroll.getInstance().EmployeeList)
            {
                comboBox1.Items.Add(e.Name);
            }
            /*----------Employee Initializiation----------*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3.getInstance().Show();
            Form1.getInstance().Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(checkDate(textBox1.Text) && checkDate("20" + textBox2.Text)))
            {
                MessageBox.Show("Invalid Input!");
            }
            else
            {
                string year = textBox1.Text.Substring(0, 4);
                string month = textBox1.Text.Substring(5, 2);
                string day = textBox1.Text.Substring(8, 2);
                string hour = textBox2.Text.Substring(0, 2);
                string min = textBox2.Text.Substring(3, 2);
                string sec = textBox2.Text.Substring(6, 2);

                DateTime d = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(min), Int32.Parse(sec));
                Attendance.todayDate = d;
                label1.Text = "Today Date: " + Attendance.todayDate.ToString();
                MessageBox.Show("Date Set To: " + Attendance.todayDate.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Employee emp in Payroll.getInstance().EmployeeList)
            {
                if (emp.Name == comboBox1.Text)
                {
                    bool attendanceFound = false;
                    foreach (Attendance atn in emp.AttendanceRecord)
                    {
                        if(atn.AttendanceDate.ToShortDateString() == Attendance.todayDate.ToShortDateString())
                        {
                            atn.LoginTime = Attendance.todayDate;
                            MessageBox.Show(atn.LoginTime.ToString());
                            attendanceFound = true;
                            break;
                        }
                    }

                    if(!attendanceFound)
                    {
                        Attendance a = new Attendance();
                        a.LoginTime = Attendance.todayDate;
                        emp.AttendanceRecord.Add(a);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!(checkDate(textBox3.Text) && checkDate(textBox4.Text)))
            {
                MessageBox.Show("Invalid Input!");
            }
            else
            {
                string year1 = textBox3.Text.Substring(0, 4);
                string month1 = textBox3.Text.Substring(5, 2);
                string day1 = textBox3.Text.Substring(8, 2);

                string year2 = textBox4.Text.Substring(0, 4);
                string month2 = textBox4.Text.Substring(5, 2);
                string day2 = textBox4.Text.Substring(8, 2);

                DateTime d1 = new DateTime(Int32.Parse(year1), Int32.Parse(month1), Int32.Parse(day1));
                DateTime d2 = new DateTime(Int32.Parse(year2), Int32.Parse(month2), Int32.Parse(day2));

                string strShow = d1.ToShortDateString();
                strShow += "   ";
                strShow += d2.ToShortDateString();
                MessageBox.Show(strShow);

                List<Employee> EmployeeList = Payroll.getInstance().ListOfEmployeesWithShortAttendance(d1, d2);

                Form2.getInstance().clearGridView();

                foreach (Employee emp in EmployeeList)
                {
                    Form2.getInstance().addToGridView(emp.EmployeeId, emp.Name, emp.CNIC, emp.MonthlySalary.ToString(), emp.EmailId, emp.MailingAddress);
                }

                Form2.getInstance().Show();
                Form1.getInstance().Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Employee emp in Payroll.getInstance().EmployeeList)
            {
                if (emp.Name == comboBox1.Text)
                {
                    foreach (Attendance atn in emp.AttendanceRecord)
                    {
                        atn.LogoutTime = Attendance.todayDate;
                        MessageBox.Show(atn.LogoutTime.ToString());
                        break;
                    }
                }
            }
        }

        public bool checkDate(string date)
        {
            if(date.Length != 10)
            {
                return false;
            }

            if(!(isInt(date[0]) && isInt(date[1]) && isInt(date[2]) && isInt(date[3]) && isInt(date[5]) && isInt(date[6]) && isInt(date[8]) && isInt(date[9])))
            {
                return false;
            }

            return true;


        }

        public bool isInt(char chr)
        {
            if ((int)chr >= 48 && (int)chr <= 57)
            {
                return true;
            }
            return false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (Employee emp in Payroll.getInstance().EmployeeList)
            {
                comboBox1.Items.Add(emp.Name);
            }
        }
    }
        
    }
