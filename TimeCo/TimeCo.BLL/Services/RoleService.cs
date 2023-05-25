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
        private TimeCoContext _context;
        private RoleRepository _roleRepository;
        public RoleService()
        {
            _context = new TimeCoContext();
            _roleRepository = new RoleRepository();
        }
        public Role GetUserRole(string username)
        {
            Role userRole = _roleRepository.GetUserRole(username);
            return userRole;
        }
    }
}
