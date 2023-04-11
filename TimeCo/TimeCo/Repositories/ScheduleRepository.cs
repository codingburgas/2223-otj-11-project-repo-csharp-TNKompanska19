using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;

namespace TimeCo.DAL.Repositories
{
    public class ScheduleRepository
    {
        public static Schedule GetUserSchedule(string username)
        {
            using TimeCoContext context = new TimeCoContext();

            User user = UserRepository.GetUser(username);

            return context.Schedules.Where(x => x.UserId == user.Id).FirstOrDefault();
        }

        public static void AddSchedule(Schedule schedule)
        {
            using TimeCoContext context = new TimeCoContext();

            context.Schedules.Add(schedule);

            context.SaveChanges();
        }
    }
}
