using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.DAL.Data;
using TimeCo.BLL.Models;
using Microsoft.SqlServer.Management.Smo;

namespace TimeCo.BLL.Services
{
    public class VacationService
    {
        private TimeCoContext _context;
        private VacationRepository _vacationRepository;
        private UserRepository _userRepository;
        private TimeCo.Utilities.Converter _converter;

        public VacationService()
        {
            _context = new TimeCoContext();
            _vacationRepository = new VacationRepository();
            _userRepository = new UserRepository();
            _converter = new Utilities.Converter();
        }
        public void AddUserVacation(string name, string description, string startDate, string endDate, string username, string status = "Pending")
        {

            var user = _context.Users.FirstOrDefault(user => user.Username == username);

            bool flag = true;
            
            Vacation vacation = new Vacation()
            {
                Name = name,
                Description = description,
                Status = status,
                StartDate = _converter.ToDate(startDate),
                EndDate = _converter.ToDate(endDate),
                isMainVacation = flag,
                UserId = user.Id
            };

            _vacationRepository.AddVacation(vacation);
        }

        public void ApproveVacation(int id) 
        {
            using (var context = new TimeCoContext())
            {
                var vacation = context.Vacations.FirstOrDefault(item => item.Id == id);
                var user = context.Users.FirstOrDefault(item => item.Id == vacation.UserId);
                if (vacation != null)
                {
                    vacation.Status = "Approved";
                    user.MainVacationHours -= _converter.GetDaysVacation(vacation.StartDate, vacation.EndDate)*8;
                    _vacationRepository.UpdateVacation(vacation);
                    _userRepository.UpdateUser(user);
                }
            }
        }

        public void DenyVacation(int id)
        {
            using (var context = new TimeCoContext()) 
            {
                var vacation = context.Vacations.FirstOrDefault(item => item.Id == id);

                if (vacation != null)
                {
                    vacation.Status = "Denied";
                    _vacationRepository.UpdateVacation(vacation);
                }
            }
        }


        public List<VacationDTO> GetPendingVacations()
        {
            using (_context)
            {
                var results = from vacation in _context.Vacations
                              join user in _context.Users on vacation.UserId equals user.Id
                              where vacation.Status == "Pending"
                              select new VacationDTO
                              {
                                  Id = vacation.Id,
                                  Username = user.Username,
                                  Description = vacation.Description,
                                  StartDate = vacation.StartDate,
                                  EndDate = vacation.EndDate
                              };

                List<VacationDTO> result = results.ToList();
                return result;
            }
        }

        public List<VacationDTO> GetUserVacation(string username)
        {
            using (_context)
            {
                var results = from vacation in _context.Vacations
                              join user in _context.Users on vacation.UserId equals user.Id
                              where user.Username == username
                              select new VacationDTO
                              {
                                  Username = user.Username,
                                  StartDate = vacation.StartDate,
                                  EndDate = vacation.EndDate,
                              };

                List<VacationDTO> result = results.ToList();
                return result;
            }
        }

    }
}
