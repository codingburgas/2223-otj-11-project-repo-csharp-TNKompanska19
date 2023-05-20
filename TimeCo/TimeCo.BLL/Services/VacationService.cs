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

        public void GetUserVacation(string username)
        {
            Vacation userVacation = _vacationRepository.GetUserVacation(username);
            //Console.WriteLine($"Name: {userVacation.Name}, Description: {userVacation.Description}, Status: {userVacation.Status}");
        }

        public void AddUserVacation(string name, string description, string startDate, string endDate, string username, string status = "Pending", string isMainVacation = "yes")
        {

            var user = _context.Users.FirstOrDefault(user => user.Username == username);

            bool flag = false;

            if (isMainVacation == "yes")
            {
                flag = true;
                user.MainVacationHours -= _converter.GetDaysVacation
                (_converter.ToDate(startDate), _converter.ToDate(endDate)) * 8;
            }

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

            _userRepository.UpdateUser(user);
            _vacationRepository.AddVacation(vacation);
        }
    }
}
