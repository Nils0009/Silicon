namespace Infrastructure.Models;

public class CourseResult
{
    public bool Succeeded { get; set; }
    public IEnumerable<CourseRegistrationModel>? Courses { get; set; }
}
