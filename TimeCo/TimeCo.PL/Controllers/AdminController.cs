using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeCo.PL.Models;
using TimeCo.BLL.Services;

namespace TimeCo.PL.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(string firstName, string lastName, string email, string password, string username, string departmentName, string roleName)
        {
            // Call the function with the parameters
            TimeCo.BLL.Services.UserService.AddUser(firstName, lastName, email, password, username, departmentName, roleName);

            // Redirect to a result page
            return RedirectToAction("Result");
        }

        [HttpPost]
        public ActionResult AddUserSchedule(string shift, string startDate, string endDate, string startHour, string endHour, string username)
        {
            // Call the function with the parameters
            TimeCo.BLL.Services.ScheduleService.AddUserSchedule(shift, startDate, endDate, startHour, endHour, username);

            // Redirect to a result page
            return RedirectToAction("Result");
        }
    }

}
