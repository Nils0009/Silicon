using Infrastructure.Models;

namespace SiliconWebApp.ViewModels.Views;

public class CoursesIndexViewModel
{
    public IEnumerable<CategoryModel>? Categories { get; set; }
    public IEnumerable<CourseRegistrationModel>? Courses { get; set;}
}
