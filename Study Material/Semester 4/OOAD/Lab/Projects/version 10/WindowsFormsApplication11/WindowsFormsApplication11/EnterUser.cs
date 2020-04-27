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
    public partial class EnterUser : Form
    {
        public static EnterUser EnterUserForm = null;

        public string email;
        public string password;
        public EnterUser()
        {
            InitializeComponent();
        }
        public void setname(string name)
        {
            lbl_name.Text = name;
        }

        private void EnterUser_Load(object sender, EventArgs e)
        {
            EnterUser.EnterUserForm = this;
            flowLayoutPanel1.Controls.Clear();
            List<string> strnamer = new List<string>();
            Server.Service1 server = new Server.Service1();
            string[] strnamer1 = strnamer.ToArray();
 
            server.getUsersContacts(EnterUser.EnterUserForm.email, ref strnamer1);

            foreach (string s in strnamer1)
            {
                UserControl4 uc = new UserControl4(s);
                flowLayoutPanel1.Controls.Add(uc);

            }
        }

        private void lbl_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            server.SOfflineUser(lbl_name.Text );
            EnterUserForm = this;
            if (LoginUser.LoginUserForm == null)
            {
                LoginUser.LoginUserForm = new LoginUser();
            }

            this.Hide();
            LoginUser.LoginUserForm.Show();
        }

        public void setUserFormAttr(string passedEmail, string passedPassword)
        {
            email = passedEmail;
            password = passedPassword;
        }

        private void btn_Deactivate_Click(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            bool isPassed;
            bool Passed;

            server.DeactivateMyAccount(email, password, out isPassed, out Passed);

            EnterUserForm = this;
            if (LoginUser.LoginUserForm == null)
            {
                LoginUser.LoginUserForm = new LoginUser();
            }

            this.Hide();
            LoginUser.LoginUserForm.Show();

        }

        public void refreshComponents()
        {
            lbl_name.Text = email;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<string> strnamer = new List<string>();
            Server.Service1 server = new Server.Service1();
            string[] strnamer1 = strnamer.ToArray();
        

            
            server.getUsersContacts(EnterUser.EnterUserForm.email, ref strnamer1);

            foreach (string s in strnamer1)
            {
                UserControl4 uc = new UserControl4(s);
                flowLayoutPanel1.Controls.Add(uc);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_GroupChat_Click(object sender, EventArgs e)
        {
            if(UsersForGroupChat.usersforgroupchat == null)
            {
                UsersForGroupChat n = new UsersForGroupChat();
                UsersForGroupChat.usersforgroupchat = n;
            }

            UsersForGroupChat.usersforgroupchat.setname(lbl_name.Text);
            UsersForGroupChat.usersforgroupchat.Show();
            this.Hide();
        }

        
    }
}
