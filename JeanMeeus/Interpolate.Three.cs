
namespace JeanMeeus
{
    public class InterpolateThree
    {
        private readonly double x2, y2;
        private readonly double a, b, c;

        public InterpolateThree(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            this.x2 = x2; this.y2 = y2;

            a = y2 - y1;
            b = y3 - y2;
            c = b - a;
        }

        // Astronomical Algorithms by Jean Meeus, Chapter 3, page 25, Formula 3.3
        public double CalculateY(double x)
        {
            double n = x - x2;
            double y = y2 + (n / 2) * (a + b + n * c);
            return y;
        }
    }
}
