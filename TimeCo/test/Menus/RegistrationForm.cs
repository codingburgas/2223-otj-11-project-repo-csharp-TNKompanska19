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
        // Private fields
        private AdminView _adminView;
        private MenuAccess _menuAccess;
        private Figures _figures;
        private UserView _userView;
        private TimeCo.BLL.Services.UserService _userService;
        private TimeCo.Utilities.PasswordHash _passwordHash;
        private TimeCo.BLL.Services.RoleService _roleService;

        // Constructor
        public RegistrationForm(MenuAccess menuAccess)
        {
            _adminView = new AdminView();
            _userService = new TimeCo.BLL.Services.UserService();
            _roleService = new TimeCo.BLL.Services.RoleService();
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
                // If user is admin
                if (_roleService.CheckAdmin(username) == true)
                {
                    // Admin panel options
                    Console.Clear();
                    _figures.Border(0, 0, 51);
                    _figures.TimeCoLabel(30, 1);
                    _figures.Border(107, 0, 51);
                    _adminView.AdminPanelOptions(username);
                }
                // If user is not admin
                else
                {
                    // User panel options
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

        // Function for changing password
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
            // If user is valid
            if (_userService.CheckUser(username, password) == true)
            {
                // Enter new password and change it
                Console.SetCursorPosition(45, 27);
                Console.WriteLine("ENTER NEW PASSWORD: ");
                Console.SetCursorPosition(45, 28);
                string newPass = Console.ReadLine();
                string newPassword = _passwordHash.HashPassword(pass);
            }
            // If user is not valid
            else
            {
                // Return to main menu
                Console.Clear();
                Menus.MenuAccess _menuAccess = new Menus.MenuAccess();
                Console.WriteLine(_menuAccess.MainMenu());
            }
        }
    }
}
