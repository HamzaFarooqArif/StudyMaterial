using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Normalization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FunctionalDependency fd = new FunctionalDependency();
            fd.Left.Add("A");
            fd.Left.Add("B");
            fd.Right.Add("B");
            fd.Right.Add("C");
            fd.Right.Add("D");
            fd.Right.Add("E");
            fd.Right.Add("F");

            FunctionalDependency fd2 = new FunctionalDependency();
            fd2.Left.Add("A");
            fd2.Left.Add("C");
            fd2.Right.Add("B");
            fd2.Right.Add("C");
            fd2.Right.Add("D");

            List< FunctionalDependency > fdList = new List<FunctionalDependency>();
            fdList.Add(fd);
            fdList.Add(fd2);
            List<string> attrList = new List<string>();
            attrList.Add("A");

            fd.takeClosure(fdList, attrList);

            //MessageBox.Show(fd.breakDown().Count.ToString());

            

        }
    }
}
