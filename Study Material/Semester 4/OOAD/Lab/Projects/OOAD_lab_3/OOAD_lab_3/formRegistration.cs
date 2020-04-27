using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace OOAD_lab_3
{
    public partial class formRegistration : Form
    {
        public static formRegistration reg_form = null;
        public formRegistration()
        {
            InitializeComponent();
        }

        private void lbl_Password_Click(object sender, EventArgs e)
        {

        }

        private void lnk_formLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reg_form = this;
            if(formLogin.login_form == null)
            {
                formLogin.login_form = new formLogin();
            }

            this.Hide();
            formLogin.login_form.Show();

        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            bool exists = false;

            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                lbl_info.Text = "Error: Enter  Credentials";
                lbl_info.ForeColor = System.Drawing.Color.Red;
            }
            else if (Users.userList == null)
            {
                Users.userList = new ArrayList();

                User U = new User();
                U.UserName = txt_UserName.Text;
                U.Password = txt_Password.Text;

                Users.userList.Add(U);

                lbl_info.Text = "Registration Successful";
                lbl_info.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                foreach (User u in Users.userList)
                {
                    if (u.UserName == txt_UserName.Text && u.Password == txt_Password.Text)
                    {
                        lbl_info.Text = "Error: User Already Exists";
                        lbl_info.ForeColor = System.Drawing.Color.Red;

                        exists = true;
                    }
                }

                if(exists == false)
                {
                    User U = new User();
                    U.UserName = txt_UserName.Text;
                    U.Password = txt_Password.Text;

                    Users.userList.Add(U);

                    lbl_info.Text = "Registration Successful";
                    lbl_info.ForeColor = System.Drawing.Color.LimeGreen;
                }
            }

        }
    }
}
