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
    public class DepartmentService
    {
        public static void GetAllDepartments()
        {
            //List<Department> departmentList = DepartmentRepository.GetDepartments();

            /*foreach (Department department in departmentList)
            {
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, Description: {department.Description}");
            }*/
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
    }
}
