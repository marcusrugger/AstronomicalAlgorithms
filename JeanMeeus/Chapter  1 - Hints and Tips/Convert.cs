using System;

namespace JeanMeeus
{
    public class Convert
    {
        public static double Sexagecimal(double h, double m, double s)
        {
            return h + m / 60.0 + s / 3600.0;
        }

        public static double MeeusSexagecimal(double h, double m, double s)
        {
            if (h < 0.0)
            {
                m = -Math.Abs(m);
                s = -Math.Abs(s);
            }

            return Sexagecimal(h, m, s);
        }
    }
}
