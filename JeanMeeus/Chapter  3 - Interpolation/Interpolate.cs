using System;

namespace JeanMeeus
{
    public class Interpolate
    {
        public static double FromX(double x, double x2, double y1, double y2, double y3)
        {
            return Interpolator.FromX(x2, y1, y2, y3)(x);
        }

        public static double FromX(double x, double x3, double y1, double y2, double y3, double y4, double y5)
        {
            return Interpolator.FromX(x3, y1, y2, y3, y4, y5)(x);
        }

        public static double FromN(double n, double y1, double y2, double y3)
        {
            return Interpolator.FromN(y1, y2, y3)(n);
        }

        public static double FromN(double n, double y1, double y2, double y3, double y4, double y5)
        {
            return Interpolator.FromN(y1, y2, y3, y4, y5)(n);
        }
    }

    public class Interpolator
    {
        public delegate double InterpolateY(double x);

        public static InterpolateY FromX(double x2, double y1, double y2, double y3)
        {
            var fn = new InterpolateThree(y1, y2, y3);

            return (x) => fn.FromN(x - x2);
        }

        public static InterpolateY FromX(double x3, double y1, double y2, double y3, double y4, double y5)
        {
            var fn = new InterpolateFive(y1, y2, y3, y4, y5);

            return (x) => fn.FromN(x - x3);
        }

        public static InterpolateY FromN(double y1, double y2, double y3)
        {
            var fn = new InterpolateThree(y1, y2, y3);

            return (n) => fn.FromN(n);
        }

        public static InterpolateY FromN(double y1, double y2, double y3, double y4, double y5)
        {
            var fn = new InterpolateFive(y1, y2, y3, y4, y5);

            return (n) => fn.FromN(n);
        }
    }

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
        public double FromN(double n)
        {
            double y = y2 + (n / 2) * (a + b + n * c);
            return y;
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Formula 3.4
        public double ExtremumY
        {
            get { return y2 - (a+b) * (a+b) / (8 * c); }
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

    public class InterpolateFive
    {
        private readonly double y3;
        private readonly double a, b, c, d, e, f, g, h, j, k;

        public InterpolateFive(double y1, double y2, double y3, double y4, double y5)
        {
            this.y3 = y3;

            a = y2 - y1;
            b = y3 - y2;
            c = y4 - y3;
            d = y5 - y4;
            e = b - a;
            f = c - b;
            g = d - c;
            h = f - e;
            j = g - f;
            k = j - h;
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 28, Formula 3.8
        public double FromN(double n)
        {
            double y = y3
                     + (n / 2) * (b + c)
                     + (n * n / 2) * f
                     + ((n * (n * n - 1)) / 12) * (h + j)
                     + ((n * n * (n * n - 1)) / 24) * k;

            return y;
        }
    }
}
