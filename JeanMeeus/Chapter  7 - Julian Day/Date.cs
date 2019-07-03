using System;

namespace JeanMeeus
{
    public struct Date
    {
        public readonly int Year;
        public readonly int Month;
        public readonly double Day;

        public static Date Now => new Date(DateTime.Now);

        public Date(int year, int month, double day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public Date(DateTime dt)
        {
            double d = dt.Millisecond;
            d = dt.Second + d / 1000.0;
            d = dt.Minute + d / 60.0;
            d = dt.Hour + d / 60.0;
            d = dt.Day + d / 24.0;

            Day = d;
            Month = dt.Month;
            Year = dt.Year;
        }

        public DateTime ToDateTime()
        {
            double remainder = Day;
            var day = Math.Truncate(remainder);

            remainder = 24.0 * (remainder - day);
            var hour = Math.Truncate(remainder);

            remainder = 60.0 * (remainder - hour);
            var minute = Math.Truncate(remainder);

            remainder = 60.0 * (remainder - minute);
            var second = Math.Truncate(remainder);

            remainder = 1000.0 * (remainder - second);
            var millisecond = Math.Truncate(remainder + 0.5);

            return new DateTime(
                Year,
                Month,
                (int)day,
                (int)hour,
                (int)minute,
                (int)second,
                (int)millisecond);
        }

        public static implicit operator DateTime(Date date) => date.ToDateTime();
        public static implicit operator Date(DateTime date) => new Date(date);
    }
}
