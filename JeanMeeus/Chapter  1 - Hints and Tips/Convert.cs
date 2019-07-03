using System;

namespace JeanMeeus
{
    public class Convert
    {
        public static double Sexagesimal(double h, double m, double s) => h + m / 60.0 + s / 3600.0;

        public static double MeeusSexagesimal(double h, double m, double s)
        {
            if (h < 0.0)
            {
                m = -Math.Abs(m);
                s = -Math.Abs(s);
            }

            return Sexagesimal(h, m, s);
        }
    }
}
