using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.PL.Menus;

namespace test.Menus
{
    public class RegistrationForm
    {
        private AdminView _adminView;
        private MenuAccess _menuAccess;
        private Figures _figures;
        private UserView _userView;
        private TimeCo.BLL.Services.UserService _userService;
        private TimeCo.Utilities.PasswordHash _passwordHash;
        public RegistrationForm(MenuAccess menuAccess)
        {
            _adminView = new AdminView();
            _userService = new TimeCo.BLL.Services.UserService();
            _figures = new Figures();
            _userView = new UserView();
            _passwordHash = new TimeCo.Utilities.PasswordHash();
            _menuAccess = menuAccess;
        }

        // Function for login
        public void Login()
        {
            Console.SetCursorPosition(45, 21);
            Console.WriteLine("ENTER USERNAME: ");
            Console.SetCursorPosition(45, 22);
            string username = Console.ReadLine();
            Console.SetCursorPosition(45, 24);
            Console.WriteLine("ENTER PASSWORD: "); 
            Console.SetCursorPosition(45, 25);
            string pass = Console.ReadLine();
            string password = _passwordHash.HashPassword(pass);
            if (_userService.CheckUser(username, password) == true)
            {
                if (_userService.CheckAdmin(username) == true)
                {
                    Console.Clear();
                    _figures.Border(0, 0, 51);
                    _figures.TimeCoLabel(30, 1);
                    _figures.Border(107, 0, 51);
                    _adminView.AdminPanelOptions(username);
                }
                else
                {
                    Console.Clear();
                    _figures.Border(0, 0, 51);
                    _figures.TimeCoLabel(30, 1);
                    _figures.Border(107, 0, 51);
                    _userView.UserPanelOptions(username);
                }
            }
            else
            {
                Console.Clear();
                Menus.MenuAccess _menuAccess = new Menus.MenuAccess();
                Console.WriteLine(_menuAccess.MainMenu());
            }
        }

        public void ChangePassword()
        {
            Console.SetCursorPosition(45, 21);
            Console.WriteLine("ENTER USERNAME: ");
            Console.SetCursorPosition(45, 22);
            string username = Console.ReadLine();
            Console.SetCursorPosition(45, 24);
            Console.WriteLine("ENTER PASSWORD: ");
            Console.SetCursorPosition(45, 25);
            string pass = Console.ReadLine();
            string password = _passwordHash.HashPassword(pass);
            if (_userService.CheckUser(username, password) == true)
            {
                Console.SetCursorPosition(45, 27);
                Console.WriteLine("ENTER NEW PASSWORD: ");
                Console.SetCursorPosition(45, 28);
                string newPass = Console.ReadLine();
                string newPassword = _passwordHash.HashPassword(pass);
            }
            else
            {
                Console.Clear();
                Menus.MenuAccess _menuAccess = new Menus.MenuAccess();
                Console.WriteLine(_menuAccess.MainMenu());
            }
        }
    }
}
