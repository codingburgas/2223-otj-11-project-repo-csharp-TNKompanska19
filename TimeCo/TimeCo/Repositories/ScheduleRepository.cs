using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;
using Microsoft.SqlServer.Management.XEvent;

namespace TimeCo.DAL.Repositories
{
    public class ScheduleRepository
    {
        private TimeCoContext _context;
        private UserRepository _userRepository;
        public ScheduleRepository()
        {
            _context = new TimeCoContext();
            _userRepository = new UserRepository();
        }

        public List<Schedule> GetUserSchedule(string username)
        {
            User user = _userRepository.GetUser(username);

            return _context.Schedules.Where(x => x.UserId == user.Id).ToList();
        }

        public Schedule GetSchedule(int id)
        {
            return _context.Schedules.FirstOrDefault(x => x.Id == id);
        }

        public void AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);

            _context.SaveChanges();
        }
    }
}
