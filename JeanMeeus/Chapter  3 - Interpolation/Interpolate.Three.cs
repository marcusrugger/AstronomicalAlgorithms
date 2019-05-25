using System;

namespace JeanMeeus
{
    public class InterpolateThree
    {
        private readonly double y2;
        private readonly double a, b, c;

        public InterpolateThree(double y1, double y2, double y3)
        {
            this.y2 = y2;

            a = y2 - y1;
            b = y3 - y2;
            c = b - a;
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Formula 3.3
        public double FindY(double n)
        {
            double y = y2 + (n / 2) * (a + b + n * c);
            return y;
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Formula 3.4
        public double ExtremumY
        {
            get { return y2 - (a + b) * (a + b) / (8 * c); }
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Formula 3.5
        public double ExtremumN
        {
            get { return -((a + b) / (2 * c)); }
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 26, Formula 3.6
        public double Ybecomes0(double precision)
        {
            double nold = 0.0;
            double n0 = f(nold);

            while (Math.Abs(n0 - nold) > precision)
            {
                nold = n0;
                n0 = f(nold);
            }

            return n0;

            double f(double n)
            {
                return (-(2 * y2)) / (a + b + c * n);
            }
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 27, Formula 3.7
        public double CurvedYbecomes0(double precision)
        {
            double n0 = 0.0;
            double dn0;

            do
            {
                dn0 = f(n0);
                n0 += dn0;
            }
            while (Math.Abs(dn0) > precision);

            return n0;

            double f(double n)
            {
                return -((2 * y2 + n * (a + b + c * n)) / (a + b + 2 * c * n));
            }
        }
    }
}
