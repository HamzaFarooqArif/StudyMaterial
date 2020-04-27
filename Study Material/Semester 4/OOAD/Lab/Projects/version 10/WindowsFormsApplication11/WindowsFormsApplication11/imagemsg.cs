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
    public partial class imagemsg : UserControl
    {
        public imagemsg()
        {
            InitializeComponent();
        }
        public imagemsg(string name, Image img)
        {
            InitializeComponent();
            lbl_name.Text = name;
            image.Image = img;
        }


        private void imagemsg_Load(object sender, EventArgs e)
        {

        }
    }
}
