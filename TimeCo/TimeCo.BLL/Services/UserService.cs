using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;

namespace TimeCo.BLL.Services
{
    public class UserService
    {
        public static void GetAllUsers()
        {
            List<User> userList = UserRepository.GetUsers();

            /*foreach (User user in userList)
            {
                Console.WriteLine($"ID: {user.Id}, Username: {user.Username}, Email: {user.Email}");
            }*/
        }
    }
}
