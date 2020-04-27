using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class EnterAdmin : Form
    {
        public static EnterAdmin EnterAdminForm = null;
        public EnterAdmin()
        {
            InitializeComponent();
        }

        private void EnterAdmin_Load(object sender, EventArgs e)
        {
            EnterAdmin.EnterAdminForm = this;

            List<string> strnamer = new List<string>();
            List<string> strpasswordr = new List<string>();
            List<string> strnamep = new List<string>();
            List<string> strpasswordp = new List<string>();
            List<string> strnames = new List<string>();
            List<string> strpasswords = new List<string>();
            Server.Service1 server = new Server.Service1();
            string[] strnamer1 = strnamer.ToArray();
            string[] strpasswordr1 = strpasswordr.ToArray();
            string[] strnamep1 = strnamep.ToArray();
            string[] strpasswordp1 = strpasswordp.ToArray();
            string[] strnames1 = strnames.ToArray();
            string[] strpasswords1 = strpasswords.ToArray();
            server.SPassRegisteredUsersname(ref strnamer1);
            server.SPassRegisteredUserspassword(ref strpasswordr1);
            int idx = 0;
        
            foreach (string s in strnamer1)
            {
                UserControl1 uc = new UserControl1(s, strpasswordr1[idx]);
                flowLayoutPanel1.Controls.Add(uc);
                idx++;

            }
            server.SPassToBeRegisteredUsersname(ref strnamep1);
            server.SPassToBeRegisteredUserspassword(ref strpasswordp1);
            idx = 0;
            foreach (string s in strnamep1)
            {
                UserControl2 uc = new UserControl2(s, strpasswordp1[idx]);
                flowLayoutPanel2.Controls.Add(uc);
                idx++;

            }

            server.SPassSuspendedUsersname(ref strnames1);
            server.SPassSuspendedUserspassword(ref strpasswords1);
            idx = 0;
            foreach (string s in strnames1)
            {
                UserControl3 uc = new UserControl3(s, strpasswords1[idx]);
                flowLayoutPanel3.Controls.Add(uc);
                idx++;

            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            List<string> strnamer = new List<string>();
            List<string> strpasswordr = new List<string>();
            List<string> strnamep = new List<string>();
            List<string> strpasswordp = new List<string>();
            List<string> strnames = new List<string>();
            List<string> strpasswords = new List<string>();
            Server.Service1 server = new Server.Service1();
            string[] strnamer1 = strnamer.ToArray();
            string[] strpasswordr1 = strpasswordr.ToArray();
            string[] strnamep1 = strnamep.ToArray();
            string[] strpasswordp1 = strpasswordp.ToArray();
            string[] strnames1 = strnames.ToArray();
            string[] strpasswords1 = strpasswords.ToArray();
            server.SPassRegisteredUsersname(ref strnamer1);
            server.SPassRegisteredUserspassword(ref strpasswordr1);
            int idx = 0;
            foreach (string s in strnamer1)
            {
                UserControl1 uc = new UserControl1(s, strpasswordr1[idx]);
                flowLayoutPanel1.Controls.Add(uc);
                idx++;

            }
            server.SPassToBeRegisteredUsersname(ref strnamep1);
            server.SPassToBeRegisteredUserspassword(ref strpasswordp1);
            idx = 0;
            foreach (string s in strnamep1)
            {
                UserControl2 uc = new UserControl2(s, strpasswordp1[idx]);
                flowLayoutPanel2.Controls.Add(uc);
                idx++;

            }

            server.SPassSuspendedUsersname(ref strnames1);
            server.SPassSuspendedUserspassword(ref strpasswords1);
            idx = 0;
            foreach (string s in strnames1)
            {
                UserControl3 uc = new UserControl3(s, strpasswords1[idx]);
                flowLayoutPanel3.Controls.Add(uc);
                idx++;

            }
        }

        private void lbl_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EnterAdminForm = this;
            if (LoginAdmin.LoginAdminForm == null)
            {
                LoginAdmin.LoginAdminForm = new LoginAdmin();
            }
            
            this.Hide();
            LoginAdmin.LoginAdminForm.Show();
        }
    }
}
