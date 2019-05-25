using System;

namespace JeanMeeus
{
    public class JulianCalendar : Calendar
    {
        public static double ToJulianDay(int year, int month, double day)
        {
            double Y = year;
            double M = month;
            double D = day;

            /* If the month is January or Febuary, consider it to be the 13th or 14th month of the preceding year */
            if (month == 1 || month == 2)
            {
                Y = year - 1;
                M = month + 12;
            }

            double B = 0.0;

            return Math.Truncate(365.25 * (Y + 4716.0)) +
                   Math.Truncate(30.6001 * (M + 1.0)) +
                   D + B - 1524.5;
        }

        public static Date FromJulianDay(double JD)
        {
            double adjustedJD = JD + 0.5;
            double Z = Math.Truncate(adjustedJD);
            double F = adjustedJD - Z;
            double A = Z;
            double B = A + 1524.0;
            double C = Math.Truncate((B - 122.1) / 365.25);
            double D = Math.Truncate(365.25 * C);
            double E = Math.Truncate((B - D) / 30.6001);

            double day = B - D - Math.Truncate(30.6001 * E) + F;
            int month = (int)(E < 14 ? E - 1 : E - 13);
            int year = (int)(month > 2 ? C - 4716 : C - 4715);

            return new Date(year, month, day);
        }

        public static JulianCalendar Create(double JD)
        {
            return new JulianCalendar(JD);
        }

        public static JulianCalendar Create(int year, int month, double day)
        {
            return Create( ToJulianDay(year, month, day) );
        }

        public static JulianCalendar Create(Date date)
        {
            return Create(date.Year, date.Month, date.Day);
        }

        public static JulianCalendar Create(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            double d = millisecond;
            d = second + d / 1000.0;
            d = minute + d / 60.0;
            d = hour + d / 60.0;
            d = day + d / 24.0;

            return Create(year, month, d);
        }

        public static JulianCalendar Create(Calendar date)
        {
            return Create(date.JulianDay);
        }

        private JulianCalendar(double julianDay)
        : base(julianDay)
        { }

        private JulianCalendar(JulianCalendar date)
        : base(date)
        { }

        public override Calendar Clone()
        {
            return new JulianCalendar(this);
        }

        protected override Calendar Instantiate(double jd)
        {
            return new JulianCalendar(jd);
        }

        public override Date Date
        {
            get
            { return FromJulianDay(JulianDay); }
        }
    }
}
