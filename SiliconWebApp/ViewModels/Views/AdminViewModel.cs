using Infrastructure.Entities;
using SiliconWebApp.ViewModels.Sections;

namespace SiliconWebApp.ViewModels.Views;

public class AdminViewModel
{
    public AccountProfileInfoViewModel ProfileInfo { get; set; } = null!;

    public IEnumerable<CourseEntity> courses { get; set; } = new List<CourseEntity>();
    public IEnumerable<NewsletterEntity> newsletter { get; set; } = new List<NewsletterEntity>();
}
