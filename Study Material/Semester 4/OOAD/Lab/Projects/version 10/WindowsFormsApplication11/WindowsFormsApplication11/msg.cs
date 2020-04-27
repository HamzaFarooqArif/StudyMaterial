using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class msg : UserControl
    {
        public msg()
        {
            InitializeComponent();
        }
        public msg(string message, string username)
        {
            InitializeComponent();
            textBox1.Text = message;
            lbl_username.Text = username;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void msg_Load(object sender, EventArgs e)
        {

        }
    }
}
