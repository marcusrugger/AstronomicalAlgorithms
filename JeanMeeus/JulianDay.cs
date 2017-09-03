using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanMeeus
{
    public class JulianDay
    {
        public static double GregorianDateToJulianDay(int year, int month, double day)
        {
            double Y = year;
            double M = month;
            double D = day;

            /* If the month is January or Febuary, consider it to be the 13th or 14th month of the preceding year */
            if (month == 1 || month == 2)
            {
                Y = year - 1;
                M = month + 12;
            }

            double A = Math.Truncate(Y / 100.0);
            double B = 2.0 - A + Math.Truncate(A / 4.0);

            double JD = Math.Truncate(365.25 * (Y + 4716.0)) +
                        Math.Truncate(30.6001 * (M + 1.0)) +
                        D + B - 1524.5;

            /* Note from Jean:
             * 
             * The number 30.6 (instead of 30.6001) will give the correct result but 30.6001 is used so
             * that the proper integer will always be obtained.  [In fact, instead of 30.6001, one may use 30.601,
             * or even 30.61.]  For instance, 5 times 30.6 gives 153 exactly.  However, most computers would not
             * represent 30.6 exactly -- see in Chapter 2 what we said about BCD -- and might give a result of
             * 152.999 9998 instead, whose integer part is 152. The calculated JD would then be incorrect.
             */

            return JD;
        }
    }
}
