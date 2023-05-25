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
        private TimeCoContext _context;
        private DepartmentRepository _departmentRepository;
        public DepartmentService()
        {
            _context = new TimeCoContext();
            _departmentRepository = new DepartmentRepository();
        }

        public void GetAllDepartments()
        {
            List<Department> departmentList = _departmentRepository.GetDepartmentsList();

            int y = 15;
            foreach (Department department in departmentList)
            {
                Console.SetCursorPosition(30, y);
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, Description: {department.Description}");
                y++;
            }
        }

        public void GetUserDepartment(string username)
        {
            Department userDepartment = _departmentRepository.GetUserDepartment(username);

            //Console.WriteLine($"Name: {userDepartment.Name}, Description: {userDepartment.Description}");
        }

        public void AddDepartment(string name, string description)
        {
            Department department = new Department()
            {
                Name = name,
                Description = description
            };

            _departmentRepository.AddDepartment(department);
        }

        public void UpdateDepartment(string name, string editedName, string editedDescription)
        {
            var department = _context.Departments.FirstOrDefault(item => item.Name == name);

            if (department != null)
            {
                department.Name = editedName;
                department.Description = editedDescription;
            }
            _departmentRepository.UpdateDepartment(department);
        }

        public List<DepartmentDTO> GetUsersDepartments(string departmentName)
        {
            using (_context)
            {
                var results = from department in _context.Departments
                              join user in _context.Users
                              on department.Id equals user.DepartmentId
                              where department.Name == departmentName
                              select new DepartmentDTO
                              { 
                                  FirstName = user.FirstName, 
                                  LastName = user.LastName, 
                                  DepartmentName = department.Name 
                              };

                List<DepartmentDTO> result = results.ToList();
                return result;  
            }
        }


    }
}
