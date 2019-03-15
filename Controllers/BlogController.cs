using Microsoft.AspNetCore.Mvc;

namespace CustomRoute_Project{
    public class BlogController : Controller{

        public IActionResult Detail(int yil, int blogId){
            return Content("Yıl Bilgisi : " + yil + " BlogId Bilgisi : " + blogId);
        }
    }
}