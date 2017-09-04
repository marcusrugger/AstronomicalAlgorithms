using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanMeeus
{
    public struct Date
    {
        public int Year;
        public int Month;
        public double Day;
    }

    public class Calendar
    {
        private double _JulianDay;

        public Calendar(double julianDay)
        {
            _JulianDay = julianDay;
        }

        public double JulianDay
        {
            get { return _JulianDay; }
        }

        public virtual Date Date { get;}
    }

    public class JulianCalendar : Calendar
    {
        public JulianCalendar Create(int year, int month, double day)
        {
            double jd = JeanMeeus.JulianDay.JulianDateToJulianDay(year, month, day);
            return new JulianCalendar(jd);
        }

        public JulianCalendar Create(GregorianCalendar date)
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
                return new Date();
            }
        }
    }
}
