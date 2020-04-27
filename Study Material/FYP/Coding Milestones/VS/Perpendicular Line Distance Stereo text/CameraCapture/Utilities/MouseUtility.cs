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
        private static List<MouseUtility> _instance;
        public int pointLimit;
        public Point currentPoint;
        public Point[] points { get; set; }
        public int idx { get; set; }
        public float position;
        private MouseUtility()
        {
            pointLimit = 3;
            points = new Point[pointLimit];
            idx = 0;
            currentPoint = new Point();
            position = 0;
            //insertPoint(100, 100);
            //insertPoint(200, 100);
            //insertPoint(150, 50);
        }
        public static MouseUtility getInstance(int idx)
        {
            if (_instance == null)
            {
                _instance = new List<MouseUtility>();
                MouseUtility mouseUtility = new MouseUtility();
                _instance.Add(mouseUtility);
            }
            if(_instance.Count == idx)
            {
                MouseUtility mouseUtility = new MouseUtility();
                _instance.Add(mouseUtility);
            }
            return _instance[idx];
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
            Point p = new Point(-1, -1);
            Point q = new Point(-1, -1);

            Point r1 = doIntercept(0, rows, cols, p1, p2);
            Point r2 = doIntercept(1, rows, cols, p1, p2);
            Point r3 = doIntercept(2, rows, cols, p1, p2);
            Point r4 = doIntercept(3, rows, cols, p1, p2);

            if(isValidPoint(r1, rows, cols))
            {
                setPoint(ref p, ref q, r1.X, r1.Y);
            }
            if (isValidPoint(r2, rows, cols))
            {
                setPoint(ref p, ref q, r2.X, r2.Y);
            }
            if (isValidPoint(r3, rows, cols))
            {
                setPoint(ref p, ref q, r3.X, r3.Y);
            }
            if (isValidPoint(r4, rows, cols))
            {
                setPoint(ref p, ref q, r4.X, r4.Y);
            }

            List<Point> result = new List<Point>();
            result.Add(p);
            result.Add(q);

            return result;
        }

        public Point doIntercept(int lineIndex, int rows, int cols, Point p1, Point p2)
        {
            double m1 = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
            int c1 = (int)(p1.Y - (m1 * p1.X));

            Point p = new Point(-1, -1);

            if (lineIndex == 0)
            {
                double x;
                double y;
                if(double.IsInfinity(m1))
                {
                    x = p1.X;
                    y = 0;
                }
                else
                {
                    double m2 = 0;
                    int c2 = 0;
                    x = (c2 - c1) / (m1 - m2);
                    y = (c1 * m2 - c2 * m1) / (m2 - m1);                    
                }
                p.X = (int)x;
                p.Y = (int)y;

                if (p.X <= cols && p.X >= 0 && p.Y <= rows && p.Y >= 0)
                {
                    return p;
                }
            }
            if (lineIndex == 1)
            {
                double x = cols;
                double y = m1*(cols) + c1;
                
                p.X = (int)x;
                p.Y = (int)y;

                if (p.X <= cols && p.X >= 0 && p.Y <= rows && p.Y >= 0)
                {
                    return p;
                }
            }
            if (lineIndex == 2)
            {
                double x;
                double y;
                if(double.IsInfinity(m1))
                {
                    x = p1.X;
                    y = rows;
                }
                else
                {
                    double m2 = 0;
                    int c2 = rows;

                    x = (c2 - c1) / (m1 - m2);
                    y = (c1 * m2 - c2 * m1) / (m2 - m1);
                }
                p.X = (int)x;
                p.Y = (int)y;

                if (p.X <= cols && p.X >= 0 && p.Y <= rows && p.Y >= 0)
                {
                    return p;
                }
            }
            if (lineIndex == 3)
            {
                double x = 0;
                double y = m1 * 0 + c1;

                p.X = (int)x;
                p.Y = (int)y;

                if (p.X <= cols && p.X >= 0 && p.Y <= rows && p.Y >= 0)
                {
                    return p;
                }
            }
            p.X = -1;
            p.Y = -1;
            return p;
        }

        public bool isAssigned(Point p)
        {
            return p.X != -1 && p.Y != -1;
        }
        public bool isValidPoint(Point p, int rows, int cols)
        {
            if (p.X <= cols && p.X >= 0 && p.Y <= rows && p.Y >= 0)
            {
                return true;
            }
            return false;
        }

        public void setPoint(ref Point p, ref Point q, int x, int y)
        {
            if(!isAssigned(p))
            {
                p.X = x;
                p.Y = y;
            }
            else if (!isAssigned(q))
            {
                q.X = x;
                q.Y = y;
            }
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

        public List<Point> getDistPoints(int rows, int cols, Point p1, Point p2, Point p3)
        {
            double m1 = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
            int c1 = (int)(p1.Y - (m1 * p1.X));
            double m2 = -1 / m1; 
            int c2 = (int)(p3.Y - (m2 * p3.X));

            double x;
            double y;

            x = (c2 - c1) / (m1 - m2);
            y = (c1 * m2 - c2 * m1) / (m2 - m1);

            Point p = new Point((int)x, (int)y);
            //Point p4 = new Point(-1, p3.Y);
            //double m = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
            //int c = (int)(p1.Y - (m * p1.X));
            //double x;
            //if (double.IsInfinity(m))
            //{
            //    x = p1.X;
            //}
            //else
            //{
            //    x = (p4.Y - c) / m;
            //}
            //p4.X = (int)x;

            List<Point> result = new List<Point>();
            result.Add(p3);
            result.Add(p);

            return result;
        }

        public int distance(Point p, Point q)
        {
            int xDiff = p.X - q.X;
            int yDiff = p.Y - q.Y;

            int result = (int)Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));

            return result;
        }

        public float percent(int obtained, int total)
        {
            float result = (float)obtained / (float)total;
            result *= 100;
            return result;
        }

        public int directionOfPoint(Point A, Point B, Point P)
        {
            // subtracting co-ordinates of point A from 
            // B and P, to make A as origin 
            B.X -= A.X;
            B.Y -= A.Y;
            P.X -= A.X;
            P.Y -= A.Y;

            // Determining cross Product 
            int cross_product = B.X * P.Y - B.Y * P.X;

            // return RIGHT if cross product is positive 
            if (cross_product > 0)
                return 1;   

            // return LEFT if cross product is negative 
            if (cross_product < 0)
                return -1;

            // return ZERO if cross product is zero.  
            return 0;
        }

        public Point rotate(Point p1, Point center, float angle)
        {
            double ang = Math.PI * angle / 180;
            double x = ((p1.X - center.X) * Math.Cos(ang)) - ((p1.Y - center.Y) * Math.Sin(ang)) + center.X;
            double y = ((p1.X - center.X) * Math.Sin(ang)) + ((p1.Y - center.Y) * Math.Cos(ang)) + center.Y;

            Point result = new Point((int)x, (int)y);
            return result;
        }

        public float getAngleFromPercent(float percent)
        {
            float result = Map(percent, -100, 100, -45, 45);
            return result;
        }

        public float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}
