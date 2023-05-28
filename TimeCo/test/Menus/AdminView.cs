using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.DAL.Data;
using TimeCo.DAL.Repositories;
using TimeCo.BLL.Models;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.AspNetCore.Mvc.Internal;
using TimeCo.DAL.Entities;

namespace test.Menus
{
    public class AdminView
    {
        // Private fields
        private TimeCo.BLL.Services.DepartmentService _departmentService;
        private TimeCo.BLL.Services.UserService _userService;
        private TimeCo.BLL.Services.ScheduleService _scheduleService;
        private TimeCo.BLL.Services.VacationService _vacationService;
        private TimeCo.Utilities.Converter _converter;
        private Figures _figures;

        // Constructor
        public AdminView()
        {
            _departmentService = new TimeCo.BLL.Services.DepartmentService();
            _userService = new TimeCo.BLL.Services.UserService();
            _scheduleService = new TimeCo.BLL.Services.ScheduleService();
            _vacationService = new TimeCo.BLL.Services.VacationService();
            _converter = new TimeCo.Utilities.Converter();
            _figures = new Figures();
        }

        // Method for displaying admin options for user
        public void AdminPanelUserOptions(string username)
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
                _figures.Button(43, 26, selectedOption == 4 ? "blue" : "cyan");
                _figures.Button(43, 31, selectedOption == 5 ? "blue" : "cyan");

                _figures.TextInButton(46, 13, "Make user an admin", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(50, 18, "Edit user", selectedOption == 2 ? "blue" : "cyan");
                _figures.TextInButton(51, 23, "Add user", selectedOption == 3 ? "blue" : "cyan");
                _figures.TextInButton(48, 28, "View all users", selectedOption == 4 ? "blue" : "cyan");
                _figures.TextInButton(45, 33, "Add user department", selectedOption == 5 ? "blue" : "cyan");

                _figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Pressing up arrow
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 5;
                    }
                }

