using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeCo.DAL.Data;
using TimeCo.PL.Models;
using TimeCo.PL.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using TimeCo.PL.Controllers.ActionFilters;
using System.Reflection;
using Microsoft.SqlServer.Management.XEvent;

namespace TimeCo.PL.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly TimeCoContext _dal;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ScheduleController(TimeCoContext dal, UserManager<ApplicationUser> usermanager)
        {
            _dal = dal;
            _usermanager = usermanager;
        }

        // GET: Event
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(TimeCo.DAL.Repositories.ScheduleRepository.GetUserSchedule(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }


    }
}
