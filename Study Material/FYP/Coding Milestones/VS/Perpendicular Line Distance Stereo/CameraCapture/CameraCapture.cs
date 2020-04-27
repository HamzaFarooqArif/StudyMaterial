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
            Image<Bgr, Byte> frame1 = frameOriginal.Clone();
            Image<Bgr, Byte> frame2 = frameOriginal.Clone();
            CvInvoke.Circle(frame1, MouseUtility.getInstance(0).currentPoint, 1, new MCvScalar(0, 0, 255), 2);
            for (int i = 0; i < MouseUtility.getInstance(0).idx; i++)
            {
                Point center = new Point((int)MouseUtility.getInstance(0).points[i].X, (int)MouseUtility.getInstance(0).points[i].Y);
                CvInvoke.Circle(frame1, center, 1, new MCvScalar(0, 0, 255), 2);
            }
            if(MouseUtility.getInstance(0).idx > 1)
            {
                CvInvoke.Line(frame1, MouseUtility.getInstance(0).points[0], MouseUtility.getInstance(0).points[1], new MCvScalar(0, 0, 255));
                if (MouseUtility.getInstance(0).idx > 2)
                {
                    Point p1 = MouseUtility.getInstance(0).getPerpEndPoints(frame1.Rows, frame1.Cols, MouseUtility.getInstance(0).points[0], MouseUtility.getInstance(0).points[1], MouseUtility.getInstance(0).points[2])[0];
                    Point q1 = MouseUtility.getInstance(0).getPerpEndPoints(frame1.Rows, frame1.Cols, MouseUtility.getInstance(0).points[0], MouseUtility.getInstance(0).points[1], MouseUtility.getInstance(0).points[2])[1];
                    CvInvoke.Line(frame1, p1, q1, new MCvScalar(0, 0, 255));

                    Point p2 = MouseUtility.getInstance(0).getDistPoints(frame1.Rows, frame1.Cols, p1, q1, MouseUtility.getInstance(0).currentPoint)[0];
                    Point q2 = MouseUtility.getInstance(0).getDistPoints(frame1.Rows, frame1.Cols, p1, q1, MouseUtility.getInstance(0).currentPoint)[1];
                    CvInvoke.Line(frame1, p2, q2, new MCvScalar(0, 0, 255));
                }
            }

            CvInvoke.Circle(frame2, MouseUtility.getInstance(1).currentPoint, 1, new MCvScalar(0, 0, 255), 2);
            for (int i = 0; i < MouseUtility.getInstance(1).idx; i++)
            {
                Point center = new Point((int)MouseUtility.getInstance(1).points[i].X, (int)MouseUtility.getInstance(1).points[i].Y);
                CvInvoke.Circle(frame2, center, 1, new MCvScalar(0, 0, 255), 2);
            }
            if (MouseUtility.getInstance(1).idx > 1)
            {
                CvInvoke.Line(frame2, MouseUtility.getInstance(1).points[0], MouseUtility.getInstance(1).points[1], new MCvScalar(0, 0, 255));
                if (MouseUtility.getInstance(1).idx > 2)
                {
                    Point p1 = MouseUtility.getInstance(1).getPerpEndPoints(frame2.Rows, frame2.Cols, MouseUtility.getInstance(1).points[0], MouseUtility.getInstance(1).points[1], MouseUtility.getInstance(1).points[2])[0];
                    Point q1 = MouseUtility.getInstance(1).getPerpEndPoints(frame2.Rows, frame2.Cols, MouseUtility.getInstance(1).points[0], MouseUtility.getInstance(1).points[1], MouseUtility.getInstance(1).points[2])[1];
                    CvInvoke.Line(frame2, p1, q1, new MCvScalar(0, 0, 255));

                    Point p2 = MouseUtility.getInstance(1).getDistPoints(frame2.Rows, frame2.Cols, p1, q1, MouseUtility.getInstance(1).currentPoint)[0];
                    Point q2 = MouseUtility.getInstance(1).getDistPoints(frame2.Rows, frame2.Cols, p1, q1, MouseUtility.getInstance(1).currentPoint)[1];
                    CvInvoke.Line(frame2, p2, q2, new MCvScalar(0, 0, 255));
                }
            }

            imageBox1.Image = frame1;
            imageBox2.Image = frame2;
        }

        private void imageBox1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;

            if (MouseUtility.getInstance(0).idx > 1)
            {
                double m = (double)(MouseUtility.getInstance(0).points[1].Y - MouseUtility.getInstance(0).points[0].Y) / (double)(MouseUtility.getInstance(0).points[1].X - MouseUtility.getInstance(0).points[0].X);
                int c  = (int)(MouseUtility.getInstance(0).points[1].Y - (m * MouseUtility.getInstance(0).points[1].X));

                for (int i = 0; i < imageBox1.Height; i++)
                {
                    if((i == (int)(m * coord.X + c)))
                    {
                        coord.Y = i;
                        break;
                    }
                }
            }
            MouseUtility.getInstance(0).insertPoint(coord.X, coord.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MouseUtility.getInstance(0).idx--;
        }

        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseUtility.getInstance(0).currentPoint.X = e.Location.X;
            MouseUtility.getInstance(0).currentPoint.Y = e.Location.Y;
        }

        private void imageBox2_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;

            if (MouseUtility.getInstance(1).idx > 1)
            {
                double m = (double)(MouseUtility.getInstance(1).points[1].Y - MouseUtility.getInstance(1).points[0].Y) / (double)(MouseUtility.getInstance(1).points[1].X - MouseUtility.getInstance(1).points[0].X);
                int c = (int)(MouseUtility.getInstance(1).points[1].Y - (m * MouseUtility.getInstance(1).points[1].X));

                for (int i = 0; i < imageBox1.Height; i++)
                {
                    if ((i == (int)(m * coord.X + c)))
                    {
                        coord.Y = i;
                        break;
                    }
                }
            }
            MouseUtility.getInstance(1).insertPoint(coord.X, coord.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MouseUtility.getInstance(1).idx--;
        }

        private void imageBox2_MouseMove(object sender, MouseEventArgs e)
        {
            MouseUtility.getInstance(1).currentPoint.X = e.Location.X;
            MouseUtility.getInstance(1).currentPoint.Y = e.Location.Y;
        }
    }
}
