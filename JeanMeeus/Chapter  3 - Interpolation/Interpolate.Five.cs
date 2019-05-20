using System;

namespace JeanMeeus
{
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
