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
        private TimeCoContext _context;
        private UserRepository _userRepository;
        public DepartmentRepository()
        {
            _context = new TimeCoContext();
            _userRepository = new UserRepository();
        }

        public IQueryable<Department> GetDepartments()
        {
            return _context.Departments.Select(x => x);
        }

        public List<Department> GetDepartmentsList()
        {
            return _context.Departments.Select(x => x).ToList();
        }


        public Department GetUserDepartment(string username)
        {
            User user = _userRepository.GetUser(username);

            return _context.Departments.Where(x => x.Id == user.DepartmentId).FirstOrDefault();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);

            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);

            _context.SaveChanges();
        }
    }
}
