using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
    public class HomeController:Controller
    {
       public IActionResult Index()
       {
           return Content ("sono la Index della Home");
       } 
    }
}