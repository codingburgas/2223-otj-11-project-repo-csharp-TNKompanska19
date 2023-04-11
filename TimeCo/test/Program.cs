using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.BLL.Services;
namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TimeCo.BLL.Services.DepartmentService.AddDepartment("Software engineering", "new department");
            //TimeCo.BLL.Services.DepartmentService.UpdateDepartment("Software engineering", "Computer Science", "edited department");

            TimeCo.BLL.Services.ScheduleService.AddUserSchedule("first", "10-04-2023", "14-04-2023", "8:00", "16:00", "tnkompanska19");
        }
    }
}