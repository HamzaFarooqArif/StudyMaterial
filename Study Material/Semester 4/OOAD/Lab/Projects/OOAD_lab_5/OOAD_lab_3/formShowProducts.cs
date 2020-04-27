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
    public partial class formShowProducts : Form
    {
        public static formShowProducts ShowProducts_form = null;
        public formShowProducts()
        {
            InitializeComponent();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            source.DataSource = MyUtil.loggedUser.Products;
            grdShowProducts.DataSource = source;
        }

        private void lnkLoginForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowProducts_form = this;
            if (formLogin.login_form == null)
            {
                formLogin.login_form = new formLogin();
            }

            this.Hide();
            formLogin.login_form.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<Product> filteredProducts = new List<Product>();
           
            foreach (Product p in MyUtil.loggedUser.Products)
            {
                if(p.Category == cmbCategories.Text)
                {
                    filteredProducts.Add(p);
                }
            }

            BindingSource source = new BindingSource();
            source.DataSource = filteredProducts;
            grdShowProducts.DataSource = source;
        }
    }
}
