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
    public partial class OrSunao : Form
    {
        public static OrSunao OrSunaoForm = null;
        public OrSunao()
        {
            InitializeComponent();
        }

        private void registeradmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            OrSunaoForm = this;
            if (RegisterAdmin.RegisterAdminForm == null)
            {
                RegisterAdmin.RegisterAdminForm = new RegisterAdmin();
            }

            this.Hide();
            RegisterAdmin.RegisterAdminForm.Show();
        }

        private void loginadmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OrSunaoForm = this;
            if (LoginAdmin.LoginAdminForm == null)
            {
                LoginAdmin.LoginAdminForm = new LoginAdmin();
            }

          
            LoginAdmin.LoginAdminForm.Show();
            this.Hide();


        }

        private void registeruser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OrSunaoForm = this;
            if (RegisterUser.RegisterUserForm == null)
            {
                RegisterUser.RegisterUserForm = new RegisterUser();
            }

            this.Hide();
            RegisterUser.RegisterUserForm.Show();

        }

        private void loginuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OrSunaoForm = this;
            if (LoginUser.LoginUserForm == null)
            {
                LoginUser.LoginUserForm = new LoginUser();
            }

            this.Hide();
            LoginUser.LoginUserForm.Show();
        }

        private void OrSunao_Load(object sender, EventArgs e)
        {
            OrSunao.OrSunaoForm = this;
        }
    }
}
