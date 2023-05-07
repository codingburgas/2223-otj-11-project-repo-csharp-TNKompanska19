using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.Utilities;
using TimeCo.DAL.Data;

namespace TimeCo.BLL.Services
{
    public class ScheduleService
    {
        public static void GetUserSchedule(string username)
        {
            //Schedule userSchedule = ScheduleRepository.GetUserSchedule(username);
            //Console.WriteLine($"Shift: {userSchedule.Shift}, Start Date: {userSchedule.StartDate}, End Date: {userSchedule.EndDate}, Start Hour: {userSchedule.StartHour}, End Hour: {userSchedule.EndHour}");
        }

        public static void AddUserSchedule (string userShift, string startDate, string endDate, string startHour, string endHour, string username) 
        {
            using TimeCoContext context = new TimeCoContext();

            var user = context.Users.FirstOrDefault(user => user.Username == username);

            Schedule schedule = new Schedule()
            {
                Shift = userShift,
                StartDate = TimeCo.Utilities.Converter.ToDate(startDate),
                EndDate = TimeCo.Utilities.Converter.ToDate(endDate),
                StartHour = TimeCo.Utilities.Converter.ToHour(startHour),
                EndHour = TimeCo.Utilities.Converter.ToHour(endHour),
                UserId = user.Id
            };

            ScheduleRepository.AddSchedule(schedule);
        }
    }
}
