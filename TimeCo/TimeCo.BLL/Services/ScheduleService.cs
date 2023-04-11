using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;

namespace TimeCo.BLL.Services
{
    public class ScheduleService
    {
        public static void GetUserSchedule(string username)
        {
            Schedule userSchedule = ScheduleRepository.GetUserSchedule(username);
            //Console.WriteLine($"Shift: {userSchedule.Shift}, Start Date: {userSchedule.StartDate}, End Date: {userSchedule.EndDate}, Start Hour: {userSchedule.StartHour}, End Hour: {userSchedule.EndHour}");
        }
    }
}
