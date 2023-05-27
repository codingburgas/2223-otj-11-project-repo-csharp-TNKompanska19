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
    public class RoleService
    {
        // Private fields
        private TimeCoContext _context;
        private RoleRepository _roleRepository;

        // Constructor
        public RoleService()
        {
            _context = new TimeCoContext();
            _roleRepository = new RoleRepository();
        }

        // Function for checking if the user is admin
        public bool CheckAdmin(string username)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            var role = _context.Roles.FirstOrDefault(role => role.Name == "Admin");
            return user.RoleId == role.Id;
        }
    }
}
