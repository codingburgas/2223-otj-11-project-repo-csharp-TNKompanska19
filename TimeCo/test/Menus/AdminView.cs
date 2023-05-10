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
        public static void userPanelOptions(string username)
		{
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(40, 42);
			Console.WriteLine( "PRESS CTRL + P TO MAKE USER AN ADMIN");
			Console.SetCursorPosition(40, 44);
			Console.WriteLine( "PRESS CTRL + E TO EDIT USER");
			Console.SetCursorPosition(40, 46);
			Console.WriteLine( "PRESS CTRL + I TO ADD USER");
			Console.SetCursorPosition(40, 48);
			Console.WriteLine( "PRESS CTRL + D TO DELETE USER");

            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.P when keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control):
                {
                Console.Clear();
                Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				Console.SetCursorPosition(33, 21);
				Console.WriteLine( "Enter the username of the user you want to make an admin:");
				Console.SetCursorPosition(40, 22);
				string name = Console.ReadLine();
				TimeCo.BLL.Services.UserService.MakeUserAnAdmin(name);
			    Console.Clear();
				Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				adminOptions(username);
			}break;

            case ConsoleKey.E when keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control):
			{
				Console.Clear();
				Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				Console.SetCursorPosition(40, 21);
				Console.WriteLine( "Enter the username of the user you want to edit:");
				Console.SetCursorPosition(40, 22);
				string name = Console.ReadLine();
				Console.SetCursorPosition(40, 24);
				Console.WriteLine( "Enter new first name of the user:");
				Console.SetCursorPosition(40, 25);
				string firstName = Console.ReadLine();
				Console.SetCursorPosition(40, 26);
				Console.WriteLine( "Enter new last name of the user:");
				Console.SetCursorPosition(40, 27);
			    string lastName = Console.ReadLine();
				Console.SetCursorPosition(40, 28);
				Console.WriteLine( "Enter new username of the user:");
				Console.SetCursorPosition(40, 29);
				string newUsername = Console.ReadLine();
				
				TimeCo.BLL.Services.UserService.UpdateUser(name, firstName, lastName, newUsername);
				Console.Clear();
				Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				adminOptions(username);
			}break;

                case ConsoleKey.I when keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control):
                {
				Console.Clear();
				Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				Console.SetCursorPosition(45, 15);
				Console.WriteLine( "ENTER FIRST NAME:");
				Console.SetCursorPosition(45, 16);
			    string firstName = Console.ReadLine();
				Console.SetCursorPosition(45, 18);
				Console.WriteLine( "ENTER LAST NAME: ");
				Console.SetCursorPosition(45, 19);
				string lastName = Console.ReadLine();
				Console.SetCursorPosition(45, 21);
				Console.WriteLine( "ENTER USERNAME: ");
				Console.SetCursorPosition(45, 22);
				string name = Console.ReadLine();
				Console.SetCursorPosition(45, 24);
				Console.WriteLine( "ENTER EMAIL: ");
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
				Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				adminOptions(username);
			}break;

            case ConsoleKey.D when keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control):
            {
				Console.Clear();
				Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				Console.SetCursorPosition(35, 21);
				Console.WriteLine( "Enter the username of the user you want to delete:");
				Console.SetCursorPosition(40, 22);
                string name = Console.ReadLine();
                //TimeCo.BLL.Services.UserService.DeleteUser(name);
				Console.Clear();
				Figures.border(0, 0, 51);
				Figures.label(30, 1);
				Figures.border(107, 0, 51);
				adminOptions(username);
			}break;

			}
		}
        public static void adminOptions(string username)
        {
            Console.SetCursorPosition(45, 21);
            Console.WriteLine( "1 - USERS ");
            Console.SetCursorPosition(45, 23);
            Console.WriteLine( "2 - DEPARTMENTS");
            Console.SetCursorPosition(45, 25);
            Console.WriteLine( "3 - SCHEDULES ");
            Console.SetCursorPosition(45, 27);
            Console.WriteLine("3 - VACATIONS ");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine( "Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        Figures.border(0, 0, 51);
                        Figures.label(30, 1);
                        Figures.border(107, 0, 51);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TimeCo.BLL.Services.UserService.GetAllUsers();
                        userPanelOptions(username);
                        ConsoleKeyInfo key;
                        key = Console.ReadKey(true);

                        switch (key.Key)
                        {
                            case ConsoleKey.Escape:
                                {
                                    Console.Clear();
                                    Figures.border(0, 0, 51);
                                    Figures.label(30, 1);
                                    Figures.border(107, 0, 51);
                                    adminOptions(username);
                                }
                                break;
                        }
                    }
                    break;
                    //    case 2:
                    //        {
                    //            Console.Clear();
                    //            Figures.border(0, 0, 51);
                    //            Figures.label(30, 1);
                    //            Figures.border(107, 0, 51);
                    //            pm::dal::projects::showProjects();
                    //            projectPanelOptions(username);
                    //            switch (_getch())
                    //            {
                    //                case ESCAPE:
                    //                    {
                    //                        Console.Clear();
                    //                        Figures.border(0, 0, 51);
                    //                        Figures.label(30, 1);
                    //                        Figures.border(107, 0, 51);
                    //                        adminOptions(username);
                    //                    }
                    //                    break;
                    //            }
                    //        }
                    //        break;
                    //    case 3:
                    //        {
                    //            Console.Clear();
                    //            Figures.border(0, 0, 51);
                    //            Figures.label(30, 1);
                    //            Figures.border(107, 0, 51);
                    //            pm::dal::teams::showTeams();
                    //            teamPanelOptions(username);
                    //            switch (_getch())
                    //            {
                    //                case ESCAPE:
                    //                    {
                    //                        Console.Clear();
                    //                        Figures.border(0, 0, 51);
                    //                        Figures.label(30, 1);
                    //                        Figures.border(107, 0, 51);
                    //                        adminOptions(username);
                    //                    }
                    //                    break;
                    //            }
                    //        }
                    //        break;

                    //}

                    ConsoleKeyInfo keyInfo;

                    keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Escape:
                            Console.Clear();
                            MenuAccess.mainMenu();
                    }
            }
        }
    }
}
