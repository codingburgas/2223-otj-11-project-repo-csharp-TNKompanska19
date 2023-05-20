using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;

namespace TimeCo.DAL.Repositories
{
    public class RoleRepository
    {
        private TimeCoContext _context;
        private UserRepository _userRepository;
        public RoleRepository()
        {
            _context = new TimeCoContext();
            _userRepository = new UserRepository();
        }

        public Role GetUserRole(string username)
        {
            User user = _userRepository.GetUser(username);

            return _context.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault();
        }
    }
}
