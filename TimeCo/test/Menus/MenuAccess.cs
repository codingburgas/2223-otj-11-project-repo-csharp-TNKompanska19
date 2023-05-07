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
        public static bool mainMenu()
        {
            int counter = 0;

            Figures.border(0, 0, 51);
            Figures.teamFigure(10, 33);
            Figures.label(30, 1);
            Figures.button(43, 11, "blue");
            Figures.button(43, 16, "cyan");
            Figures.button(43, 21, "cyan");
            Figures.button(43, 26, "cyan");
            Figures.textInButton(51, 13, "Log in", "blue");
            Figures.textInButton(48, 18, "Registration", "cyan");
            Figures.textInButton(47, 23, "Change password", "cyan");
            Figures.textInButton(52, 28, "Exit", "cyan");
            Figures.computerFigure(68, 30);
            Figures.border(107, 0, 51);

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            switch (counter)
                            {
                                case 0:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11, "blue");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in", "blue");
                                        Figures.textInButton(48, 18, "Registration", "cyan");
                                        Figures.textInButton(47, 23, "Change password", "cyan");
                                        Figures.textInButton(52, 28, "Exit", "cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 4;
                                    }break;
                                case 1:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11, "blue");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in","blue");
                                        Figures.textInButton(48, 18, "Registration","cyan");
                                        Figures.textInButton(47, 23, "Change password","cyan");
                                        Figures.textInButton(52, 28, "Exit","cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 4;
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11,"cyan");
                                        Figures.button(43, 16,"blue");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in","cyan");
                                        Figures.textInButton(48, 18, "Registration","blue");
                                        Figures.textInButton(47, 23, "Change password","cyan");
                                        Figures.textInButton(52, 28, "Exit","cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 1;
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11, "cyan");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21,"blue");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in","cyan");
                                        Figures.textInButton(48, 18, "Registration","cyan");
                                        Figures.textInButton(47, 23, "Change password","blue");
                                        Figures.textInButton(52, 28, "Exit","cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 2;
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11,"cyan");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26,"blue");
                                        Figures.textInButton(51, 13, "Log in","cyan");
                                        Figures.textInButton(48, 18, "Registration","cyan");
                                        Figures.textInButton(47, 23, "Change password","cyan");
                                        Figures.textInButton(52, 28, "Exit","blue");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 3;
                                    }
                                    break;
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        {
                            switch (counter)
                            {
                                case 0:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11, "blue");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in", "blue");
                                        Figures.textInButton(48, 18, "Registration", "cyan");
                                        Figures.textInButton(47, 23, "Change password", "cyan");
                                        Figures.textInButton(52, 28, "Exit", "cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 2;
                                    }
                                    break;
                                case 1:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11, "blue");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in","blue");
                                        Figures.textInButton(48, 18, "Registration","cyan");
                                        Figures.textInButton(47, 23, "Change password","cyan");
                                        Figures.textInButton(52, 28, "Exit","cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 2;
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11,"cyan");
                                        Figures.button(43, 16,"blue");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in","cyan");
                                        Figures.textInButton(48, 18, "Registration","blue");
                                        Figures.textInButton(47, 23, "Change password","cyan");
                                        Figures.textInButton(52, 28, "Exit","cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 3;
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11,"cyan");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21,"blue");
                                        Figures.button(43, 26, "cyan");
                                        Figures.textInButton(51, 13, "Log in","cyan");
                                        Figures.textInButton(48, 18, "Registration","cyan");
                                        Figures.textInButton(47, 23, "Change password","blue");
                                        Figures.textInButton(52, 28, "Exit","cyan");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 4;
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.teamFigure(10, 33);
                                        Figures.label(30, 1);
                                        Figures.button(43, 11,"cyan");
                                        Figures.button(43, 16, "cyan");
                                        Figures.button(43, 21, "cyan");
                                        Figures.button(43, 26,"blue");
                                        Figures.textInButton(51, 13, "Log in","cyan");
                                        Figures.textInButton(48, 18, "Registration","cyan");
                                        Figures.textInButton(47, 23, "Change password","cyan");
                                        Figures.textInButton(52, 28, "Exit","blue");
                                        Figures.computerFigure(68, 30);
                                        Figures.border(107, 0, 51);
                                        counter = 1;
                                    }
                                    break;
                            }
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        {
                            switch (counter)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.label(30, 1);
                                        Figures.border(107, 0, 51);
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.label(30, 1);
                                        Figures.border(107, 0, 51);
                                        
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.label(30, 1);
                                        Figures.border(107, 0, 51);
                                       

                                    }
                                    break;
                                case 4:
                                    {
                                        Console.Clear();
                                        Figures.border(0, 0, 51);
                                        Figures.label(30, 1);
                                        Figures.border(107, 0, 51);
                                        
                                    }
                                    break;
                                
                            }
                        }break;
                }
            } while (true);
            return true;
        }
    }
}

