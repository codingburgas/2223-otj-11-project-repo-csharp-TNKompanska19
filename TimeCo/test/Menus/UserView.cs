using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Menus;
using TimeCo.BLL.Services;
using TimeCo.Utilities;

namespace TimeCo.PL.Menus
{
    public class UserView
    {
        //private TimeCo.BLL.Services.DepartmentService _departmentService;
        //private TimeCo.BLL.Services.UserService _userService;
        private TimeCo.BLL.Services.ScheduleService _scheduleService;
        private TimeCo.BLL.Services.VacationService _vacationService;
        private TimeCo.Utilities.Converter _converter;

        private Figures _figures;
        public UserView()
        {
            //_departmentService = new TimeCo.BLL.Services.DepartmentService();
            //_userService = new TimeCo.BLL.Services.UserService();
            _scheduleService = new TimeCo.BLL.Services.ScheduleService();
            _vacationService = new TimeCo.BLL.Services.VacationService();
            _converter = new TimeCo.Utilities.Converter();
            _figures = new Figures();
        }

        public void UserPanelScheduleOptions(string username)
        {
            int selectedOption = 1;
            while (true)
            {
                Console.Clear();

                _figures.Border(0, 0, 51);
                _figures.TeamFigure(10, 33);
                _figures.TimeCoLabel(30, 1);
                _figures.Button(43, 11, selectedOption == 1 ? "blue" : "cyan");
                _figures.Button(43, 16, selectedOption == 2 ? "blue" : "cyan");


                _figures.TextInButton(48, 13, "View schedule", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(48, 18, "Colls schedule", selectedOption == 2 ? "blue" : "cyan");



                _figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 2;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 2)
                    {
                        selectedOption = 1;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                var result = _scheduleService.GetUserSchedule(username);
                                int y = 25;
                                foreach (var item in result)
                                {
                                    Console.SetCursorPosition(35, y);
                                    Console.WriteLine("Dates: {0} - {1}; Hours: {2} - {3}", _converter.DateOnly(item.StartDate), _converter.DateOnly(item.EndDate), item.StartHour, item.EndHour);
                                    y++;
                                }
                                Console.ReadLine();
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                var result = _scheduleService.GetCollsSchedule(username);
                                int y = 20;
                                foreach (var item in result)
                                {
                                    Console.SetCursorPosition(25, y);
                                    Console.WriteLine("Username: {0} Dates: {1} - {2}; Hours: {3} - {4}", item.Username, _converter.DateOnly(item.StartDate), _converter.DateOnly(item.EndDate), item.StartHour, item.EndHour);
                                    y++;
                                }
                                Console.ReadLine();

                            }
                            break;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    UserPanelOptions(username);
                }

            }
        }

        public void UserPanelVacationOptions(string username)
        {
            int selectedOption = 1;
            while (true)
            {
                Console.Clear();

                _figures.Border(0, 0, 51);
                _figures.TeamFigure(10, 33);
                _figures.TimeCoLabel(30, 1);
                _figures.Button(43, 11, selectedOption == 1 ? "blue" : "cyan");
                _figures.Button(43, 16, selectedOption == 2 ? "blue" : "cyan");
                _figures.Button(43, 21, selectedOption == 3 ? "blue" : "cyan");

                _figures.TextInButton(45, 13, "Request a vacation", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(48, 18, "View vacations", selectedOption == 2 ? "blue" : "cyan");
                _figures.TextInButton(48, 23, "Main vac hours", selectedOption == 3 ? "blue" : "cyan");


                _figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 3;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 3)
                    {
                        selectedOption = 1;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(45, 15);
                                Console.WriteLine("ENTER VACATION NAME:");
                                Console.SetCursorPosition(45, 16);
                                string name = Console.ReadLine();
                                Console.SetCursorPosition(45, 18);
                                Console.WriteLine("ENTER VACATION DESCRIPTION: ");
                                Console.SetCursorPosition(45, 19);
                                string description = Console.ReadLine();
                                Console.SetCursorPosition(45, 21);
                                Console.WriteLine("ENTER START DAY: ");
                                Console.SetCursorPosition(45, 22);
                                string startDay = Console.ReadLine();
                                Console.SetCursorPosition(45, 24);
                                Console.WriteLine("ENTER END DAY: ");
                                Console.SetCursorPosition(45, 25);
                                string endDay = Console.ReadLine();
                                _vacationService.AddUserVacation(name, description, startDay, endDay, username);
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                UserPanelOptions(username);

                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                var result = _vacationService.GetUserVacation(username);
                                int y = 20;
                                foreach (var item in result)
                                {
                                    Console.SetCursorPosition(25, y);
                                    Console.WriteLine("Dates: {0} - {1}; Name: {2}, Description: {3}", _converter.DateOnly(item.StartDate), _converter.DateOnly(item.EndDate), item.Name, item.Description);
                                    y++;
                                }
                                Console.ReadLine();
                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                var result = _vacationService.GetUserMainVacHours(username);
                                Console.SetCursorPosition(43, 20);
                                Console.WriteLine("MAIN VACATION HOURS LEFT:");
                                Console.SetCursorPosition(53, 21);
                                Console.WriteLine(result); 
                                Console.ReadLine();
                            }
                            break;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    UserPanelOptions(username);
                }

            }
        }

        public void UserPanelOptions(string username)
        {
            int selectedOption = 1;
            while (true)
            {
                Console.Clear();

                _figures.Border(0, 0, 51);
                _figures.TeamFigure(10, 33);
                _figures.TimeCoLabel(30, 1);
                _figures.Button(43, 11, selectedOption == 1 ? "blue" : "cyan");
                _figures.Button(43, 16, selectedOption == 2 ? "blue" : "cyan");  

                _figures.TextInButton(50, 13, "Schedules", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(50, 18, "Vacations", selectedOption == 2 ? "blue" : "cyan");
                

                _figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 2;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 2)
                    {
                        selectedOption = 1;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            UserPanelScheduleOptions(username);
                            break;
                        case 2:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            UserPanelVacationOptions(username);
                            break;
                    }
                }
            }
        }
    }
}
