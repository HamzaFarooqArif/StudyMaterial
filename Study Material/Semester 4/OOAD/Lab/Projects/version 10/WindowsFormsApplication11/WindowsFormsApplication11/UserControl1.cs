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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(string email, string password)
        {
            InitializeComponent();
            lbl_Name.Text = email;
            lbl_Password.Text = password;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void btn_suspend_Click(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            bool ispassed;
            bool passed;
            server.SSuspendUser(lbl_Name.Text, lbl_Password.Text, out passed, out ispassed);

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            bool passed;
            bool ispassed;
            server.SDeleteUser(lbl_Name.Text, lbl_Password.Text, out passed, out ispassed);
        }
    }
}
