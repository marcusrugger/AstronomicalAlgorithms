
namespace JeanMeeus
{
    public delegate double InterpolateY(double x);

    public class Interpolate
    {
        public static InterpolateY FromX(double x2, double y1, double y2, double y3)
        {
            var fn = new InterpolateThree(x2, y1, y2, y3);

            return (x) => fn.FromX(x);
        }

        public static InterpolateY FromX(double x3, double y1, double y2, double y3, double y4, double y5)
        {
            var fn = new InterpolateFive(x3, y1, y2, y3, y4, y5);

            return (x) => fn.FromX(x);
        }
    }

    public class InterpolateThree
    {
        private readonly double x2, y2;
        private readonly double a, b, c;

        public InterpolateThree(
            double x2,
            double y1, double y2, double y3)
        {
            this.x2 = x2;
            this.y2 = y2;

            a = y2 - y1;
            b = y3 - y2;
            c = b - a;
        }

        public double FromX(double x)
        {
            var n = x - x2;
            return FromN(n);
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Formula 3.3
        public double FromN(double n)
        {
            double y = y2 + (n / 2) * (a + b + n * c);
            return y;
        }
    }

    public class InterpolateFive
    {
        private readonly double x3, y3;
        private readonly double a, b, c, d, e, f, g, h, j, k;

        public InterpolateFive(
            double x3,
            double y1, double y2, double y3, double y4, double y5)
        {
            this.x3 = x3;
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

        public double FromX(double x)
        {
            double n = x - x3;
            return FromN(n);
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
