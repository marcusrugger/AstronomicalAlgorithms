﻿using System;

namespace JeanMeeus
{
    public class WesternCalendar : Calendar
    {
        public const int REFORM_YEAR = 1582;
        public const int REFORM_MONTH = Month.October;
        public const double REFORM_JULIAN_DAY = 2299161.5;

        public static double ToJulianDay(int year, int month, double day)
        {
            double jd;

            if (year > REFORM_YEAR)
                jd = GregorianCalendar.ToJulianDay(year, month, day);
            else if (year < REFORM_YEAR)
                jd = JulianCalendar.ToJulianDay(year, month, day);
            else if (month > REFORM_MONTH)
                jd = GregorianCalendar.ToJulianDay(year, month, day);
            else if (month < REFORM_MONTH)
                jd = JulianCalendar.ToJulianDay(year, month, day);
            else if (day >= 15.0)
                jd = GregorianCalendar.ToJulianDay(year, month, day);
            else if (day < 5.0)
                jd = JulianCalendar.ToJulianDay(year, month, day);
            else
                throw new ArgumentOutOfRangeException("Invalid date: Date cannot be between Oct 4, 1582 and Oct 15, 1582");

            return jd;
        }

        public static bool IsLeapYear(int year) => year <= REFORM_YEAR ? JulianCalendar.IsLeapYear(year)
                                                                       : GregorianCalendar.IsLeapYear(year);

        public static bool IsLeapYear(Date date) => IsLeapYear(date.Year);

        public static Date FromJulianDay(double JD) => (JD < REFORM_JULIAN_DAY) ? JulianCalendar.FromJulianDay(JD)
                                                                                : GregorianCalendar.FromJulianDay(JD);

        public static WesternCalendar Create(double JD) => new WesternCalendar(JD);
        public static WesternCalendar Create(int year, int month, double day) => Create(ToJulianDay(year, month, day));
        public static WesternCalendar Create(Date date) => Create(date.Year, date.Month, date.Day);
        public static WesternCalendar Create(Calendar calendar) => Create(calendar.JulianDay);

        private WesternCalendar(double julianDay)
        : base(julianDay)
        { }

        private WesternCalendar(WesternCalendar date)
        : base(date.JulianDay)
        { }

        public override Calendar Clone() => new WesternCalendar(this);

        protected override Calendar Instantiate(double jd) => new WesternCalendar(jd);

        public override Date Date => FromJulianDay(JulianDay);
    }
}
