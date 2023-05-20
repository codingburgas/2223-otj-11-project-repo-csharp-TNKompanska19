using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Menus
{
    public class RegistrationForm
    {
        private AdminView _adminView;
        private MenuAccess _menuAccess;
        private Figures _figures;
        private TimeCo.BLL.Services.UserService _userService;
        public RegistrationForm(MenuAccess menuAccess)
        {
            _adminView = new AdminView();
            _userService = new TimeCo.BLL.Services.UserService();
            _figures = new Figures();
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
            //string password = pm::bll::passwordHashing::sha256(pass);
            if (_userService.CheckUser(username, pass) == true)
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
                    //standardOptions(username);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine(_menuAccess.MainMenu());
            }
        }
    }
}
