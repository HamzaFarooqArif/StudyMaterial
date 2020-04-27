using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cmdRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            this.Hide();
            registration.Show();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            bool isValidUser;
            bool isValidUserPassed;
            server.isValidUser(txtUserName.Text, txtPassword.Text, out isValidUser, out isValidUserPassed);
            if (isValidUser)
            {
                MessageBox.Show("valid");
            }
            else {
                MessageBox.Show("Invalid User");
            }
            
        }
    }
}
