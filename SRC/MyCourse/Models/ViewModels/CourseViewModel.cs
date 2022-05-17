
using MyCourse.Models.ValueTypes;
using System;
namespace MyCourse.Models.ViewModels;


public class CourseViewModel
{
    public int id { get; set; }

    public string Title { get; set; }

    public string ImagePath { get; set; }

    public string Author { get; set; }

    public double Rating { get; set; }

    public Money FullPrice { get; set; }

    public Money CurrentPrice { get; set; }
}

