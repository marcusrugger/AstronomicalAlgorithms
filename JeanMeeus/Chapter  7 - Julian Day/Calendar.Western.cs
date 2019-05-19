using System;

namespace JeanMeeus
{
    public class WesternCalendar : Calendar
    {
        public static WesternCalendar Create(double JD)
        {
            return new WesternCalendar(JD);
        }

        public static WesternCalendar Create(int year, int month, double day)
        {
            double jd;

            if (year > 1582)
                jd = GregorianCalendar.ToJulianDay(year, month, day);
            else if (year < 1582)
                jd = JulianCalendar.ToJulianDay(year, month, day);
            else if (month > Month.October)
                jd = GregorianCalendar.ToJulianDay(year, month, day);
            else if (month < Month.October)
                jd = JulianCalendar.ToJulianDay(year, month, day);
            else if (day >= 15.0)
                jd = GregorianCalendar.ToJulianDay(year, month, day);
            else if (day < 5.0)
                jd = JulianCalendar.ToJulianDay(year, month, day);
            else
                throw new ArgumentOutOfRangeException("Invalid date: Date cannot be between Oct 4, 1582 and Oct 15, 1582");

            return Create(jd);
        }

        public static WesternCalendar Create(Date date)
        {
            return Create(date.Year, date.Month, date.Day);
        }

        private WesternCalendar(double julianDay)
        : base(julianDay)
        { }

        private WesternCalendar(WesternCalendar date)
        : base(date.JulianDay)
        { }

        public override Calendar Clone()
        {
            return new WesternCalendar(this);
        }

        protected override Calendar Instantiate(double jd)
        {
            return new WesternCalendar(jd);
        }

        public override Date Date
        {
            get
            {
                return (JulianDay < 2299161.5) ? JulianCalendar.FromJulianDay(JulianDay)
                                               : GregorianCalendar.FromJulianDay(JulianDay);
            }
        }
    }
}
