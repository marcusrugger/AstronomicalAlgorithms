using System;

namespace JeanMeeus
{
    public class GregorianCalendar : Calendar
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

            double A = Math.Truncate(Y / 100.0);
            double B = 2.0 - A + Math.Truncate(A / 4.0);

            return Math.Truncate(365.25 * (Y + 4716.0)) +
                   Math.Truncate(30.6001 * (M + 1.0)) +
                   D + B - 1524.5;
        }

        public static Date FromJulianDay(double JD)
        {
            double adjustedJD = JD + 0.5;
            double Z = Math.Truncate(adjustedJD);
            double F = adjustedJD - Z;
            double a = Math.Truncate((Z - 1867216.25) / 36524.25);
            double A = Z + 1 + a - Math.Truncate(a / 4.0);
            double B = A + 1524.0;
            double C = Math.Truncate((B - 122.1) / 365.25);
            double D = Math.Truncate(365.25 * C);
            double E = Math.Truncate((B - D) / 30.6001);

            double day = B - D - Math.Truncate(30.6001 * E) + F;
            int month = (int)(E < 14 ? E - 1 : E - 13);
            int year = (int)(month > 2 ? C - 4716 : C - 4715);

            return new Date(year, month, day);
        }

        public static bool IsLeapYear(int year) => year % 100 == 0 ? year % 400 == 0 : year % 4 == 0;
        public static bool IsLeapYear(Date date) => IsLeapYear(date.Year);

        public static int DayOfTheYear(Date date)
        {
            int M = date.Month;
            int D = (int)date.Day;
            int K = IsLeapYear(date) ? 1 : 2;

            int N = 275 * M / 9 - K * ((M + 9) / 12) + D - 30;

            return N;
        }

        public static GregorianCalendar Create(double JD) => new GregorianCalendar(JD);
        public static GregorianCalendar Create(int year, int month, double day) => Create( ToJulianDay(year, month, day) );
        public static GregorianCalendar Create(Date date) => Create(date.Year, date.Month, date.Day);
        public static GregorianCalendar Create(Calendar date) => Create(date.JulianDay);

        public static GregorianCalendar Create(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            double d = millisecond;
            d = second + d / 1000.0;
            d = minute + d / 60.0;
            d = hour + d / 60.0;
            d = day + d / 24.0;

            return Create(year, month, d);
        }

        private GregorianCalendar(double julianDay)
        : base(julianDay)
        { }

        private GregorianCalendar(GregorianCalendar date)
        : base(date)
        { }

        public override Calendar Clone() => new GregorianCalendar(this);

        protected override Calendar Instantiate(double jd) => new GregorianCalendar(jd);

        public override Date Date => FromJulianDay(JulianDay);
    }
}
