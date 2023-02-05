using System;

namespace PointLib
{
    [Serializable]
    public class Point : IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }
        protected Random rnd = new Random(DateTime.Now.Millisecond);
        public Point()
        {
            X = rnd.Next(10);
            Y = rnd.Next(10);
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual double Metric()
        {
            return Math.Sqrt(X*X + Y*Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public int CompareTo(object obj)
        {
            Point p = (Point)obj;
            return (int)(Metric() - p.Metric());
        }
    }
}