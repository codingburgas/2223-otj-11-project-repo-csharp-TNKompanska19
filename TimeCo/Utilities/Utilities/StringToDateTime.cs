using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Utilities
{
    public class Converter
    {
        // Method for returning only the date from DateTime variable
        public string DateOnly(DateTime dateTime)
        {
            DateTime dateOnly = dateTime.Date;
            return dateOnly.ToString("dd/MM/yyyy");
        }
       
        // Method for parsing string to DateTime
        public DateTime ToDate(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "dd-MM-yyyy", null);
            return date;
        }

        // Method for parsing string to TimeSpan
        public TimeSpan ToHour(string timeString)
        {
            TimeSpan time = TimeSpan.ParseExact(timeString, "h\\:mm", null);
            return time;
        }

        // Method for getting current time
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        // Method for getting day of the week
        public string GetDayOfWeek(DateTime date)
        {
            return date.ToString("dddd");
        }

        // Method for getting vacation's days
        public double GetDaysVacation(DateTime startDate, DateTime endDate)
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

