using MyCourse.Models.ViewModels;
using MyCourse.Models.ValueTypes;
using System;

namespace MyCourse.Models.Services.Application
{
    public class CourseService:ICourseService
    {
     public List<CourseViewModel> GetCourses()
        {
                var courseList=new List <CourseViewModel>();
                var rand = new Random();
                for (int i = 1; i < 20; i++)
                {
                    var price=Convert.ToDecimal(rand.NextDouble()*10+10);
                    var course = new CourseViewModel
                    {
                        id = i,
                        Title = $"Corso{i}",
                        ImagePath = "~/LogoMC.svg", 
                        CurrentPrice = new Money(Currency.EUR, price),
                        FullPrice = new Money(Currency.EUR, rand.NextDouble() > 0.5 ? price : price - 1),
                        Author = "Nome cognome",
                        Rating = rand.NextDouble() * 5.0
                    };
                    courseList.Add(course);
                }
            return courseList;

        }

        public CourseDetailViewModel GetCourse(int id)
        {
            var rand = new Random();
            var price=Convert.ToDecimal(rand.NextDouble()*10+10);
             var course = new CourseDetailViewModel
           {
                        id = id,
                        Title = $"Corso{id}",
                        ImagePath = "~/LogoMC.svg", 
                        CurrentPrice = new Money(Currency.EUR, price),
                        FullPrice = new Money(Currency.EUR, rand.NextDouble() > 0.5 ? price : price - 1),
                        Author = "Nome cognome",
                        Rating = rand.NextDouble() * 5.0,
                        Description = $"Descrizione {id}",
                        Lessons = new List <LessonViewModel>()
                    };
                    for (var i = 1; i <= 5; i++)
                    {
                      var Lesson = new LessonViewModel
                      {
                          Title = $"lezione {i}",
                          Duration = TimeSpan.FromSeconds(rand.Next(40,90))
                      };
                      course.Lessons.Add(Lesson);  
                    };


                    return course;
                 }
        }
    }