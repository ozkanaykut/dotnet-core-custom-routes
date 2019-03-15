using Microsoft.AspNetCore.Mvc;

namespace CustomRoute_Project{
    public class HomeController : Controller{

        public IActionResult Index(){
            return View();
        }

    }
}