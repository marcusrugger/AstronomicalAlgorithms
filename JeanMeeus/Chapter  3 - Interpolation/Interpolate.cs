using System;

namespace JeanMeeus
{
    public static class Interpolate
    {
        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Formula 3.3
        public static Func<double, double> Given(double y1, double y2, double y3)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = b - a;

            return (n) => y2 + (n / 2) * (a + b + n * c);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 28, Formula 3.8
        public static Func<double, double> Given(double y1, double y2, double y3, double y4, double y5)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y4 - y3;
            var d = y5 - y4;
            var e = b - a;
            var f = c - b;
            var g = d - c;
            var h = f - e;
            var j = g - f;
            var k = j - h;

            return (n) => y3 +
                          (n / 2) * (b + c) +
                          (n * n / 2) * f +
                          ((n * (n * n - 1)) / 12) * (h + j) +
                          ((n * n * (n * n - 1)) / 24) * k;
        }
    }
}
