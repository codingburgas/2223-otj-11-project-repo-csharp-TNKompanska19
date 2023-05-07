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
        public static IQueryable<Department> GetDepartments()
        {
            using TimeCoContext context = new TimeCoContext();

            return context.Departments.Select(x => x);
        }

        public static List<Department> GetDepartmentsList()
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

        public static void AddDepartment(Department department)
        {
            using TimeCoContext context = new TimeCoContext();

            context.Departments.Add(department);

            context.SaveChanges();
        }

        public static void UpdateDepartment(Department department)
        {
            using TimeCoContext context = new TimeCoContext();

            context.Departments.Update(department);

            context.SaveChanges();
        }
    }
}
