using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
    public class CoursesController:Controller
    {
        public IActionResult Index()
        {
            return Content ("sono Index");
        }
        public IActionResult Detail(string id)
        {
            return Content ($"Sono Detail, ho ricevuto l'id {id}");
        }



    }
}