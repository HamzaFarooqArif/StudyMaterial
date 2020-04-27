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

        private VideoCapture _capture1 = null;
        private VideoCapture _capture2 = null;
        //private Mat _frame;
        private int[] upper = { 50, 255, 255 };
        private int[] lower = { 29, 80, 73 };
        public CameraCapture()
        {
            InitializeComponent();
            
            CvInvoke.UseOpenCL = false;
            //_frame = new Mat();
            _capture1 = new VideoCapture(0);
            _capture2 = new VideoCapture(1);
            //_capture1.SetCaptureProperty(CapProp.Fps, 60);
            //_capture2.SetCaptureProperty(CapProp.Fps, 60);
            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //Image<Bgr, Byte> frameOriginal = _capture1.QueryFrame().ToImage<Bgr, Byte>();
            Image<Bgr, Byte> frame1 = _capture1.QueryFrame().ToImage<Bgr, Byte>();
            Image<Bgr, Byte> frame1Copy = frame1.Clone();
            Image<Bgr, Byte> frame2 = frame1.Clone();//_capture2.QueryFrame().ToImage<Bgr, Byte>();
            Image<Bgr, Byte> frame2Copy = frame1.Clone();//frame2.Clone();

            //Ball detection for camera1----------------------------------------------------------------------------------------------
            frame1Copy._SmoothGaussian(11);
            Image<Hsv, byte> frame1HSV = frame1Copy.Convert<Hsv, byte>();
            CvInvoke.InRange(frame1HSV, new ScalarArray(new MCvScalar(lower[0], lower[1], lower[2])),
                           new ScalarArray(new MCvScalar(upper[0], upper[1], upper[2])), frame1HSV);
            var element1 = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(frame1HSV, frame1HSV, element1, new Point(-1, -1), 2, BorderType.Reflect, default(MCvScalar));
            CvInvoke.Dilate(frame1HSV, frame1HSV, element1, new Point(-1, -1), 2, BorderType.Reflect, default(MCvScalar));
            Emgu.CV.Util.VectorOfVectorOfPoint contours1 = new Emgu.CV.Util.VectorOfVectorOfPoint();
            CvInvoke.FindContours(frame1HSV, contours1, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            Image<Gray, byte> imgout1 = new Image<Gray, byte>(frame1HSV.Width, frame1HSV.Height, new Gray(0));
            Image<Gray, byte> imgCircle1 = new Image<Gray, byte>(frame1HSV.Width, frame1HSV.Height, new Gray(0));
            CvInvoke.DrawContours(imgout1, contours1, -1, new MCvScalar(255, 0, 0));
            Point center1 = new Point();
            if (contours1.Size > 0)
            {
                double prevSize = 0;
                int idx = 0;

                for (int i = 0; i < contours1.Size; i++)
                {
                    if (CvInvoke.ContourArea(contours1[i]) > prevSize)
                    {
                        prevSize = CvInvoke.ContourArea(contours1[i]);
                        idx = i;
                    }
                }

                CircleF circle = CvInvoke.MinEnclosingCircle(contours1[idx]);
                Moments M = CvInvoke.Moments(contours1[idx]);
                center1 = new Point((int)(M.M10 / M.M00), (int)(M.M01 / M.M00));

                if (circle.Radius > 10)
                {
                    CvInvoke.Circle(frame1, center1, (int)circle.Radius, new MCvScalar(255, 0, 0), 5);
                    CvInvoke.Circle(frame1, center1, 5, new MCvScalar(0, 0, 255), 5);
                }
            }

            //Ball detection for camera2----------------------------------------------------------------------------------------------
            frame2Copy._SmoothGaussian(11);
            Image<Hsv, byte> frame2HSV = frame2Copy.Convert<Hsv, byte>();
            CvInvoke.InRange(frame2HSV, new ScalarArray(new MCvScalar(lower[0], lower[1], lower[2])),
                           new ScalarArray(new MCvScalar(upper[0], upper[1], upper[2])), frame2HSV);
            var element2 = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Erode(frame2HSV, frame2HSV, element2, new Point(-1, -1), 2, BorderType.Reflect, default(MCvScalar));
            CvInvoke.Dilate(frame2HSV, frame2HSV, element2, new Point(-1, -1), 2, BorderType.Reflect, default(MCvScalar));
            Emgu.CV.Util.VectorOfVectorOfPoint contours2 = new Emgu.CV.Util.VectorOfVectorOfPoint();
            CvInvoke.FindContours(frame2HSV, contours2, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            Image<Gray, byte> imgout2 = new Image<Gray, byte>(frame2HSV.Width, frame2HSV.Height, new Gray(0));
            Image<Gray, byte> imgCircle2 = new Image<Gray, byte>(frame2HSV.Width, frame2HSV.Height, new Gray(0));
            CvInvoke.DrawContours(imgout2, contours2, -1, new MCvScalar(255, 0, 0));
            Point center2 = new Point();
            if (contours2.Size > 0)
            {
                double prevSize = 0;
                int idx = 0;

                for (int i = 0; i < contours2.Size; i++)
                {
                    if (CvInvoke.ContourArea(contours2[i]) > prevSize)
                    {
                        prevSize = CvInvoke.ContourArea(contours2[i]);
                        idx = i;
                    }
                }

                CircleF circle = CvInvoke.MinEnclosingCircle(contours2[idx]);
                Moments M = CvInvoke.Moments(contours2[idx]);
                center2 = new Point((int)(M.M10 / M.M00), (int)(M.M01 / M.M00));

                if (circle.Radius > 10)
                {
                    CvInvoke.Circle(frame2, center2, (int)circle.Radius, new MCvScalar(255, 0, 0), 5);
                    CvInvoke.Circle(frame2, center2, 5, new MCvScalar(0, 0, 255), 5);
                }
            }









            CvInvoke.Circle(frame1, center1, 1, new MCvScalar(0, 0, 255), 2);
            for (int i = 0; i < MouseUtility.getInstance(0).idx; i++)
            {
                Point center = new Point((int)MouseUtility.getInstance(0).points[i].X, (int)MouseUtility.getInstance(0).points[i].Y);
                CvInvoke.Circle(frame1, center, 1, new MCvScalar(0, 0, 255), 2);
            }
            if (MouseUtility.getInstance(0).idx > 1)
            {
                CvInvoke.Line(frame1, MouseUtility.getInstance(0).points[0], MouseUtility.getInstance(0).points[1], new MCvScalar(0, 0, 255));
                if (MouseUtility.getInstance(0).idx > 2)
                {
                    Point p1 = MouseUtility.getInstance(0).getPerpEndPoints(frame1.Rows, frame1.Cols, MouseUtility.getInstance(0).points[0], MouseUtility.getInstance(0).points[1], MouseUtility.getInstance(0).points[2])[0];
                    Point q1 = MouseUtility.getInstance(0).getPerpEndPoints(frame1.Rows, frame1.Cols, MouseUtility.getInstance(0).points[0], MouseUtility.getInstance(0).points[1], MouseUtility.getInstance(0).points[2])[1];
                    CvInvoke.Line(frame1, p1, q1, new MCvScalar(0, 0, 255));

                    Point p2 = MouseUtility.getInstance(0).getDistPoints(frame1.Rows, frame1.Cols, p1, q1, center1)[0];
                    Point q2 = MouseUtility.getInstance(0).getDistPoints(frame1.Rows, frame1.Cols, p1, q1, center1)[1];
                    CvInvoke.Line(frame1, p2, q2, new MCvScalar(0, 0, 255));

                    if (MouseUtility.getInstance(0).directionOfPoint(p1, q1, center1) == 1)
                    {
                        MouseUtility.getInstance(0).position = -MouseUtility.getInstance(0).percent(MouseUtility.getInstance(0).distance(p2, q2), MouseUtility.getInstance(0).distance(MouseUtility.getInstance(0).points[0], MouseUtility.getInstance(0).points[2]));
                    }
                    if (MouseUtility.getInstance(0).directionOfPoint(p1, q1, center1) < 1)
                    {
                        MouseUtility.getInstance(0).position = MouseUtility.getInstance(0).percent(MouseUtility.getInstance(0).distance(p2, q2), MouseUtility.getInstance(0).distance(MouseUtility.getInstance(0).points[1], MouseUtility.getInstance(0).points[2]));
                    }
                }
            }
            //---------------------------------------------------------------------------------------------------
            CvInvoke.Circle(frame2, center2, 1, new MCvScalar(0, 0, 255), 2);
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

                    Point p2 = MouseUtility.getInstance(1).getDistPoints(frame2.Rows, frame2.Cols, p1, q1, center2)[0];
                    Point q2 = MouseUtility.getInstance(1).getDistPoints(frame2.Rows, frame2.Cols, p1, q1, center2)[1];
                    CvInvoke.Line(frame2, p2, q2, new MCvScalar(0, 0, 255));

                    if (MouseUtility.getInstance(1).directionOfPoint(p1, q1, center2) == 1)
                    {
                        MouseUtility.getInstance(1).position = -MouseUtility.getInstance(1).percent(MouseUtility.getInstance(1).distance(p2, q2), MouseUtility.getInstance(1).distance(MouseUtility.getInstance(1).points[0], MouseUtility.getInstance(1).points[2]));
                    }
                    if (MouseUtility.getInstance(1).directionOfPoint(p1, q1, center2) < 1)
                    {
                        MouseUtility.getInstance(1).position = MouseUtility.getInstance(1).percent(MouseUtility.getInstance(1).distance(p2, q2), MouseUtility.getInstance(1).distance(MouseUtility.getInstance(1).points[1], MouseUtility.getInstance(1).points[2]));
                    }
                }
            }

            int boardWidth = 480;
            int boardHeight = 320;

            Image<Gray, byte> boardFrame = new Image<Gray, byte>(boardWidth, boardHeight);
            Point line1p1 = new Point((int)((float)boardWidth*(float)0.1), (int)((float)boardHeight * (float)0.1));
            Point line1p2 = new Point(boardWidth, boardHeight);
            Point line2p1 = new Point((int)((float)boardWidth * (float)0.9), (int)((float)boardHeight * (float)0.1));
            Point line2p2 = new Point(0, boardHeight);

            line1p2 = MouseUtility.getInstance(0).rotate(line1p2, line1p1, (float)11.5 - MouseUtility.getInstance(0).getAngleFromPercent(MouseUtility.getInstance(0).position));
            line2p2 = MouseUtility.getInstance(1).rotate(line2p2, line2p1, (float)-11.5 + MouseUtility.getInstance(1).getAngleFromPercent(MouseUtility.getInstance(1).position));

            CvInvoke.Circle(boardFrame, line1p1, 1, new MCvScalar(255, 255, 255), 2);
            CvInvoke.Circle(boardFrame, line1p2, 1, new MCvScalar(255, 255, 255), 2);
            CvInvoke.Circle(boardFrame, line2p1, 1, new MCvScalar(255, 255, 255), 2);
            CvInvoke.Circle(boardFrame, line2p2, 1, new MCvScalar(255, 255, 255), 2);
            CvInvoke.Line(boardFrame, line1p1, line1p2, new MCvScalar(255, 255, 255));
            CvInvoke.Line(boardFrame, line2p1, line2p2, new MCvScalar(255, 255, 255));





            textBox1.Text = MouseUtility.getInstance(0).position.ToString();
            textBox2.Text = MouseUtility.getInstance(1).position.ToString();

            imageBox1.Image = frame1;
            imageBox2.Image = frame2;

            CvInvoke.Imshow("Board", boardFrame);
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
            if (MouseUtility.getInstance(0).idx > 0)
            {
                MouseUtility.getInstance(0).idx--;
            }
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
            if(MouseUtility.getInstance(1).idx > 0)
            {
                MouseUtility.getInstance(1).idx--;
            }
            
        }

        private void imageBox2_MouseMove(object sender, MouseEventArgs e)
        {
            MouseUtility.getInstance(1).currentPoint.X = e.Location.X;
            MouseUtility.getInstance(1).currentPoint.Y = e.Location.Y;
        }
    }
}
