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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        public UserControl2(string name, string password)
        {
            InitializeComponent();
            lbl_Name.Text = name;
            lbl_Password.Text = password;
        }

        private void lbl_Name_Click(object sender, EventArgs e)
        {

        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            bool passed;
            bool ispassed;
            server.SPassUser(lbl_Name.Text, lbl_Password.Text, out passed, out ispassed);
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
    }
}
