using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace test.Menus
{
    public class AdminView
    {
        public static void AdminPanelUserOptions(string username)
		{
            int selectedOption = 1;
            while (true)
            {
                Console.Clear();

                Figures.Border(0, 0, 51);
                Figures.TeamFigure(10, 33);
                Figures.TimeCoLabel(30, 1);
                Figures.Button(43, 11, selectedOption == 1 ? "blue" : "cyan");
                Figures.Button(43, 16, selectedOption == 2 ? "blue" : "cyan");
                Figures.Button(43, 21, selectedOption == 3 ? "blue" : "cyan");
                Figures.Button(43, 26, selectedOption == 4 ? "blue" : "cyan");
                Figures.Button(43, 31, selectedOption == 5 ? "blue" : "cyan");

                Figures.TextInButton(46, 13, "Make user an admin", selectedOption == 1 ? "blue" : "cyan");
                Figures.TextInButton(50, 18, "Edit user", selectedOption == 2 ? "blue" : "cyan");
                Figures.TextInButton(51, 23, "Add user", selectedOption == 3 ? "blue" : "cyan");
                Figures.TextInButton(48, 28, "View all users", selectedOption == 4 ? "blue" : "cyan");
                Figures.TextInButton(45, 33, "Add user department", selectedOption == 5 ? "blue" : "cyan");

                Figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 5;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 5)
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
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
                                Console.SetCursorPosition(33, 21);
                                Console.WriteLine("Enter the username of the user you want to make an admin:");
                                Console.SetCursorPosition(40, 22);
                                string name = Console.ReadLine();
                                TimeCo.BLL.Services.UserService.MakeUserAnAdmin(name);
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
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

                                TimeCo.BLL.Services.UserService.UpdateUser(name, firstName, lastName, newUsername);
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
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

                                TimeCo.BLL.Services.UserService.AddUser(firstName, lastName, email, pass, name, departmentName);
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                        case 4:
                            {
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
                                TimeCo.BLL.Services.UserService.GetAllUsers();
                                Thread.Sleep(8000);
                            }
                            break;
                        case 5:
                            {
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
                                Console.SetCursorPosition(45, 15);
                                Console.WriteLine("Enter the username of the user:");
                                Console.SetCursorPosition(45, 16);
                                string userName = Console.ReadLine();
                                Console.SetCursorPosition(45, 18);
                                Console.WriteLine("Enter the name of the department: ");
                                Console.SetCursorPosition(45, 19);
                                string departmentName = Console.ReadLine();
                                TimeCo.BLL.Services.UserService.AddUserToDepartment(userName, departmentName);
                                Console.Clear();
                                Figures.Border(0, 0, 51);
                                Figures.TimeCoLabel(30, 1);
                                Figures.Border(107, 0, 51);
                                AdminPanelOptions(username);
                            }
                            break;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    AdminPanelOptions(username);
                }
			}
		}

        public static void AdminPanelDepartmentOptions(string username)
        {
            int selectedOption = 1;
            while (true)
            {
                Console.Clear();

                Figures.Border(0, 0, 51);
                Figures.TeamFigure(10, 33);
                Figures.TimeCoLabel(30, 1);
                Figures.Button(43, 11, selectedOption == 1 ? "blue" : "cyan");
                Figures.Button(43, 16, selectedOption == 2 ? "blue" : "cyan");
                Figures.Button(43, 21, selectedOption == 3 ? "blue" : "cyan");
                Figures.Button(43, 26, selectedOption == 4 ? "blue" : "cyan");

                Figures.TextInButton(44, 13, "View department users", selectedOption == 1 ? "blue" : "cyan");
                Figures.TextInButton(47, 18, "Edit department", selectedOption == 2 ? "blue" : "cyan");
                Figures.TextInButton(47, 23, "Add department", selectedOption == 3 ? "blue" : "cyan");
                Figures.TextInButton(45, 28, "View all departments", selectedOption == 4 ? "blue" : "cyan");


                Figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 4;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 4)
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
                            Figures.Border(0, 0, 51);
                            Figures.TimeCoLabel(30, 1);
                            Figures.Border(107, 0, 51);
                            Console.SetCursorPosition(25, 21);
                            Console.WriteLine("Enter the name of the department in which you want to see the users:");
                            Console.SetCursorPosition(25, 22);
                            string name = Console.ReadLine();
                            TimeCo.BLL.Services.DepartmentService.GetUsersDepartments(name);
                            Thread.Sleep(8000);
                            break;
                        case 2:
                            Console.Clear();
                            Figures.Border(0, 0, 51);
                            Figures.TimeCoLabel(30, 1);
                            Figures.Border(107, 0, 51);
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
                            TimeCo.BLL.Services.DepartmentService.UpdateDepartment(departmentName, editedName, editedDescription);
                            Console.Clear();
                            Figures.Border(0, 0, 51);
                            Figures.TimeCoLabel(30, 1);
                            Figures.Border(107, 0, 51);
                            AdminPanelOptions(username);
                            break;
                        case 3:
                            Console.Clear();
                            Figures.Border(0, 0, 51);
                            Figures.TimeCoLabel(30, 1);
                            Figures.Border(107, 0, 51);
                            Console.SetCursorPosition(45, 15);
                            Console.WriteLine("ENTER NAME:");
                            Console.SetCursorPosition(45, 16);
                            departmentName = Console.ReadLine();
                            Console.SetCursorPosition(45, 18);
                            Console.WriteLine("ENTER DESCRIPTION: ");
                            Console.SetCursorPosition(45, 19);
                            string description = Console.ReadLine();
                            TimeCo.BLL.Services.DepartmentService.AddDepartment(departmentName, description);
                            break;
                        case 4:
                            Console.Clear();
                            Figures.Border(0, 0, 51);
                            Figures.TimeCoLabel(30, 1);
                            Figures.Border(107, 0, 51);
                            TimeCo.BLL.Services.DepartmentService.GetAllDepartments();
                            Thread.Sleep(8000);
                            break;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    AdminPanelOptions(username);
                }
            }
        }

        public static void AdminPanelOptions(string username)
        {
            int selectedOption = 1;
            while (true)
            {
                Console.Clear();

                Figures.Border(0, 0, 51);
                Figures.TeamFigure(10, 33);
                Figures.TimeCoLabel(30, 1);
                Figures.Button(43, 11, selectedOption == 1 ? "blue" : "cyan");
                Figures.Button(43, 16, selectedOption == 2 ? "blue" : "cyan");
                Figures.Button(43, 21, selectedOption == 3 ? "blue" : "cyan");
                Figures.Button(43, 26, selectedOption == 4 ? "blue" : "cyan");

                Figures.TextInButton(52, 13, "Users", selectedOption == 1 ? "blue" : "cyan");
                Figures.TextInButton(49, 18, "Departments", selectedOption == 2 ? "blue" : "cyan");
                Figures.TextInButton(50, 23, "Schedules", selectedOption == 3 ? "blue" : "cyan");
                Figures.TextInButton(50, 28, "Vacations", selectedOption == 4 ? "blue" : "cyan");

                Figures.Border(107, 0, 51);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 1)
                    {
                        selectedOption = 4;
                    }
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption > 4)
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
                            Figures.Border(0, 0, 51);
                            Figures.TimeCoLabel(30, 1);
                            Figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            TimeCo.BLL.Services.UserService.GetAllUsers();
                            AdminPanelUserOptions(username);
                            break;
                        case 2:
                            Console.Clear();
                            Figures.Border(0, 0, 51);
                            Figures.TimeCoLabel(30, 1);
                            Figures.Border(107, 0, 51);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            TimeCo.BLL.Services.DepartmentService.GetAllDepartments();
                            AdminPanelDepartmentOptions(username);
                            break;
                        case 3:
							Console.WriteLine("Schedules");
                            break;
					    case 4:
							Console.WriteLine("Vacations");
							break;
                    }
                }


            }
        }
    }
}
