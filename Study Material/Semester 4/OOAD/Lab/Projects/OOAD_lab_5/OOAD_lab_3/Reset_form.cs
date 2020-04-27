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
    public partial class Reset_form : Form
    {
        public static Reset_form rest_form = null;
        public Reset_form()
        {
            InitializeComponent();
        }

        private void lnk_login_form_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rest_form = this;
            if (formLogin.login_form == null)
            {
                formLogin.login_form = new formLogin();
            }

            this.Hide();
            formLogin.login_form.Show();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            bool exist_flag = false;
            if (Users.userList != null)
            {
                foreach (User u in Users.userList)
                {
                    if (u.UserName == txt_Name.Text)
                    {
                        exist_flag = true;
                    }
                    if (exist_flag == true && u.SecretQuestion == cmbo_Secret_Questions.Text && u.Answer == txt_Answer.Text)
                    {
                        u.Password = "123";
                        lbl_info.Text = "Reset Successful";
                        lbl_info.ForeColor = System.Drawing.Color.LimeGreen;
                    }
                    else
                    {
                        lbl_info.Text = "User Doesn't exist/Invalid Question";
                        lbl_info.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                lbl_info.Text = "No User is Registered yet!!";
                lbl_info.ForeColor = System.Drawing.Color.Red;
            }
            
            
        }
    }
}
