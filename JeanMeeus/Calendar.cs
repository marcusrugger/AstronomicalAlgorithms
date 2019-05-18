using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanMeeus
{
    public enum Weekday : byte
    {
        Sunday = 0x01,
        Monday = 0x02,
        Tuesday = 0x04,
        Wednesday = 0x08,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40,
        Weekend = Saturday | Sunday,
        Weekday = Monday | Tuesday | Wednesday | Thursday | Friday
    }

    public static class WeekdayMethods
    {
        public static Weekday[] DaysOfWeek = new Weekday[7]
        {
            Weekday.Sunday,
            Weekday.Monday,
            Weekday.Tuesday,
            Weekday.Wednesday,
            Weekday.Thursday,
            Weekday.Friday,
            Weekday.Saturday
        };

        public static Weekday FromIndex(int dayOfWeek)
        {
            if (dayOfWeek < 0 || dayOfWeek >= 7)
                throw new ArgumentOutOfRangeException($"dayOfWeek must be 0-6, actual value was {dayOfWeek}");

            return DaysOfWeek[dayOfWeek];
        }

        public static int ToIndex(Weekday day)
        {
            switch (day)
            {
                case Weekday.Sunday:
                    return 0;

                case Weekday.Monday:
                    return 1;

                case Weekday.Tuesday:
                    return 2;

                case Weekday.Wednesday:
                    return 3;

                case Weekday.Thursday:
                    return 4;

                case Weekday.Friday:
                    return 5;

                case Weekday.Saturday:
                    return 6;

                default:
                    throw new ArgumentOutOfRangeException($"day not set to valid day of week: actual value is {day}");
            }
        }

        public static Weekday Add(Weekday day, int value)
        {
            int a = (ToIndex(day) + value) % 7;
            if (a < 0) a = 7 + a;
            return FromIndex(a);
        }
    }

    public static class Month
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

        public Weekday DayOfWeek
        {
            get
            {
                return WeekdayMethods.FromIndex((int)((JulianDay + 1.5) % 7.0));
            }
        }
    }
}
