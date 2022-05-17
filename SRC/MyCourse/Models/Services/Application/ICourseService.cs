using MyCourse.Models.ViewModels;
using System.Collections.Generic;
namespace MyCourse.Models.Services.Application

{
    public interface ICourseService
    {
         List<CourseViewModel>GetCourses();

        CourseDetailViewModel GetCourse(int id);
    }
}