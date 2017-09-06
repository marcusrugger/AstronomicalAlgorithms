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

    public abstract class Calendar
    {
        private readonly double _JulianDay;

        protected Calendar(double julianDay)
        {
            _JulianDay = julianDay;
        }

        protected Calendar(Calendar date)
        {
            _JulianDay = date.JulianDay;
        }

        public abstract Calendar Clone();

        protected abstract Calendar Instantiate(double jd);

        public double JulianDay
        {
            get { return _JulianDay; }
        }

        public abstract Date Date { get; }

        public static double operator -(Calendar d1, Calendar d2)
        {
            return d1.JulianDay - d2.JulianDay;
        }

        public static Calendar operator +(Calendar date, double d)
        {
            return date.Instantiate(date.JulianDay + d);
        }

        public static Calendar operator -(Calendar date, double d)
        {
            return date.Instantiate(date.JulianDay - d);
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
