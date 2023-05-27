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
        // Private fields
        private TimeCoContext _context;
        private UserRepository _userRepository;

        // Constructor
        public VacationRepository()
        {
            _context = new TimeCoContext();
            _userRepository = new UserRepository();
        }

        // Method for adding vacation
        public void AddVacation(Vacation vacation)
        {
            _context.Vacations.Add(vacation);

            _context.SaveChanges();
        }

        // Method for updating vacation
        public void UpdateVacation(Vacation vacation)
        {
            _context.Vacations.Update(vacation);

            _context.SaveChanges();
        }
    }
}
