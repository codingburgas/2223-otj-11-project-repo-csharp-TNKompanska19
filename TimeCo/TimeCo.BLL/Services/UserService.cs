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
        public static List<UserDTO> GetUsersDepartments()
        {
            var userList = from user in UserRepository.GetAllUsers()
                           join department in DepartmentRepository.GetDepartments() on
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

        public static void GetAllUsers()
        {
            List<User> userList = UserRepository.GetUsersList();

            foreach (User user in userList)
            {
                Console.WriteLine($"ID: {user.Id}, FirstName: {user.FirstName}, LastName: {user.LastName}");
            }
        }

        public static bool CheckUser(string username, string password)
        {
            using TimeCoContext context = new TimeCoContext();

            var user = context.Users.FirstOrDefault(user => user.Username == username && user.Password == password);

            return user != null;
        }

        public static bool CheckAdmin(string username)
        {
            using TimeCoContext context = new TimeCoContext();

            var user = context.Users.FirstOrDefault(user => user.Username == username);

            return user.RoleId == 2;
        }

        public static void GetUser(string username)
        {
            User user = UserRepository.GetUser(username);

            //Console.WriteLine($"Username: {user.Username}");
        }

        public static void GetAllAdmins()
        {
            List<User> adminList = UserRepository.GetAllAdmins();

            /*foreach (User user in adminList)
            {
                Console.WriteLine($"ID: {user.Id}, Username: {user.Username}, Email: {user.Email}");
            }*/
        }

        public static void MakeUserAnAdmin(string username)
        {

            using TimeCoContext context = new TimeCoContext();

            var user = context.Users.FirstOrDefault(user => user.Username == username);
            var role = context.Roles.FirstOrDefault(role => role.Name == "Admin");

            if (user != null)
            {
                user.RoleId = role.Id;
            }
            UserRepository.MakeUserAnAdmin(user);
        }

        public static void AddUser(string firstName, string lastName, string email, string password, string username, string departmentName, string roleName = "Standard")
        {
            using TimeCoContext context = new TimeCoContext();

            var department = context.Departments.FirstOrDefault(item => item.Name == departmentName);
            var role = context.Roles.FirstOrDefault(role => role.Name == roleName);

            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Username = username,
                CreatedAt = TimeCo.Utilities.Converter.GetCurrentTime(),
                ModifiedAt = TimeCo.Utilities.Converter.GetCurrentTime(),
                MainVacationHours = 200,
                RoleId = role.Id,
                DepartmentId = department.Id
            };

            UserRepository.AddUser(user);
        }

        public static void UpdateUser(string username, string firstName, string lastName, string newUsername)
        {
            using TimeCoContext context = new TimeCoContext();

            var user = context.Users.FirstOrDefault(user => user.Username == username);
            user.Username = newUsername;
            user.FirstName = firstName;
            user.LastName = lastName;

            UserRepository.UpdateUser(user);
        }

        /*public static bool checkUser (string username, string password)
        {
            using TimeCoContext context = new TimeCoContext();

            List<User> users = UserRepository.GetAllUsers();

            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password) return true;
            }

            return false;
        }*/
    }
}
