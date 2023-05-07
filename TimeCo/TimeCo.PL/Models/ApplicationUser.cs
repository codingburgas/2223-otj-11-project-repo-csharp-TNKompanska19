using Microsoft.AspNetCore.Identity;
using Microsoft.SqlServer.Management.XEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeCo.PL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}