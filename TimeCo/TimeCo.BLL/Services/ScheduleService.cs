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
        private TimeCoContext _context;
        private ScheduleRepository _scheduleRepository;
        private TimeCo.Utilities.Converter _converter;
        public ScheduleService()
        {
            _context = new TimeCoContext();
            _scheduleRepository = new ScheduleRepository();
            _converter = new TimeCo.Utilities.Converter();
        }

        public static void GetUserSchedule(string username)
        {
            //Schedule userSchedule = ScheduleRepository.GetUserSchedule(username);
            //Console.WriteLine($"Shift: {userSchedule.Shift}, Start Date: {userSchedule.StartDate}, End Date: {userSchedule.EndDate}, Start Hour: {userSchedule.StartHour}, End Hour: {userSchedule.EndHour}");
        }

        public void AddUserSchedule (string userShift, string startDate, string endDate, string startHour, string endHour, string username) 
        {

            var user = _context.Users.FirstOrDefault(user => user.Username == username);

            Schedule schedule = new Schedule()
            {
                Shift = userShift,
                StartDate = _converter.ToDate(startDate),
                EndDate = _converter.ToDate(endDate),
                StartHour = _converter.ToHour(startHour),
                EndHour = _converter.ToHour(endHour),
                UserId = user.Id
            };

            _scheduleRepository.AddSchedule(schedule);
        }
    }
}
