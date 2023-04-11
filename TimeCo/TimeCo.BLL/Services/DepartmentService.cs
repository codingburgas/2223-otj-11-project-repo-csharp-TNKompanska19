using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;

namespace TimeCo.BLL.Services
{
    public class DepartmentService
    {
        public static void GetAllDepartments()
        {
            List<Department> departmentList = DepartmentRepository.GetDepartments();

            /*foreach (Department department in departmentList)
            {
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, Description: {department.Description}");
            }*/
        }
    }
}
