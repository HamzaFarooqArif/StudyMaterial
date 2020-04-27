using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing.Imaging;
using System.IO;

namespace CVWebApp.Utilities
{
    public class Filters
    {
        private static Filters _instance;
        private Filters()
        {

        }
        public static Filters getInstance()
        {
            if (_instance != null) return _instance;
            else
            {
                _instance = new Filters();
                return _instance;
            }
        }

        public static String BitmapToBase64(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            var bytes = (byte[])converter.ConvertTo(img, typeof(byte[]));
            var base64 = Convert.ToBase64String(bytes);
            return String.Format("data:image/gif;base64,{0}", base64);
        }

        public static Bitmap Base64ToBitmap(String str)
        {
            int sIdx = str.IndexOf("base64,") + 7;
            String converted = str.Substring(sIdx, str.Length - sIdx);
            byte[] data = Convert.FromBase64String(converted);
            Bitmap x = (Bitmap)((new ImageConverter()).ConvertFrom(data));
            return x;
        }

        public static String Negative(String imgStr)
        {
            Bitmap bmp = Base64ToBitmap(imgStr);
            Image<Bgr, Byte> myImage = new Image<Bgr, Byte>(bmp);
            CvInvoke.BitwiseNot(myImage, myImage, null);
            return BitmapToBase64(myImage.Bitmap);
        }

        public static String GammaCorrection(String imgStr)
        {
            Bitmap bmp = Base64ToBitmap(imgStr);
            Image<Bgr, Byte> myImage = new Image<Bgr, Byte>(bmp);
            myImage._GammaCorrect(2.0);
            return BitmapToBase64(myImage.Bitmap);
        }
    }
}