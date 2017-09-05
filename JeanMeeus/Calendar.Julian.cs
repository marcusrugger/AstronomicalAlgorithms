using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanMeeus
{
    public class JulianCalendar : Calendar
    {
        public static new JulianCalendar Create(int year, int month, double day)
        {
            double jd = JeanMeeus.JulianDay.JulianDateToJulianDay(year, month, day);
            return new JulianCalendar(jd);
        }

        public static new JulianCalendar Create(Date date)
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

        public static JulianCalendar Create(GregorianCalendar date)
        {
            return new JulianCalendar(date.JulianDay);
        }

        public JulianCalendar(double julianDay)
        : base(julianDay)
        { }

        public override Date Date
        {
            get
            {
                double adjustedJD = JulianDay + 0.5;
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
