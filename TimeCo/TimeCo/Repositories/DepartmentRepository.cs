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
        // Private fields
        private TimeCoContext _context;
        private UserRepository _userRepository;

        // Constructor
        public DepartmentRepository()
        {
            _context = new TimeCoContext();
            _userRepository = new UserRepository();
        }

        // Method for returning all departments
        public List<Department> GetDepartmentsList()
        {
            return _context.Departments.Select(x => x).ToList();
        }

        // Method for adding departments
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);

            _context.SaveChanges();
        }

        // Method for updating department
        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);

            _context.SaveChanges();
        }
    }
}
