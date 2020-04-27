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
            if(MouseUtility.getInstance().idx == 4)
            {
                PointF[] dsts = new PointF[4];
                dsts[0] = new PointF(0, 0);
                dsts[1] = new PointF(Int32.Parse(textBox1.Text) - 1, 0);
                dsts[2] = new PointF(Int32.Parse(textBox1.Text) - 1, Int32.Parse(textBox2.Text) - 1);
                dsts[3] = new PointF(0, Int32.Parse(textBox2.Text) - 1);
                var mywarpmat = CvInvoke.GetPerspectiveTransform(MouseUtility.getInstance().points, dsts);
                CvInvoke.WarpPerspective(frame, frame, mywarpmat, new System.Drawing.Size(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text)), Inter.Linear, Warp.Default);
                CvInvoke.Imshow("Trans", frame);
            }
            imageBox1.Image = frame;
        }

        private void imageBox1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;
            MouseUtility.getInstance().insertPoint(coord.X, coord.Y);
        }
    }
}
