using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanMeeus
{
    public class Weekdays
    {
        public const int Sunday = 0;
        public const int Monday = 1;
        public const int Tuesday = 2;
        public const int Wednesday = 3;
        public const int Thursday = 4;
        public const int Friday = 5;
        public const int Saturday = 6;
    }

    public class Months
    {
        public const int January = 1;
        public const int Febuary = 2;
        public const int March = 3;
        public const int April = 4;
        public const int May = 5;
        public const int June = 6;
        public const int July = 7;
        public const int August = 8;
        public const int September = 9;
        public const int October = 10;
        public const int November = 11;
        public const int December = 12;
    }

    public struct Date
    {
        public int Year;
        public int Month;
        public double Day;
    }

    public class Calendar
    {
        public static Calendar Create(int year, int month, double day)
        {
            double jd;

            if (year > 1582)
                jd = JeanMeeus.JulianDay.GregorianDateToJulianDay(year, month, day);
            else if (year < 1582)
                jd = JeanMeeus.JulianDay.JulianDateToJulianDay(year, month, day);
            else if (month < Months.October)
                jd = JeanMeeus.JulianDay.JulianDateToJulianDay(year, month, day);
            else if (month > Months.October)
                jd = JeanMeeus.JulianDay.GregorianDateToJulianDay(year, month, day);
            else if (day < 5.0)
                jd = JeanMeeus.JulianDay.JulianDateToJulianDay(year, month, day);
            else if (day >= 15.0)
                jd = JeanMeeus.JulianDay.GregorianDateToJulianDay(year, month, day);
            else
                throw new ArgumentOutOfRangeException("Invalid date: Date cannot be between Oct 4, 1582 and Oct 15, 1582");

            return new Calendar(jd);
        }

        public static Calendar Create(Date date)
        {
            return Create(date.Year, date.Month, date.Day);
        }

        private double _JulianDay;

        public Calendar(double julianDay)
        {
            _JulianDay = julianDay;
        }

        public double JulianDay
        {
            get { return _JulianDay; }
        }

        public virtual Date Date
        {
            get
            {
                double adjustedJD = JulianDay + 0.5;
                double Z = Math.Truncate(adjustedJD);
                double F = adjustedJD - Z;

                double A;
                if (Z < 2299161.0)
                    A = Z;
                else
                {
                    double a = Math.Truncate((Z - 1867216.25) / 36524.25);
                    A = Z + 1 + a - Math.Truncate(a / 4.0);
                }

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

        public static double operator -(Calendar d1, Calendar d2)
        {
            return d1.JulianDay - d2.JulianDay;
        }

        public int DayOfWeek
        {
            get
            {
                return (int)((JulianDay + 1.5) % 7.0);
            }
        }
    }
}
