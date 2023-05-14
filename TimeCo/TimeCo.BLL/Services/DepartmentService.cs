using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;
using TimeCo.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace TimeCo.BLL.Services
{
    public class DepartmentService
    {
        public static void GetAllDepartments()
        {
            List<Department> departmentList = DepartmentRepository.GetDepartmentsList();

            int y = 15;
            foreach (Department department in departmentList)
            {
                Console.SetCursorPosition(30, y);
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, Description: {department.Description}");
                y++;
            }
        }

        public static void GetUserDepartment(string username)
        {
            Department userDepartment = DepartmentRepository.GetUserDepartment(username);

            //Console.WriteLine($"Name: {userDepartment.Name}, Description: {userDepartment.Description}");
        }

        public static void AddDepartment(string name, string description)
        {
            Department department = new Department()
            {
                Name = name,
                Description = description
            };

            DepartmentRepository.AddDepartment(department);
        }

        public static void UpdateDepartment(string name, string editedName, string editedDescription)
        {

            using TimeCoContext context = new TimeCoContext();

            var department = context.Departments.FirstOrDefault(item => item.Name == name);

            if (department != null)
            {
                department.Name = editedName;
                department.Description = editedDescription;
            }
            DepartmentRepository.UpdateDepartment(department);
        }

        public static void GetUsersDepartments(string departmentName)
        {
            using (var context = new TimeCoContext())
            {
                var results = from department in context.Departments
                              join user in context.Users
                              on department.Id equals user.DepartmentId
                              where department.Name == departmentName
                              select new { user.FirstName, user.LastName, department.Name };

                int y = 25;
                foreach (var item in results.ToList())
                {
                    Console.SetCursorPosition(40, y);
                    Console.WriteLine("{0}: {1} {2}", item.Name, item.FirstName, item.LastName);
                    y++;
                }

              
            }
        }


    }
}