                // Pressing down arrow
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 5)
                    {
                        selectedOption = 1;
                    }
                }

                // Pressing enter
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        // Option for making user an admin
                        case 1:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(33, 21);
                                Console.WriteLine("Enter the username of the user you want to make an admin:");
                                Console.SetCursorPosition(40, 22);
                                string name = Console.ReadLine();
                                _userService.MakeUserAnAdmin(name);
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                        // Option for editing user
                        case 2:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(40, 21);
                                Console.WriteLine("Enter the username of the user you want to edit:");
                                Console.SetCursorPosition(40, 22);
                                string name = Console.ReadLine();
                                Console.SetCursorPosition(40, 24);
                                Console.WriteLine("Enter new first name of the user:");
                                Console.SetCursorPosition(40, 25);
                                string firstName = Console.ReadLine();
                                Console.SetCursorPosition(40, 26);
                                Console.WriteLine("Enter new last name of the user:");
                                Console.SetCursorPosition(40, 27);
                                string lastName = Console.ReadLine();
                                Console.SetCursorPosition(40, 28);
                                Console.WriteLine("Enter new username of the user:");
                                Console.SetCursorPosition(40, 29);
                                string newUsername = Console.ReadLine();

                                _userService.UpdateUser(name, firstName, lastName, newUsername);
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                        // Option for adding user
                        case 3:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(45, 15);
                                Console.WriteLine("ENTER FIRST NAME:");
                                Console.SetCursorPosition(45, 16);
                                string firstName = Console.ReadLine();
                                Console.SetCursorPosition(45, 18);
                                Console.WriteLine("ENTER LAST NAME: ");
                                Console.SetCursorPosition(45, 19);
                                string lastName = Console.ReadLine();
                                Console.SetCursorPosition(45, 21);
                                Console.WriteLine("ENTER USERNAME: ");
                                Console.SetCursorPosition(45, 22);
                                string name = Console.ReadLine();
                                Console.SetCursorPosition(45, 24);
                                Console.WriteLine("ENTER EMAIL: ");
                                Console.SetCursorPosition(45, 25);
                                string email = Console.ReadLine();
                                Console.SetCursorPosition(45, 27);
                                Console.WriteLine("ENTER PASSWORD: ");
                                Console.SetCursorPosition(45, 28);
                                string pass = Console.ReadLine();
                                //string password = pm::bll::passwordHashing::sha256(pass);
                                Console.SetCursorPosition(45, 30);
                                Console.WriteLine("ENTER DEPARTMENT: ");
                                Console.SetCursorPosition(45, 31);
                                string departmentName = Console.ReadLine();

                                _userService.AddUser(firstName, lastName, email, pass, name, departmentName);
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                        // Option for viewing all users
                        case 4:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                var userList = _userService.GetAllUsers();
                                int x = 30, y = 10;
                                foreach (User user in userList)
                                {
                                    Console.SetCursorPosition(x, y);
                                    Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Username: {user.Username}");
                                    y++;
                                }
                                Console.ReadLine();
                            }
                            break;
                        // Option for adding user to department
                        case 5:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(45, 15);
                                Console.WriteLine("Enter the username of the user:");
                                Console.SetCursorPosition(45, 16);
                                string userName = Console.ReadLine();
                                Console.SetCursorPosition(45, 18);
                                Console.WriteLine("Enter the name of the department: ");
                                Console.SetCursorPosition(45, 19);
                                string departmentName = Console.ReadLine();
                                _userService.AddUserToDepartment(userName, departmentName);
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                    }
                }

                // Pressing escape
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    AdminPanelOptions(username);
                }
			}
		}

        // Method for displaying admin options for department
        public void AdminPanelDepartmentOptions(string username)
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
                _figures.Button(43, 26, selectedOption == 4 ? "blue" : "cyan");

                _figures.TextInButton(44, 13, "View department users", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(47, 18, "Edit department", selectedOption == 2 ? "blue" : "cyan");
                _figures.TextInButton(47, 23, "Add department", selectedOption == 3 ? "blue" : "cyan");
                _figures.TextInButton(45, 28, "View all departments", selectedOption == 4 ? "blue" : "cyan");


                _figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Pressing up arrow
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 4;
                    }
                }

                // Pressing down arrow
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 4)
                    {
                        selectedOption = 1;
                    }
                }

                // Pressing enter
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        // Option for viewing all users in a given department
                        case 1:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.SetCursorPosition(25, 21);
                            Console.WriteLine("Enter the name of the department in which you want to see the users:");
                            Console.SetCursorPosition(25, 22);
                            string name = Console.ReadLine();
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            var result = _departmentService.GetUsersDepartments(name);
                            int y = 20;
                            foreach (var item in result)
                            {
                                Console.SetCursorPosition(15, y);
                                Console.WriteLine("{0}: {1} {2}", item.DepartmentName, item.FirstName, item.LastName);
                                y++;
                            }
                            Console.ReadLine();
                            break;

                        // Option for editing department
                        case 2:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.SetCursorPosition(40, 21);
                            Console.WriteLine("Enter the name of the department you want to edit:");
                            Console.SetCursorPosition(40, 22);
                            string departmentName = Console.ReadLine();
                            Console.SetCursorPosition(40, 24);
                            Console.WriteLine("Enter new name of the department:");
                            Console.SetCursorPosition(40, 25);
                            string editedName = Console.ReadLine();
                            Console.SetCursorPosition(40, 26);
                            Console.WriteLine("Enter new description of the department:");
                            Console.SetCursorPosition(40, 27);
                            string editedDescription = Console.ReadLine();
                            _departmentService.UpdateDepartment(departmentName, editedName, editedDescription);
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            AdminPanelOptions(username);
                            break;

                        // Option for adding a department
                        case 3:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.SetCursorPosition(45, 15);
                            Console.WriteLine("ENTER NAME:");
                            Console.SetCursorPosition(45, 16);
                            departmentName = Console.ReadLine();
                            Console.SetCursorPosition(45, 18);
                            Console.WriteLine("ENTER DESCRIPTION: ");
                            Console.SetCursorPosition(45, 19);
                            string description = Console.ReadLine();
                            _departmentService.AddDepartment(departmentName, description);
                            break;

                        // Option for viewing all departments
                        case 4:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            var departmentList = _departmentService.GetAllDepartments();
                            int y1 = 15;
                            foreach (Department department in departmentList)
                            {
                                Console.SetCursorPosition(15, y1);
                                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, Description: {department.Description}");
                                y1++;
                            }
                            Console.ReadLine();
                            break;
                    }
                }

                // Pressing escape
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    AdminPanelOptions(username);
                }
            }
        }

        // Method for displaying admin options for schedule
        public void AdminPanelScheduleOptions(string username)
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


                _figures.TextInButton(45, 13, "Add schedule to user", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(45, 18, "View user schedule", selectedOption == 2 ? "blue" : "cyan");



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
                        // Option for adding schedule
                        case 1:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(33, 21);
                                Console.WriteLine("Enter the username of the user you want to add schedule:");
                                Console.SetCursorPosition(40, 22);
                                string name = Console.ReadLine();
                                Console.SetCursorPosition(33, 24);
                                Console.WriteLine("Enter the user shift:");
                                Console.SetCursorPosition(40, 25);
                                string userShift = Console.ReadLine();
                                Console.SetCursorPosition(33, 27);
                                Console.WriteLine("Enter the start date:");
                                Console.SetCursorPosition(40, 28);
                                string startDate = Console.ReadLine();
                                Console.SetCursorPosition(33, 30);
                                Console.WriteLine("Enter the end date:");
                                Console.SetCursorPosition(40, 31);
                                string endDate = Console.ReadLine();
                                Console.SetCursorPosition(33, 33);
                                Console.WriteLine("Enter the start hour:");
                                Console.SetCursorPosition(40, 34);
                                string startHour = Console.ReadLine();
                                Console.SetCursorPosition(33, 36);
                                Console.WriteLine("Enter the end hour:");
                                Console.SetCursorPosition(40, 37);
                                string endHour = Console.ReadLine();
                                _scheduleService.AddUserSchedule(userShift, startDate, endDate, startHour, endHour, name);
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;

                        // Optiong for viewing user's schedule
                        case 2:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(40, 21);
                                Console.WriteLine("Enter the username of the user you want to view schedule:");
                                Console.SetCursorPosition(40, 22);
                                string name = Console.ReadLine();
                                var result = _scheduleService.GetUserSchedule(name);
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
                    }
                }

                // Pressing escape
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    AdminPanelOptions(username);
                }

            }
        }

        // Method for displaying admin options for vacation
        public void AdminPanelVacationOptions(string username)
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


                _figures.TextInButton(44, 13, "Approve/Deny vacation", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(46, 18, "View user vacation", selectedOption == 2 ? "blue" : "cyan");



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
                        // Option for approving or denying a user's vacation
                        case 1:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                List<VacationDTO> result = _vacationService.GetPendingVacations();
                                int y = 20;
                                foreach (var item in result)
                                {
                                    Console.SetCursorPosition(25, y);
                                    Console.WriteLine("{0}: {1} ({2}) -  from {3} to {4}",item.Id, item.Username, item.Description, _converter.DateOnly(item.StartDate), _converter.DateOnly(item.EndDate));
                                    y++;
                                }
                                Console.ReadLine();
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(25, 21);
                                Console.WriteLine("Enter the id of the vacation you want to approve/deny:");
                                Console.SetCursorPosition(25, 22);
                                int id = int.Parse(Console.ReadLine());
                                Console.SetCursorPosition(25, 24);
                                Console.WriteLine("Enter y for approving or n for denying:");
                                Console.SetCursorPosition(25, 25);
                                string choice = Console.ReadLine();
                                if (choice == "y")
                                {
                                    _vacationService.ApproveVacation(id);
                                }
                                else
                                {
                                    _vacationService.DenyVacation(id);
                                }
                            }
                            break;
                        // Option for viewing user's vacation
                        case 2:
                            {
                                Console.Clear();
                                _figures.Border(0, 0, 51);
                                _figures.TimeCoLabel(30, 1);
                                _figures.Border(107, 0, 51);
                                Console.SetCursorPosition(40, 21);
                                Console.WriteLine("Enter the username of the user you want to view vacation:");
                                Console.SetCursorPosition(40, 22);
                                string name = Console.ReadLine();
                                var result = _vacationService.GetUserVacation(name);
                                int y = 25;
                                foreach (var item in result)
                                {
                                    Console.SetCursorPosition(35, y);
                                    Console.WriteLine("Dates: {0} - {1}; Username: {2}", _converter.DateOnly(item.StartDate), _converter.DateOnly(item.EndDate), item.Username);
                                    y++;
                                }
                                Console.ReadLine();
                            }
                            break;
                    }
                }

                // Pressing enter
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    AdminPanelOptions(username);
                }

            }
        }

        // Method for displaying admin options
        public void AdminPanelOptions(string username)
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
                _figures.Button(43, 26, selectedOption == 4 ? "blue" : "cyan");

                _figures.TextInButton(52, 13, "Users", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(49, 18, "Departments", selectedOption == 2 ? "blue" : "cyan");
                _figures.TextInButton(50, 23, "Schedules", selectedOption == 3 ? "blue" : "cyan");
                _figures.TextInButton(50, 28, "Vacations", selectedOption == 4 ? "blue" : "cyan");

                _figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Pressing up arrow
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 4;
                    }
                }

                // Pressing down arrow
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 4)
                    {
                        selectedOption = 1;
                    }
                }

                // Pressing enter
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (selectedOption)
                    {
                        // User options
                        case 1:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            AdminPanelUserOptions(username);
                            break;
                        // Department options
                        case 2:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            AdminPanelDepartmentOptions(username);
                            break;
                        // Schedule options
                        case 3:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            AdminPanelScheduleOptions(username);
                            break;
                        // Vacation options
					    case 4:
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            AdminPanelVacationOptions(username);
                            break;
                    }
                }


            }
        }
    }
}
