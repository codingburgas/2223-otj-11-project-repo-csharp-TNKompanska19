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
        private TimeCoContext _context;

        public UserRepository()
        {
            _context = new TimeCoContext();
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users.Select(x => x);
        }

        public  List<User> GetUsersList()
        {

            return _context.Users.Select(x => x).ToList();
        }
        public User GetUser(string username)
        {
            return _context.Users.Where(x => x.Username == username).FirstOrDefault();
        }

        public int GetUserId(string username)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            return user.Id;
        }
        public List<User> GetAllAdmins()
        {
            
            var role = _context.Roles.FirstOrDefault(role => role.Name == "Admin");

            return _context.Users.Where(x => x.RoleId == role.Id).ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void MakeUserAnAdmin(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }
    }
}
