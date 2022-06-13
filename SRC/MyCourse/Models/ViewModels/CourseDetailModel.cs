using MyCourse.Models.Application;
using MyCourse.Models.Services.Infrastructure;
using MyCourse.Models.ValueTypes;
using System.Data;
namespace MyCourse.Models.ViewModels
{
    public class CourseDetailViewModel:CourseViewModel

    {

    public string Description { get; set; }
    public List <LessonViewModel> Lessons { get; set; }

    public TimeSpan TotalCourseDuration
        {
        get=> TimeSpan.FromSeconds(Lessons.Sum(l => l.Duration.TotalSeconds));
        }
        

       public static CourseDetailViewModel FromDetailDataRow(DataRow courseRow)
        {
        var courseDetailViewModel= new CourseDetailViewModel 
            {
            id= Convert.ToInt32(courseRow["Id"]), 
            Lessons= new List<LessonViewModel>(),
            Title= (string) courseRow["Title"],
            Description=(string) courseRow ["Description"],
            ImagePath= (string) courseRow["Imagepath"],
            Author=(string) courseRow["Author"],
            Rating= (double) courseRow["Rating"],
            FullPrice=new Money( (string) courseRow["FullPrice_Currency"], (Int64) courseRow["FullPtice_Amount"]),
            CurrentPrice = new Money( (string) courseRow["CurrentPrice_Currency"], (Int64) courseRow["CurrentPrice_Amount"])
            };

        return courseDetailViewModel; 
        }
    }

}