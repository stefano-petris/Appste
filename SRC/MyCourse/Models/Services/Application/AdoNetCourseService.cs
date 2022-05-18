using MyCourse.Models.ViewModels;
using System.Collections.Generic;
using MyCourse.Models.Services.Infrastructure;
using System.Data;

namespace MyCourse.Models.Services.Application
{

    public class AdoNetCourseService : ICourseService
    {

        private readonly IDatabaseAccessor db;

        public AdoNetCourseService(IDatabaseAccessor db)
        {
            this.db = db;

        }


        public CourseDetailViewModel GetCourse(int id)
        {
            throw new NotImplementedException();

            
        }

        public List<CourseViewModel> GetCourses()
        {
            throw new NotImplementedException();

            string query ="SELECT*FROM Courses";
            DataSet dataSet = db.Query(query);

        }
    }

}