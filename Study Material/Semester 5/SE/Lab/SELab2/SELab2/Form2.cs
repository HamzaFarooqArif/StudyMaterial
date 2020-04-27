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
    public partial class Form2 : Form
    {
        private static Form2 form2 = null;
        public static Form2 getInstance()
        {
            if(form2 == null)
            {
                form2 = new Form2();
                return form2;
            }
            else
            {
                return form2;
            }
        }
        private Form2()
        {
            InitializeComponent();
        }

        public void clearGridView()
        {
            dataGridView1.Rows.Clear();
        }
        public void addToGridView(string id, string name, string cnic, string salary, string email, string address)
        {
            dataGridView1.Rows.Add(id, name, cnic, salary, email, address);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1.getInstance().Show();
            Form2.getInstance().Hide();
        }
    }
}
