﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Menus
{
    public class RegistrationForm
    {
        // Function for login
        public static void Login()
        {
            Console.SetCursorPosition(45, 21);
            Console.WriteLine("ENTER USERNAME: ");
            Console.SetCursorPosition(45, 22);
            string username = Console.ReadLine();
            Console.SetCursorPosition(45, 24);
            Console.WriteLine("ENTER PASSWORD: "); 
            Console.SetCursorPosition(45, 25);
            string pass = Console.ReadLine();
            //string password = pm::bll::passwordHashing::sha256(pass);
            if (TimeCo.BLL.Services.UserService.CheckUser(username, pass) == true)
            {
                if (TimeCo.BLL.Services.UserService.CheckAdmin(username) == true)
                {
                    Console.Clear();
                    Figures.Border(0, 0, 51);
                    Figures.TimeCoLabel(30, 1);
                    Figures.Border(107, 0, 51);
                    AdminView.AdminPanelOptions(username);
                }
                else
                {
                    Console.Clear();
                    Figures.Border(0, 0, 51);
                    Figures.TimeCoLabel(30, 1);
                    Figures.Border(107, 0, 51);
                    //standardOptions(username);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine(test.Menus.MenuAccess.MainMenu());
            }
        }
    }
}