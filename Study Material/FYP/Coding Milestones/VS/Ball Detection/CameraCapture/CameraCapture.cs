//----------------------------------------------------------------------------
//  Copyright (C) 2004-2019 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;
using CameraCapture.Utilities;
using ColorMine;

namespace CameraCapture
{
    public partial class CameraCapture : Form
    {

        private VideoCapture _capture = null;
        private Mat _frame;
        private int[] upper = {50, 255, 255};
        private int[] lower = {29, 80, 73};

        public CameraCapture()
        {
            InitializeComponent();

            trackBar1.Value = lower[0];
            trackBar2.Value = lower[1];
            trackBar3.Value = lower[2];
            trackBar4.Value = upper[0];
            trackBar5.Value = upper[1];
            trackBar6.Value = upper[2];
            
            CvInvoke.UseOpenCL = false;
            _frame = new Mat();
            _capture = new VideoCapture(0);
            _capture.SetCaptureProperty(CapProp.Fps, 60);
            //_capture.ImageGrabbed += ProcessFrame;
            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //_capture.Retrieve(_frame, 0);
            //imageBox1.Image = _frame;

            Image<Bgr, Byte> frameOriginal = _capture.QueryFrame().ToImage<Bgr, Byte>();
            Image<Bgr, Byte> frame = frameOriginal.Clone();
            //CvInvoke.Imshow("Original", frame);
            frame._SmoothGaussian(11);
            //CvInvoke.Imshow("Blurred", frame);
            Image<Hsv, byte> frameHSV = frame.Convert<Hsv, byte>();
            //CvInvoke.Imshow("HSV", frameHSV);
            CvInvoke.InRange(frameHSV, new ScalarArray(new MCvScalar(trackBar1.Value, trackBar2.Value, trackBar3.Value)),
                           new ScalarArray(new MCvScalar(trackBar4.Value, trackBar5.Value, trackBar6.Value)), frameHSV);
            var element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(frameHSV, frameHSV, element, new Point(-1, -1), 2, BorderType.Reflect, default(MCvScalar));
            //CvInvoke.Imshow("Erode", frameHSV);
            CvInvoke.Dilate(frameHSV, frameHSV, element, new Point(-1, -1), 2, BorderType.Reflect, default(MCvScalar));
            CvInvoke.Imshow("Dilate", frameHSV);
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            CvInvoke.FindContours(frameHSV, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            Image<Gray, byte> imgout = new Image<Gray, byte>(frameHSV.Width, frameHSV.Height, new Gray(0));
            Image<Gray, byte> imgCircle = new Image<Gray, byte>(frameHSV.Width, frameHSV.Height, new Gray(0));
            CvInvoke.DrawContours(imgout, contours, -1, new MCvScalar(255, 0, 0));

            if (contours.Size > 0)
            {
                double prevSize = 0;
                int idx = 0;

                for (int i = 0; i < contours.Size; i++)
                {
                    if(CvInvoke.ContourArea(contours[i]) > prevSize)
                    {
                        prevSize = CvInvoke.ContourArea(contours[i]);
                        idx = i;
                    }
                }

                CircleF circle = CvInvoke.MinEnclosingCircle(contours[idx]);
                Moments M = CvInvoke.Moments(contours[idx]);
                Point center = new Point((int)(M.M10 / M.M00), (int)(M.M01 / M.M00));

                if (circle.Radius > 10)
                {
                    CvInvoke.Circle(frameOriginal, center, (int)circle.Radius, new MCvScalar(255, 0, 0), 5);
                    CvInvoke.Circle(frameOriginal, center, 5, new MCvScalar(0, 0, 255), 5);
                    textBox7.Text = center.ToString();
                }
            }

            //CvInvoke.Imshow("Contours", imgout);
            CvInvoke.Imshow("Circle", frameOriginal);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_capture.Start();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            updateColor();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            updateColor();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
            updateColor();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = trackBar4.Value.ToString();
            updateColor();
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = trackBar5.Value.ToString();
            updateColor();
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = trackBar6.Value.ToString();
            updateColor();
        }

        private void updateColor()
        {
            int red1 = 0;
            int green1 = 0;
            int blue1 = 0;
            ColorUtility.HsvToRgb(trackBar1.Value, trackBar2.Value, trackBar3.Value, out red1, out green1, out blue1);
            if (red1 < 256 && green1 < 256 && blue1 < 256)
            {
                richTextBox1.BackColor = Color.FromArgb(red1, green1, blue1);
            }

            int red2 = 0;
            int green2 = 0;
            int blue2 = 0;
            ColorUtility.HsvToRgb(trackBar4.Value, trackBar5.Value, trackBar6.Value, out red2, out green2, out blue2);
            richTextBox2.BackColor = Color.FromArgb(red2, green2, blue2);
        }
    }
}
