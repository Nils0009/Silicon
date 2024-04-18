using Infrastructure.Entities;

namespace Infrastructure.Models;

public class CourseRegistrationModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool IsBestSeller { get; set; }
    public string? LikesInNumber { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Author { get; set; }
    public string? ImgUrl { get; set; }

    public string Category { get; set; } = null!;

    public ICollection<UserCourseRegistrationEntity> UserCourseRegistration { get; set; } = [];
}
