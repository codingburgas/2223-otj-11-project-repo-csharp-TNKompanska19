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
    public class DepartmentRepository
    {
        public static List<Department> GetDepartments()
        {
            using TimeCoContext context = new TimeCoContext();

            return context.Departments.Select(x => x).ToList();
        }

        public static Department GetUserDepartment(string username)
        {
            using TimeCoContext context = new TimeCoContext();

            User user = UserRepository.GetUser(username);

            return context.Departments.Where(x => x.Id == user.DepartmentId).FirstOrDefault();
        }


    }
}
