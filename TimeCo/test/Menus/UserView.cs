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
        // Private fields
        private TimeCo.BLL.Services.ScheduleService _scheduleService;
        private TimeCo.BLL.Services.VacationService _vacationService;
        private TimeCo.Utilities.Converter _converter;
        private Figures _figures;

        // Constructor
        public UserView()
        {
            _scheduleService = new TimeCo.BLL.Services.ScheduleService();
            _vacationService = new TimeCo.BLL.Services.VacationService();
            _converter = new TimeCo.Utilities.Converter();
            _figures = new Figures();
        }

        // Method for displaying user options for schedule
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

                // Pressing up arrow
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 2;
                    }
                }

                // Pressing down arrow
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 2)
                    {
                        selectedOption = 1;
                    }
                }

                // Pressing enter
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        // Option for viewing schedule
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
                        // Option for viewing colleagues' schedule
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

                // Pressing escape
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    UserPanelOptions(username);
                }

            }
        }

        // Method for displaying user options for vacation
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

                // Pressing up arrow
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 3;
                    }
                }

                // Pressing down arrow
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 3)
                    {
                        selectedOption = 1;
                    }
                }

                // Pressing enter
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        // Option for requesting a vacation
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
                        // Option for viewing vacations
                        case 2:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                var result = _vacationService.GetUserVacation(username);
                                int y = 15;
                                foreach (var item in result)
                                {
                                    Console.SetCursorPosition(10, y);
                                    Console.WriteLine("Dates: {0} - {1}; Name: {2}, Description: {3}, Status: {4}", _converter.DateOnly(item.StartDate), _converter.DateOnly(item.EndDate), item.Name, item.Description, item.Status);
                                    y++;
                                }
                                Console.ReadLine();
                            }
                            break;
                        // Option for viewing the left hours main vacation
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

                // Pressing escape
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    UserPanelOptions(username);
                }

            }
        }

        // Method for displaying user options
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

                // Pressing up arrow
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 2;
                    }
                }

                // Pressing down arrow
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 2)
                    {
                        selectedOption = 1;
                    }
                }

                // Pressing enter
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        // Schedule options
                        case 1:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            UserPanelScheduleOptions(username);
                            break;
                        // Vacation options
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
