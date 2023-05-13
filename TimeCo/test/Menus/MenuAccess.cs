using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace test.Menus
{
    public class MenuAccess
    {
        // Function for main menu options
        public static bool MainMenu()
        {
            int selectedOption = 1;
            while (true)
            {
                Console.Clear();

                Figures.border(0, 0, 51);
                Figures.teamFigure(10, 33);
                Figures.label(30, 1);
                Figures.button(43, 11, selectedOption == 1 ? "blue" : "cyan");
                Figures.button(43, 16, selectedOption == 2 ? "blue" : "cyan");
                Figures.button(43, 21, selectedOption == 3 ? "blue" : "cyan");

                Figures.textInButton(51, 13, "Log in", selectedOption == 1 ? "blue" : "cyan");
                Figures.textInButton(47, 18, "Change password", selectedOption == 2 ? "blue" : "cyan");
                Figures.textInButton(52, 23, "Exit", selectedOption == 3 ? "blue" : "cyan");

                Figures.computerFigure(68, 30);
                Figures.border(107, 0, 51);

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
                            Console.Clear();
                            Figures.border(0, 0, 51);
                            Figures.label(30, 1);
                            Figures.border(107, 0, 51);
                            RegistrationForm.login();
                            break;
                        case 2:
                            Console.WriteLine("Selected: Change password");
                            break;
                        case 3:
                            Environment.Exit(1);
                            break;
                    }
                }
            }
            return true;
        }




               
        
    }
}

