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
        public static IQueryable<User> GetAllUsers()
        {
            using TimeCoContext context = new TimeCoContext();

            return context.Users.Select(x => x);
        }

        public static User GetUser(string username)
        {
            using TimeCoContext context = new TimeCoContext();

            return context.Users.Where(x => x.Username == username).FirstOrDefault();
        }

        public static List<User> GetAllAdmins()
        {
            using TimeCoContext context = new TimeCoContext();

            var role = context.Roles.FirstOrDefault(role => role.Name == "Admin");

            return context.Users.Where(x => x.RoleId == role.Id).ToList();
        }

        public static void AddUser(User user)
        {
            using TimeCoContext context = new TimeCoContext();

            context.Users.Add(user);

            context.SaveChanges();
        }

        public static void MakeUserAnAdmin(User user)
        {
            using TimeCoContext context = new TimeCoContext();

            context.Users.Update(user);

            context.SaveChanges();

        }

        public static void UpdateUser(User user)
        {
            using TimeCoContext context = new TimeCoContext();

            context.Users.Update(user);

            context.SaveChanges();
        }
    }
}
