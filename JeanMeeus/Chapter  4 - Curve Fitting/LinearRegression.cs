using System;

namespace JeanMeeus
{
    public struct Point
    {
        public double x;
        public double y;
    }

    public class LinearRegression
    {
        public readonly double a;
        public readonly double b;

        public static Func<double, double> Create(Point[] points)
        {
            var line = new LinearRegression(points);
            return line.f;
        }

        public LinearRegression(Point[] points)
        {
            double N = points.Length;
            double Ex = 0, Ey = 0, Exy = 0, Ex2 = 0;

            foreach (var p in points)
            {
                Ex  += p.x;
                Ey  += p.y;
                Exy += p.x * p.y;
                Ex2 += p.x * p.x;
            }

            a = (N * Exy - Ex * Ey) / (N * Ex2 - Ex * Ex);
            b = (Ey * Ex2 - Ex * Exy) / (N * Ex2 - Ex * Ex);
        }

        public double f(double x)
        {
            return a * x + b;
        }
    }
}
