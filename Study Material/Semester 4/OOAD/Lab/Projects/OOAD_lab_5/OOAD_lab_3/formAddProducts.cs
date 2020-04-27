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
    public partial class formAddProducts : Form
    {
        public int totalProducts = 0;
        public static formAddProducts product_form = null;
        public formAddProducts()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Name = txtProductName.Text;
            p.Category = cmbCategories.Text;
            p.Price = txtPrice.Text;
            p.Quantity = Convert.ToDouble(txtQuantity.Text);
            MyUtil.loggedUser.Products.Add(p);

            totalProducts += Convert.ToInt32(p.Quantity);
            txtTotalProducts.Text = totalProducts.ToString();

        }

        private void lnkShowAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            product_form = this;
            if (formShowProducts.ShowProducts_form == null)
            {
                formShowProducts.ShowProducts_form = new formShowProducts();
            }

            this.Hide();
            formShowProducts.ShowProducts_form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            product_form = this;
            if (formLogin.login_form == null)
            {
                formLogin.login_form = new formLogin();
            }

            this.Hide();
            formLogin.login_form.Show();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
