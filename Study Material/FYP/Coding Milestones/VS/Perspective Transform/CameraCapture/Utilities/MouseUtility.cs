using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CameraCapture.Utilities
{
    class MouseUtility
    {
        private static MouseUtility _instance;
        public Point currentPoint { get; set;}
        public PointF[] points { get; set; }
        public int idx { get; set; }
        private MouseUtility()
        {
            points = new PointF[4];
            idx = 0;
        }
        public static MouseUtility getInstance()
        {
            if (_instance == null)
            {
                _instance = new MouseUtility();
            }
            return _instance;
        }

        public bool insertPoint(int x, int y)
        {
            if(idx < 4)
            {
                this.points[this.idx] = new PointF(x, y);
                this.idx++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int calculateWidth()
        {
            if (idx == 4)
            {
                int widthA = (int)Math.Sqrt(Math.Pow(points[2].X - points[3].X, 2) + Math.Pow(points[2].Y - points[3].Y, 2));
                int widthB = (int)Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2));
                return Math.Max(widthA, widthB);
            }
            return 0;
        }

        public int calculateHeight()
        {
            if (idx == 4)
            {
                int heightA = (int)Math.Sqrt(Math.Pow(points[1].X - points[2].X, 2) + Math.Pow(points[1].Y - points[2].Y, 2));
                int heightB = (int)Math.Sqrt(Math.Pow(points[0].X - points[3].X, 2) + Math.Pow(points[0].Y - points[3].Y, 2));
                return Math.Max(heightA, heightB);
            }
            return 0;
        }

        public PointF[] getDestPoints()
        {
            PointF[] dsts = new PointF[4];
            dsts[0] = new PointF(0, 0);
            dsts[1] = new PointF(MouseUtility.getInstance().calculateWidth() - 1, 0);
            dsts[2] = new PointF(MouseUtility.getInstance().calculateWidth() - 1, MouseUtility.getInstance().calculateHeight() - 1);
            dsts[3] = new PointF(0, MouseUtility.getInstance().calculateHeight() - 1);
            return dsts;
        }
    }
}
