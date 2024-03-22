namespace SiliconWebApp.ViewModels.Sections;

public class AccountSavedItemsSectionViewModel
{
    public string MainTitle { get; set; } = null!;
    public bool DeleteAll { get; set; } = false;
    public bool RemoveItem { get; set; } = false;
    public string? CourseImageUrl { get; set; }
    public string? CourseTitle { get; set; }
    public string? CourseAuthor { get; set;}
    public decimal? CoursePrice { get; set;}
    public decimal? CourseHours { get; set; }
    public decimal? CourseRating { get; set;  }
}
