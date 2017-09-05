using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanMeeus
{
    public class GregorianCalendar : Calendar
    {
        public static new GregorianCalendar Create(int year, int month, double day)
        {
            double jd = JeanMeeus.JulianDay.GregorianDateToJulianDay(year, month, day);
            return new GregorianCalendar(jd);
        }

        public static new GregorianCalendar Create(Date date)
        {
            return Create(date.Year, date.Month, date.Day);
        }

        public static GregorianCalendar Create(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            double d = millisecond;
            d = second + d / 1000.0;
            d = minute + d / 60.0;
            d = hour + d / 60.0;
            d = day + d / 24.0;

            return Create(year, month, d);
        }

        public static GregorianCalendar Create(JulianCalendar date)
        {
            return new GregorianCalendar(date.JulianDay);
        }

        public GregorianCalendar(double julianDay)
        : base(julianDay)
        { }

        public GregorianCalendar(GregorianCalendar date)
        : base(date)
        { }

        public override Calendar Clone()
        {
            return new GregorianCalendar(this);
        }

        protected override Calendar Instantiate(double jd)
        {
            return new GregorianCalendar(jd);
        }

        public override Date Date
        {
            get
            {
                double adjustedJD = JulianDay + 0.5;
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

                return new Date()
                {
                    Year = year,
                    Month = month,
                    Day = day
                };
            }
        }
    }
}
