using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;

namespace TimeCo.BLL.Services
{
    public class VacationService
    { 
        public static void GetUserVacation(string username)
        {
            Vacation userVacation = VacationRepository.GetUserVacation(username);
            //Console.WriteLine($"Name: {userVacation.Name}, Description: {userVacation.Description}, Status: {userVacation.Status}");
        }
    }
}
