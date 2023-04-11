using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;

namespace TimeCo.BLL.Services
{
    public class RoleService
    {
        public static void GetUserRole(string username)
        {
                Role userRole = RoleRepository.GetUserRole(username);
               // Console.WriteLine($"Role: {userRole.Name}, Description: {userRole.Description}");
        }
    }
}
