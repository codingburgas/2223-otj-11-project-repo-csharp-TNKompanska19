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
        // Private fields
        private TimeCoContext _context;
        private DepartmentRepository _departmentRepository;

        // Constructor
        public DepartmentService()
        {
            _context = new TimeCoContext();
            _departmentRepository = new DepartmentRepository();
        }

        // Method for viewing all departments
        public List<Department> GetAllDepartments()
        {
            List<Department> departmentList = _departmentRepository.GetDepartmentsList();

            return departmentList;
            
        }  

        // Method for adding department 
        public void AddDepartment(string name, string description)
        {
            Department department = new Department()
            {
                Name = name,
                Description = description
            };

            _departmentRepository.AddDepartment(department);
        }

        // Method for editing department
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

        // Method for returning all users in a given department
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
