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
using TimeCo.BLL.Models;

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

        public List<ScheduleDTO> GetUserSchedule(string username)
        {
            using (_context)
            {
                var results = from schedule in _context.Schedules
                              join user in _context.Users on schedule.UserId equals user.Id
                              where user.Username == username
                              select new ScheduleDTO
                              {
                                  StartDate = schedule.StartDate,
                                  EndDate = schedule.EndDate,
                                  StartHour = schedule.StartHour,
                                  EndHour = schedule.EndHour
                              };  

                List<ScheduleDTO> result = results.ToList();
                return result;
            }
        }

        public List<ScheduleDTO> GetCollsSchedule(string username)
        {
            using (var context = new TimeCoContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                var userDepartment = context.Departments.FirstOrDefault(d => d.Id == user.DepartmentId);

                var results = from users in context.Users
                              join schedule in context.Schedules on users.Id equals schedule.UserId
                              where userDepartment.Id == user.DepartmentId
                              select new ScheduleDTO
                              {
                                  Username = users.Username,
                                  StartDate = schedule.StartDate,
                                  EndDate = schedule.EndDate,
                                  StartHour = schedule.StartHour,
                                  EndHour = schedule.EndHour
                              };

                List<ScheduleDTO> result = results.ToList();
                return result;
            }
        }

    }
}
