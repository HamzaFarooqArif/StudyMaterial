using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraCapture
{
    public partial class ColorForm : Form
    {
        private static List<ColorForm> _instance;
        public int[] lower = {0, 0, 0};
        public int[] upper = {0, 0, 0};
        public static ColorForm getInstance(int idx, List<int> vals)
        {
            if (_instance == null)
            {
                _instance = new List<ColorForm>();
                ColorForm colorForm = new ColorForm(vals);
                _instance.Add(colorForm);
            }
            if (_instance.Count == idx)
            {
                ColorForm colorForm= new ColorForm(vals);
                _instance.Add(colorForm);
            }
            return _instance[idx];
        }

        public static ColorForm getInstance(int idx)
        {
            if (_instance == null)
            {
                _instance = new List<ColorForm>();
                ColorForm colorForm = new ColorForm();
                _instance.Add(colorForm);
            }
            if (_instance.Count == idx)
            {
                ColorForm colorForm = new ColorForm();
                _instance.Add(colorForm);
            }
            return _instance[idx];
        }
        private ColorForm()
        {
            InitializeComponent();
        }
        private ColorForm(List<int> hsvList)
        {
            InitializeComponent();

            lower[0] = hsvList[0];
            lower[1] = hsvList[1];
            lower[2] = hsvList[2];
            upper[0] = hsvList[3];
            upper[1] = hsvList[4];
            upper[2] = hsvList[5];

            trackBar1.Value = lower[0];
            trackBar2.Value = lower[1];
            trackBar3.Value = lower[2];
            trackBar4.Value = upper[0];
            trackBar5.Value = upper[1];
            trackBar6.Value = upper[2];

            textBox1.Text = lower[0].ToString();
            textBox2.Text = lower[1].ToString();
            textBox3.Text = lower[2].ToString();
            textBox4.Text = upper[0].ToString();
            textBox5.Text = upper[1].ToString();
            textBox6.Text = upper[2].ToString();

        }

        private void ColorForm1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lower[0] = trackBar1.Value;
            textBox1.Text = lower[0].ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lower[1] = trackBar2.Value;
            textBox2.Text = lower[1].ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            lower[2] = trackBar3.Value;
            textBox3.Text = lower[2].ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            upper[0] = trackBar4.Value;
            textBox4.Text = upper[0].ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            upper[1] = trackBar5.Value;
            textBox5.Text = upper[1].ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            upper[2] = trackBar6.Value;
            textBox6.Text = upper[2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
