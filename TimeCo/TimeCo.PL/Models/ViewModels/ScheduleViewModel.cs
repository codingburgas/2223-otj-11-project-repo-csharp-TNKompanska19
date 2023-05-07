using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeCo.DAL;
namespace TimeCo.PL.Models.ViewModels;
//{
    //public class ScheduleViewModel
    //{
    //    public Schedule Schedule { get; set; }
    //    public List<SelectListItem> Department = new List<SelectListItem>();
    //    public string LocationName { get; set; }
    //    public string UserId { get; set; }

    //    public ScheduleViewModel(Schedule myevent, List<Department> departments, string userid)
    //    {
    //        Schedule = myevent;
    //        LocationName = myevent.Department.Name;
    //        UserId = userid;
    //        foreach (var loc in departments)
    //        {
    //            Department.Add(new SelectListItem() { Text = loc.Name });
    //        }
    //    }

    //    public ScheduleViewModel(List<Department> locations, string userid)
    //    {
    //        UserId = userid;
    //        foreach (var loc in locations)
    //        {
    //            Department.Add(new SelectListItem() { Text = loc.Name });
    //        }
    //    }

    //    public ScheduleViewModel()
    //    {

    //    }

  //  }
//}
