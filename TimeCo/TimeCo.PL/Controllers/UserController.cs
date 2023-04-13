using Microsoft.AspNetCore.Mvc;

namespace TimeCo.PL.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser(string username, string password)
        {
            
            if (TimeCo.BLL.Services.UserService.checkUser(username, password) == true)
            {
                return RedirectToAction("Result");
            }
            else
            {
                return View();
            }
           
        }
    }
}
