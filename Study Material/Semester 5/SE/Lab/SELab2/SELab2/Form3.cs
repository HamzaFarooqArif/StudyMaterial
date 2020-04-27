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
    public partial class Form3 : Form
    {
        private static Form3 form3 = null;

        public static Form3 getInstance()
        {
            if(form3 == null)
            {
                form3 = new Form3();
                return form3;
            }
            else
            {
                return form3;
            }
        }
        private Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!validateName(textBox1.Text))
            {
                MessageBox.Show("Invalid Name!");
            }
            else if(!validateCNIC(textBox2.Text))
            {
                MessageBox.Show("Invalid CNIC!");
            }
            else if(!isIntString(textBox3.Text))
            {
                MessageBox.Show("Invalid Salary!");
            }
            else
            {
                Employee emp = new Employee();

                emp.Name = textBox1.Text;
                emp.CNIC = textBox2.Text;
                emp.MonthlySalary = Convert.ToDouble(textBox3.Text);
                emp.EmailId = textBox4.Text;
                emp.MailingAddress = textBox5.Text;

                Payroll.getInstance().AddEmployee(emp);
                MessageBox.Show("Employee " + emp.Name + " Added!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1.getInstance().Show();
            Form3.getInstance().Hide();
        }

        public bool isInt(char chr)
        {
            if ((int)chr >= 48 && (int)chr <= 57)
            {
                return true;
            }
            return false;
        }

        public bool isIntString(string str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                if(!isInt(str[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool validateName(string studentName)
        {
            char prevChr = 'a';
            if (studentName.Length != 0)
            {
                if (studentName[0] == ' ' || studentName[studentName.Length - 1] == ' ')
                {
                    Console.WriteLine("Invalid Format!");
                    return false;
                }
                for (int i = 0; i < studentName.Length; i++)
                {
                    if (i > 0)
                    {
                        if (prevChr == ' ' && studentName[i] == ' ')
                        {
                            Console.WriteLine("Invalid! Consecutive spaces ");
                            return false;
                        }

                    }
                    if (!((int)studentName[i] >= 65 && (int)studentName[i] <= 90) && !((int)studentName[i] >= 97 && (int)studentName[i] <= 122) && !((int)studentName[i] == 32))
                    {
                        Console.WriteLine("Invalid Format!");
                        return false;
                    }
                    prevChr = studentName[i];
                }
            }
            else
            {
                Console.WriteLine("Invalid Format!");
                return false;
            }

            return true;
        }

        public bool validateCNIC(string cNIC)
        {
            if (cNIC.Length == 13)
            {
                for (int i = 0; i < cNIC.Length; i++)
                {
                    if (!(isInt(cNIC[i])))
                    {
                        Console.WriteLine("Invalid Characters in 'CNIC' ");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid 'CNIC' ");
                return false;
            }
            return true;
        }
    }
}
