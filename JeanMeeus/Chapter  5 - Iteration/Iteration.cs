using System;

namespace JeanMeeus
{
    public class Iteration
    {
        private double sx1;
        private double sx2;
        private double precision;

        public static Func<Func<double, double>, double> Create(double x1, double x2, double precision)
        {
            var obj = new Iteration(x1, x2, precision);
            return obj.BinarySearch;
        }

        private Iteration(double x1, double x2, double precision)
        {
            this.sx1 = x1;
            this.sx2 = x2;
            this.precision = precision;
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 5, page 53, The binary search
        private double BinarySearch(Func<double, double> fn)
        {
            double x1 = this.sx1; double y1 = fn(x1);
            double x2 = this.sx2; double y2 = fn(x2);
            double x = 0, y;

            for (int j = 0; j < 33; j++)
            {
                x = (x1 + x2) / 2;
                y = fn(x);

                if (Math.Abs(y) < this.precision) break;

                if (y * y1 > 0)
                {
                    x1 = x;
                    y1 = y;
                }
                else
                {
                    x2 = x;
                    y2 = y;
                }
            }

            return x;
        }
    }
}
