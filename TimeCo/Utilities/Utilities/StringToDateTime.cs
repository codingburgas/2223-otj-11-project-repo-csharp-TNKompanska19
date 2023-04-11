using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Utilities
{
    public class Converter
    {
        public static DateTime ToDate(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "dd-MM-yyyy", null);
            return date;
        }

        public static TimeSpan ToHour(string timeString)
        {
            TimeSpan time = TimeSpan.ParseExact(timeString, "h\\:mm", null);
            return time;
        }

        public static DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        public static string GetDayOfWeek(DateTime date)
        {
            return date.ToString("dddd");
        }

        public static double GetDaysVacation(DateTime startDate, DateTime endDate)
        {
            int counter = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (GetDayOfWeek(date) == "Saturday" || GetDayOfWeek(date) == "Sunday")
                {
                    counter++;
                }
            }

            TimeSpan timeSpan = endDate - startDate;
            return timeSpan.Days + 1 - counter;
        }
    }
}

