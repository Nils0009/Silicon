namespace Infrastructure.Entities;

public class CourseEntity
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
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public ICollection<UserCourseRegistrationEntity>? UserCourseRegistrations { get; set; } = new List<UserCourseRegistrationEntity>();
}
