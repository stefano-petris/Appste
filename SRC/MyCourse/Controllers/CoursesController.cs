using Microsoft.AspNetCore.Mvc;
using MyCourse.Models.Services.Application;
using MyCourse.Models.ViewModels;
using System.Collections.Generic;


namespace MyCourse.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;

        }
        public IActionResult Index()
        {
            //return Content ("sono Index");
            ViewBag.Title = "Catalogo dei Corsi";
            /*var courseService = new CourseService();*/
            List<CourseViewModel> courses = courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            /* var courseService = new CourseService();*/
            CourseDetailViewModel Model = courseService.GetCourse(id);
            ViewData["Title"] = Model.Title;
            return View(Model);
        }



    }
}