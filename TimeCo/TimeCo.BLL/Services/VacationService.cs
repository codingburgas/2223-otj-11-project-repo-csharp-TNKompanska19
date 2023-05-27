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
using Microsoft.SqlServer.Management.XEvent;
using Microsoft.EntityFrameworkCore;

namespace TimeCo.BLL.Services
{
    public class VacationService
    {
        // Private fields
        private TimeCoContext _context;
        private VacationRepository _vacationRepository;
        private UserRepository _userRepository;
        private TimeCo.Utilities.Converter _converter;

        // Constructor
        public VacationService()
        {
            _context = new TimeCoContext();
            _vacationRepository = new VacationRepository();
            _userRepository = new UserRepository();
            _converter = new Utilities.Converter();
        }

        // Method for adding vacation when user requests one
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

        // Method for approving vacation by admin
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

        // Method for denying vacation by admin
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

        // Method for returning all vacations that are in pending status
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

        // Method for returning user's main vacation hours
        public double GetUserMainVacHours(string username)
        {
            double mainVacationHours;

            using (var context = new TimeCoContext())
            {
                var user = context.Users.FirstOrDefault(item => item.Username == username);

                context.Entry(user).State = EntityState.Detached;

                mainVacationHours = user.MainVacationHours;
            }

            return mainVacationHours;
        }

        // Method for returning all vacations for given user
        public List<VacationDTO> GetUserVacation(string username)
        {
            using (_context)
            {
                var results = from vacation in _context.Vacations
                              join user in _context.Users on vacation.UserId equals user.Id
                              where user.Username == username
                              select new VacationDTO
                              {
                                  Name = vacation.Name,
                                  Description = vacation.Description,
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
