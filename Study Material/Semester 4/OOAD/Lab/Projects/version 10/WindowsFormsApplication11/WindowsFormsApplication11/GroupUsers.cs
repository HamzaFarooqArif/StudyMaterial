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
    public partial class GroupUsers : UserControl
    {
        public static int numberofusers = 0;
        public bool state = false;
        public GroupUsers()
        {
            InitializeComponent();
        }

        public GroupUsers(string email)
        {
            InitializeComponent();
            lbl_Email.Text = email;
        }

        private void GroupUsers_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(this.state == false && numberofusers <= 4)
            {
                numberofusers++;
                Server.Service1 server = new Server.Service1();
                server.addusertogroup(EnterUser.EnterUserForm.email, lbl_Email.Text);
                this.state = true;
            }
        }
    }
}
