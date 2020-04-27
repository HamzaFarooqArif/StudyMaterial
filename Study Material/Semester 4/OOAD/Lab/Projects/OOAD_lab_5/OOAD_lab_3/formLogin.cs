using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_lab_3
{
    public partial class formLogin : Form
    {
        public static formLogin login_form = null;
        public formLogin()
        {
            InitializeComponent();
        }

        private void lnk_formRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login_form = this;
            if(formRegistration.reg_form == null)
            {
                formRegistration.reg_form = new formRegistration();
            }
            
           // this.Hide();
            formRegistration.reg_form.Show();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            bool exists = false;
            bool login_success = false;

            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                lbl_info.Text = "Error: Enter Valid Credentials";
                lbl_info.ForeColor = System.Drawing.Color.Red;
            }

            else if (Users.userList == null)
            {
                lbl_info.Text = "Error: Invalid UserName/Password";
                lbl_info.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                foreach (User u in Users.userList)
                {
                    if (u.UserName == txt_UserName.Text && u.Password == txt_Password.Text)
                    {
                        lbl_info.Text = "Login Successful";
                        lbl_info.ForeColor = System.Drawing.Color.LimeGreen;

                        exists = true;

                        login_success = true;
                        MyUtil.loggedUser = u;

                    }
                }

                if(exists == false)
                {
                    lbl_info.Text = "Error: Invalid UserName/Password";
                    lbl_info.ForeColor = System.Drawing.Color.Red;
                }
            }

            if(login_success == true)
            {
                login_form = this;
                if (formContacts.contacts_form == null)
                {
                    formContacts.contacts_form = new formContacts();
                }

                this.Hide();
                formContacts.contacts_form.Show();
            }
            
        }

        private void lnk_Forgot_Password_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login_form = this;
            if (Reset_form.rest_form == null)
            {
                Reset_form.rest_form = new Reset_form();
            }

            this.Hide();
            Reset_form.rest_form.Show();
        }

        private void btnUserProducts_Click(object sender, EventArgs e)
        {

            bool exists = false;
            bool login_success = false;

            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                lbl_info.Text = "Error: Enter Valid Credentials";
                lbl_info.ForeColor = System.Drawing.Color.Red;
            }

            else if (Users.userList == null)
            {
                lbl_info.Text = "Error: Invalid UserName/Password";
                lbl_info.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                foreach (User u in Users.userList)
                {
                    if (u.UserName == txt_UserName.Text && u.Password == txt_Password.Text)
                    {
                        lbl_info.Text = "Login Successful";
                        lbl_info.ForeColor = System.Drawing.Color.LimeGreen;

                        exists = true;

                        login_success = true;
                        MyUtil.loggedUser = u;

                    }
                }

                if (exists == false)
                {
                    lbl_info.Text = "Error: Invalid UserName/Password";
                    lbl_info.ForeColor = System.Drawing.Color.Red;
                }
            }

            if (login_success == true)
            {
                login_form = this;
                if (formAddProducts.product_form == null)
                {
                    formAddProducts.product_form = new formAddProducts();
                }

                this.Hide();
                formAddProducts.product_form.Show();
            }

        }
    }
}
