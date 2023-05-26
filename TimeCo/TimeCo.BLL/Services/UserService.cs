using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;
using TimeCo.BLL.Models;

namespace TimeCo.BLL.Services
{
    public class UserService
    {
        private TimeCoContext _context;
        private DepartmentRepository _departmentRepository;
        private UserRepository _userRepository;
        private TimeCo.Utilities.Converter _converter;
        public UserService()
        {
            _context = new TimeCoContext();
            _departmentRepository = new DepartmentRepository();
            _userRepository = new UserRepository(); 
            _converter = new Utilities.Converter();
        }

        public List<UserDTO> GetUsersDepartments()
        {
            var userList = from user in _userRepository.GetAllUsers()
                           join department in _departmentRepository.GetDepartments() on
                           user.DepartmentId equals department.Id
                           select new UserDTO
                           {
                               FirstName = user.FirstName,
                               LastName = user.LastName,
                               Email = user.Email,
                               DepartmentName = department.Name
                           };

            return userList.ToList();
        }

        public void GetAllUsers()
        {
            List<User> userList = _userRepository.GetUsersList();
            int x = 30, y = 10;
            foreach (User user in userList)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Username: {user.Username}");
                y++;
            }
        }

        public bool CheckUser(string username, string password)
        {

            var user = _context.Users.FirstOrDefault(user => user.Username == username && user.Password == password);

            return user != null;
        }

        public bool CheckAdmin(string username)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            var role = _context.Roles.FirstOrDefault(role => role.Name == "Admin");
            return user.RoleId == role.Id;
        }

        public void GetUser(string username)
        {
            User user = _userRepository.GetUser(username);

            //Console.WriteLine($"Username: {user.Username}");
        }

        public void GetAllAdmins()
        {
            List<User> adminList = _userRepository.GetAllAdmins();

            /*foreach (User user in adminList)
            {
                Console.WriteLine($"ID: {user.Id}, Username: {user.Username}, Email: {user.Email}");
            }*/
        }

        public void MakeUserAnAdmin(string username)
        {

            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            var role = _context.Roles.FirstOrDefault(role => role.Name == "Admin");

            if (user != null)
            {
                user.RoleId = role.Id;
            }
            _userRepository.MakeUserAnAdmin(user);
        }

        public  void AddUser(string firstName, string lastName, string email, string password, string username, string departmentName, string roleName = "Standard")
        {

            var department = _context.Departments.FirstOrDefault(item => item.Name == departmentName);
            var role = _context.Roles.FirstOrDefault(role => role.Name == roleName);

            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Username = username,
                CreatedAt = _converter.GetCurrentTime(),
                ModifiedAt = _converter.GetCurrentTime(),
                MainVacationHours = 200,
                RoleId = role.Id,
                DepartmentId = department.Id
            };

            _userRepository.AddUser(user);
        }

        public void UpdateUser(string username, string firstName, string lastName, string newUsername)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            user.Username = newUsername;
            user.FirstName = firstName;
            user.LastName = lastName;

            _userRepository.UpdateUser(user);

        }

        public void AddUserToDepartment(string username, string departmentName)
        {
            var user =_context.Users.FirstOrDefault(user => user.Username == username);
            var department =_context.Departments.FirstOrDefault(department => department.Name == departmentName);
            user.DepartmentId = department.Id;
            
            _userRepository.UpdateUser(user);

        }
    }
}
