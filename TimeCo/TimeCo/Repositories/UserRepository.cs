using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;

namespace TimeCo.DAL.Repositories
{
    public class UserRepository
    {
        public static List<User> GetUsers()
        {
            using TimeCoContext context = new TimeCoContext();

            return context.Users.Select(x => x).ToList();
        }
        public static User GetUser(string username)
        {
            using TimeCoContext context = new TimeCoContext();

            return context.Users.Where(x => x.Username == username).FirstOrDefault();
        }
    }
}
