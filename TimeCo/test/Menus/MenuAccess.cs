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
        private Figures _figures;
        private RegistrationForm _registrationForm;
        public MenuAccess()
        {
            _figures = new Figures();
            _registrationForm = new RegistrationForm(null);
        }

        // Function for main menu options
        public bool MainMenu()
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

                _figures.TextInButton(51, 13, "Log in", selectedOption == 1 ? "blue" : "cyan");
                _figures.TextInButton(47, 18, "Change password", selectedOption == 2 ? "blue" : "cyan");
                _figures.TextInButton(52, 23, "Exit", selectedOption == 3 ? "blue" : "cyan");

                _figures.ComputerFigure(68, 30);
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
                            Console.Clear();
                            _figures.Border(0, 0, 51);
                            _figures.TimeCoLabel(30, 1);
                            _figures.Border(107, 0, 51);
                            _registrationForm.Login();
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

