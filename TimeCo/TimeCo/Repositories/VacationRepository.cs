using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;

namespace TimeCo.DAL.Repositories
{
    public class VacationRepository
    {
        private TimeCoContext _context;
        private UserRepository _userRepository;

        public VacationRepository()
        {
            _context = new TimeCoContext();
            _userRepository = new UserRepository();
        }

        public Vacation GetUserVacation(string username)
        {
            User user = _userRepository.GetUser(username);

            return _context.Vacations.Where(x => x.UserId == user.Id).FirstOrDefault();
        }

        public List<Vacation> GetPendingVacationList()
        {
            return _context.Vacations.Where(x => x.Status == "Pending").ToList();
        }

        public void AddVacation(Vacation vacation)
        {
            _context.Vacations.Add(vacation);

            _context.SaveChanges();
        }

        public void UpdateVacation(Vacation vacation)
        {
            _context.Vacations.Update(vacation);

            _context.SaveChanges();
        }
    }
}
