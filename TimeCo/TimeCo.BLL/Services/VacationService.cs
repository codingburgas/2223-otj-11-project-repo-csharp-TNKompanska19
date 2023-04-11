using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;

namespace TimeCo.BLL.Services
{
    public class VacationService
    { 
        public static void GetUserVacation(string username)
        {
            Vacation userVacation = VacationRepository.GetUserVacation(username);
            //Console.WriteLine($"Name: {userVacation.Name}, Description: {userVacation.Description}, Status: {userVacation.Status}");
        }

        public static void AddUserVacation(string name, string description, string startDate, string endDate, string username, string status = "Pending", string isMainVacation = "yes")
        {
            using TimeCoContext context = new TimeCoContext();

            var user = context.Users.FirstOrDefault(user => user.Username == username);

            bool flag = false;

            if (isMainVacation == "yes")
            {
                flag = true;
                user.MainVacationHours -= TimeCo.Utilities.Converter.GetDaysVacation
                (TimeCo.Utilities.Converter.ToDate(startDate), TimeCo.Utilities.Converter.ToDate(endDate)) * 8;
            }

            Vacation vacation = new Vacation()
            {
                Name = name,
                Description = description,
                Status = status,
                StartDate = TimeCo.Utilities.Converter.ToDate(startDate),
                EndDate = TimeCo.Utilities.Converter.ToDate(endDate),
                isMainVacation = flag,
                UserId = user.Id
            };

            UserRepository.UpdateUser(user);
            VacationRepository.AddVacation(vacation);
        }
    }
}
