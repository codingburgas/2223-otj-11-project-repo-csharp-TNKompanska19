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
    public class UserRepository
    {
        // Private field
        private TimeCoContext _context;

        // Constructor
        public UserRepository()
        {
            _context = new TimeCoContext();
        }

        // Method for returning all users
        public  List<User> GetUsersList()
        {
            using (var context = new TimeCoContext()) // Replace YourDbContext with your actual DbContext class
            {
                return context.Users.Select(x => x).ToList();
            }
        }

        // Method for returning user by given username
        public User GetUser(string username)
        {
            return _context.Users.Where(x => x.Username == username).FirstOrDefault();
        }

        // Method for adding user
        public void AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        // Method for making user an admin
        public void MakeUserAnAdmin(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }

        // Method for editin user
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }
    }
}
