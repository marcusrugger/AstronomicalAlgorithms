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
        public readonly double N;
        public readonly double Ex;
        public readonly double Ey;
        public readonly double Exy;
        public readonly double Ex2;
        public readonly double Ey2;

        public LinearRegression(Point[] points)
        {
            N = points.Length;

            foreach (var p in points)
            {
                Ex  += p.x;
                Ey  += p.y;
                Exy += p.x * p.y;
                Ex2 += p.x * p.x;
                Ey2 += p.y * p.y;
            }
        }

        public double a => (N * Exy - Ex * Ey) / (N * Ex2 - Ex * Ex);
        public double b => (Ey * Ex2 - Ex * Exy) / (N * Ex2 - Ex * Ex);
        public double r => (N * Exy - Ex * Ey) / (Math.Sqrt(N * Ex2 - Ex * Ex) * Math.Sqrt(N * Ey2 - Ey * Ey));

        public double fn(double x) => a * x + b;
    }
}
