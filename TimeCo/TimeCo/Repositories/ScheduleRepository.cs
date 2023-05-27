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
        // Private fields
        private TimeCoContext _context;
        private UserRepository _userRepository;

        // Constructor
        public ScheduleRepository()
        {
            _context = new TimeCoContext();
            _userRepository = new UserRepository();
        }

        // Method for adding schedule
        public void AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);

            _context.SaveChanges();
        }
    }
}
