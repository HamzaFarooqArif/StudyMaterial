using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorMine;

namespace CameraCapture.Utilities
{
    class ColorUtility
    {
        public static void HsvToRgb(double hue, double sat, double val, out int red, out int green, out int blue)
        {
            hue = Map(hue, 0, 255, 0, 360);
            sat = Map(sat, 0, 255, 0, 1);
            val = Map(val, 0, 255, 0, 1);


            var hsv = new ColorMine.ColorSpaces.Hsv { H = hue, S = sat, V = val };
            var rgb = hsv.To<ColorMine.ColorSpaces.Rgb>();
            red = (int)rgb.R;
            green = (int)rgb.G;
            blue = (int)rgb.B;
        }
        public static double Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}
