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

        public CameraCapture()
        {
            InitializeComponent();
            
            CvInvoke.UseOpenCL = false;
            _frame = new Mat();
            _capture = new VideoCapture(0);
            _capture.SetCaptureProperty(CapProp.Fps, 60);
            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> frameOriginal = _capture.QueryFrame().ToImage<Bgr, Byte>();
            Image<Bgr, Byte> frame = frameOriginal.Clone();
            for(int i = 0; i < MouseUtility.getInstance().idx; i++)
            {
                Point center = new Point((int)MouseUtility.getInstance().points[i].X, (int)MouseUtility.getInstance().points[i].Y);
                CvInvoke.Circle(frame, center, 1, new MCvScalar(0, 0, 255), 2);
            }
            if(MouseUtility.getInstance().idx > 1)
            {
                CvInvoke.Line(frame, MouseUtility.getInstance().points[0], MouseUtility.getInstance().points[1], new MCvScalar(0, 0, 255));
                if (MouseUtility.getInstance().idx > 2)
                {
                    Point p1 = MouseUtility.getInstance().getPerpEndPoints(frame.Rows, frame.Cols, MouseUtility.getInstance().points[0], MouseUtility.getInstance().points[1], MouseUtility.getInstance().points[2])[0];
                    Point q1 = MouseUtility.getInstance().getPerpEndPoints(frame.Rows, frame.Cols, MouseUtility.getInstance().points[0], MouseUtility.getInstance().points[1], MouseUtility.getInstance().points[2])[1];
                    CvInvoke.Line(frame, p1, q1, new MCvScalar(0, 0, 255));
                }
                    
            }

            imageBox1.Image = frame;
        }

        private void imageBox1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;

            if (MouseUtility.getInstance().idx > 1)
            {
                double m = (double)(MouseUtility.getInstance().points[1].Y - MouseUtility.getInstance().points[0].Y) / (double)(MouseUtility.getInstance().points[1].X - MouseUtility.getInstance().points[0].X);
                int c  = (int)(MouseUtility.getInstance().points[1].Y - (m * MouseUtility.getInstance().points[1].X));

                for (int i = 0; i < imageBox1.Height; i++)
                {
                    if((i == (int)(m * coord.X + c)))
                    {
                        coord.Y = i;
                        break;
                    }
                }
            }
            MouseUtility.getInstance().insertPoint(coord.X, coord.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MouseUtility.getInstance().idx--;
        }
    }
}
