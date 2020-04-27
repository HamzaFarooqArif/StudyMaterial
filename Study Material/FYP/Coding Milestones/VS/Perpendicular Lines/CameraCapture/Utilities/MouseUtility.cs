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
        public int pointLimit;
        public Point currentPoint;
        public Point[] points { get; set; }
        public int idx { get; set; }
        private MouseUtility()
        {
            pointLimit = 3;
            points = new Point[pointLimit];
            idx = 0;
            currentPoint = new Point();
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
            if(idx < pointLimit)
            {
                this.points[this.idx] = new Point(x, y);
                this.idx++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Point> getEndPoints(int rows, int cols, Point p1, Point p2)
        {
            double slope = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
            Point p = new Point(0, 0);
            Point q = new Point(cols, rows);
            List<Point> result = new List<Point>();

            p.Y = (int)(-(p1.X - p.X) * slope + p1.Y);
            q.Y = (int)(-(p2.X - q.X) * slope + p2.Y);

            result.Add(p);
            result.Add(q);

            return result;
        }

        public List<Point> getPerpEndPoints(int rows, int cols, Point p1, Point p2, Point p3)
        {
            double slope = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
            double m = -1 / (slope);
            int c = (int)(p3.Y - (m * p3.X));
            Point p4 = new Point();

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if ((j == (int)(m * i + c)) && p3.X != i && p3.Y != j)
                    {
                        p4.X = i;
                        p4.Y = j;
                        break;
                    }
                }
            }
            if (p4.X == 0 && p4.Y == 0)
            {
                p4.X = p3.X;
                p4.Y = 0;
            }
            return getEndPoints(rows, cols, p3, p4);
        }
    }
}
