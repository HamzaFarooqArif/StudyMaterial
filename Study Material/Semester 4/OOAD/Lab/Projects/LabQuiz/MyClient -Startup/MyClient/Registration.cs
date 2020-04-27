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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void cmdLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            this.Hide(); 
            login.Show();
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            server.registerUser(txtUserName.Text, txtPassword.Text);
            MessageBox.Show("User Registered");
        }
    }
}
