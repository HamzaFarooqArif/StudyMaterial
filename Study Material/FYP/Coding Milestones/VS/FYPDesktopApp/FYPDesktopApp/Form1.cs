using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using DirectShowLib;
using System.IO.Ports;
using System.Threading;

namespace FYPDesktopApp
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture1 = null;
        private Mat _frame1;
        private bool isCapturing1 = false;

        private VideoCapture _capture2 = null;
        private Mat _frame2;
        private bool isCapturing2 = false;

        private delegate void SetTextDeleg(string text);
        //public static List<DsDevice> _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).ToList();


        public Form1()
        {
            InitializeComponent();
            
            BindingSource ports = new BindingSource();
            ports.DataSource = SerialPort.GetPortNames().ToList();
            CB_PortNames.DataSource = ports;

            BindingSource cameras1 = new BindingSource();
            cameras1.DataSource = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).Select(v=>v.Name).ToList();
            CB_CameraNames.DataSource = cameras1;

            BindingSource cameras2 = new BindingSource();
            cameras2.DataSource = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).Select(v => v.Name).ToList();
            CB_CameraNames2.DataSource = cameras2;

        }
        private void ProcessFrame1(object sender, EventArgs arg)
        {
            try
            {
                if (_capture1 != null && _capture1.Ptr != IntPtr.Zero)
                {
                    _capture1.Retrieve(_frame1, 0);
                    //CvInvoke.Resize(_frame1, _frame1, new Size(IBCam.Width, IBCam.Height), 0, 0, Inter.Linear);    //This resizes the image to the size of Imagebox1 
                    IBCam.Image = _frame1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if(_capture1 == null)
            {
                CvInvoke.UseOpenCL = false;
                _capture1 = new VideoCapture(CB_CameraNames.SelectedIndex);
                _capture1.SetCaptureProperty(CapProp.Fps, 60);
                _capture1.ImageGrabbed += ProcessFrame1;
                _frame1 = new Mat();

            }

            if (!isCapturing1)
            {
                _capture1.Start();
                isCapturing1 = true;
                btn_Start.Text = "Stop";
                CB_CameraNames.Enabled = false;
            }
            else if (isCapturing1)
            {
                _capture1.Stop();
                isCapturing1 = false;
                btn_Start.Text = "Start";
            }


        }

        private void ProcessSerialFrame(object sender, EventArgs arg)
        {
            try
            {
                //Thread.Sleep(10);
                string x = serialPort1.ReadLine();
                this.BeginInvoke(new SetTextDeleg(setPortText), new object[] { x });
            }
            catch(Exception ex)
            {
                
            }
            
        }
        private void setPortText(string text)
        {
            string[] data = text.Split('\t');
            txt_Yaw.Text = data[1];
            txt_Pitch.Text = data[2];
            txt_Roll.Text = data[3];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(CB_PortNames.Text) && !serialPort1.IsOpen)
            {
                serialPort1.PortName = CB_PortNames.Text;
                serialPort1.BaudRate = 115200;
                serialPort1.Open();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(ProcessSerialFrame);
                btn_Serial.Text = "Stop Serial";
                CB_PortNames.Enabled = false;
            }
            else if (!String.IsNullOrWhiteSpace(CB_PortNames.Text) && serialPort1.IsOpen)
            {
                serialPort1.Close();
                btn_Serial.Text = "Start Serial";
                CB_PortNames.Enabled = true;
            }
        }

        private void btn_Start2_Click(object sender, EventArgs e)
        {
            if (_capture2 == null)
            {
                CvInvoke.UseOpenCL = false;
                _capture2 = new VideoCapture(CB_CameraNames2.SelectedIndex);
                _capture2.SetCaptureProperty(CapProp.Fps, 60);
                _capture2.ImageGrabbed += ProcessFrame2;
                _frame2 = new Mat();

            }

            if (!isCapturing2)
            {
                _capture2.Start();
                isCapturing2 = true;
                btn_Start2.Text = "Stop";
                CB_CameraNames2.Enabled = false;
            }
            else if (isCapturing2)
            {
                _capture2.Stop();
                isCapturing2 = false;
                btn_Start2.Text = "Start";
            }
        }
        private void ProcessFrame2(object sender, EventArgs arg)
        {
            try
            {
                if (_capture2 != null && _capture2.Ptr != IntPtr.Zero)
                {
                    _capture2.Retrieve(_frame2, 0);
                    //CvInvoke.Resize(_frame2, _frame2, new Size(IBCam2.Width, IBCam2.Height), 0, 0, Inter.Linear);    //This resizes the image to the size of Imagebox1 
                    IBCam2.Image = _frame2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }
    }
}
