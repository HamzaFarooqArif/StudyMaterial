using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace test_CV
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\lena.jpg";

            Image<Bgr, byte> imf = new Image<Bgr, byte>(fileName);
            Image<Bgr, byte> imf1 = new Image<Bgr, byte>(fileName);
            CvInvoke.BitwiseNot(imf, imf1, null);
            CvInvoke.Imshow("Image", imf1);
            
            CvInvoke.WaitKey(0);

        }
    }
}
