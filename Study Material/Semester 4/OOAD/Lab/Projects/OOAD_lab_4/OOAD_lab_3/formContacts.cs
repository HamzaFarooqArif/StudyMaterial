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
    public partial class formContacts : Form
    {
        public static formContacts contacts_form = null;
        public formContacts()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Contact c = new Contact();
            c.Name = txtName.Text;
            c.Phone = txtPhone.Text;
            MyUtil.loggedUser.Contacts.Add(c);

            BindingSource source = new BindingSource();
            source.DataSource = MyUtil.loggedUser.Contacts;
            grdContact.DataSource = source;
        }

        private void formContacts_Load(Object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            contacts_form = this;
            if (formLogin.login_form == null)
            {
                formLogin.login_form = new formLogin();
            }

            this.Hide();
            formLogin.login_form.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            source.DataSource = MyUtil.loggedUser.Contacts;
            grdContact.DataSource = source;
        }

        private void formContacts_Activated(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            BindingSource source = new BindingSource();
            source.DataSource = MyUtil.loggedUser.Contacts;
            grdContact.DataSource = source;
        }
    }
}
