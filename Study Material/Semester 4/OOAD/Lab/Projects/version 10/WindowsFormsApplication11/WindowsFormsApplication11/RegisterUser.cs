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
    public partial class RegisterUser : Form
    {
        public static RegisterUser RegisterUserForm = null;
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void lnklbl_GoToMainPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUserForm = this;
            if (OrSunao.OrSunaoForm == null)
            {
                OrSunao.OrSunaoForm = new OrSunao();
            }

            this.Hide();
            OrSunao.OrSunaoForm.Show();
            
        }

        private void lnklbl_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUserForm = this;
            if (LoginUser.LoginUserForm == null)
            {
                LoginUser.LoginUserForm = new LoginUser();
            }

            this.Hide();
            LoginUser.LoginUserForm.Show();

        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if(txt_FirstName.Text == "" || txt_LastName.Text == "" || txt_Email.Text == "" || txt_Password.Text == "" || txt_SecretAnswer.Text == "" || txt_CNIC.Text == "" || txt_Contact.Text == "")
            {
                MessageBox.Show("invalid entries are present, empty data is not valid!");
                return;
            }
            Server.Service1 server = new Server.Service1();
            bool isregister;
            bool ispassed;
            server.SRegisterUser(txt_FirstName.Text, txt_LastName.Text, txt_Password.Text, txt_Email.Text, txt_Contact.Text, txt_CNIC.Text, txt_SecretQuestion.Text, txt_SecretAnswer.Text, out isregister, out ispassed);
            if(ispassed)
            {
                if(isregister)
                {
                    MessageBox.Show("Congratulations! You are a member of Or_Sunao now ");
                }
                else
                {
                    MessageBox.Show("oops ! you cant register with this id !");
                }
            }
            txt_FirstName.Clear();
            txt_LastName.Clear();
            txt_CNIC.Clear();
            txt_Contact.Clear();
            txt_Email.Clear();
            txt_Password.Clear();
            txt_SecretAnswer.Clear();
            txt_SecretQuestion.Text = "";
        }
    }
}
