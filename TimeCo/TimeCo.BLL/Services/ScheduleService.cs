using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.Utilities;
using TimeCo.DAL.Data;
using Microsoft.SqlServer.Management.HadrData;

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

        public void GetUserSchedule(string username)
        {
            using (_context)
            {
                var results = from schedule in _context.Schedules
                              join user in _context.Users on schedule.UserId equals user.Id
                              where user.Username == username
                              select new
                              {
                                  schedule.StartDate,
                                  schedule.EndDate,
                                  schedule.StartHour,
                                  schedule.EndHour
                              };

                int y = 25;
                foreach (var item in results.ToList())
                {
                    Console.SetCursorPosition(35, y);
                    Console.WriteLine("Dates: {0} - {1}; Hours: {2} - {3}", _converter.DateOnly(item.StartDate), _converter.DateOnly(item.EndDate), item.StartHour, item.EndHour);
                    y++;
                }
            }
        }
    }
}
