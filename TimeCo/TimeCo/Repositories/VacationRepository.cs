using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;

namespace TimeCo.DAL.Repositories
{
    public class VacationRepository
    {
        public static Vacation GetUserVacation(string username)
        {
            using TimeCoContext context = new TimeCoContext();

            User user = UserRepository.GetUser(username);

            return context.Vacations.Where(x => x.UserId == user.Id).FirstOrDefault();
        }
    }
}
