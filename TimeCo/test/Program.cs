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

            //TimeCo.BLL.Services.ScheduleService.AddUserSchedule("first", "10-04-2023", "14-04-2023", "8:00", "16:00", "tnkompanska19");

            //TimeCo.BLL.Services.UserService.AddUser("nikolay", "kompanski", "nkompanski@abv.bg", "neshto2", "nkompanski", "engineering");


            //TimeCo.BLL.Services.VacationService.AddUserVacation("holiday vacation", "5 days", "18-04-2023", "04-05-2023", "tnkompanska19");

            //Console.WriteLine(TimeCo.Utilities.Converter.GetDayOfWeek(TimeCo.Utilities.Converter.ToDate("11-04-2023")));

            do
            {
                Console.WriteLine(test.Menus.MenuAccess.mainMenu());
            }
            while (true);
        }
    }
}