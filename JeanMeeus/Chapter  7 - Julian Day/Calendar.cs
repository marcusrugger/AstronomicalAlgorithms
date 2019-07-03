using System;

namespace JeanMeeus
{
    public abstract class Calendar
    {
        public readonly double JulianDay;

        protected Calendar(double julianDay) => JulianDay = julianDay;
        protected Calendar(Calendar date) => JulianDay = date.JulianDay;

        public abstract Calendar Clone();

        protected abstract Calendar Instantiate(double jd);

        public abstract Date Date { get; }

        public static double operator -(Calendar d1, Calendar d2) => d1.JulianDay - d2.JulianDay;

        public static Calendar operator +(Calendar date, double d) => date.Instantiate(date.JulianDay + d);

        public static Calendar operator -(Calendar date, double d) => date.Instantiate(date.JulianDay - d);
    }
}
