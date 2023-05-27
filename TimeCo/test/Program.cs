using TimeCo.DAL.Repositories;
using TimeCo.DAL.Entities;
using TimeCo.BLL.Services;
namespace test
{
    internal class Program
    {
        // Main function
        public static void Main(string[] args)
        {
            Menus.MenuAccess _menuAccess = new Menus.MenuAccess();
            do
            {
                // Main menu
                Console.WriteLine(_menuAccess.MainMenu());
            }
            while (true);
        }
    }
}