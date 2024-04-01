namespace Infrastructure.Entities;

public class UserCourseRegistrationEntity
{
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public string CourseId { get; set; } = null!;
    public CourseEntity Course { get; set; } = null!;

    public DateTime RegistationDate { get; set; }
}
