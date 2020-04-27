using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        public UserControl3(string name, string password)
        {
            InitializeComponent();
            lbl_Name.Text = name;
            lbl_Password.Text = password;
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }
    }
}
