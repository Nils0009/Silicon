using Infrastructure.Entities;
using SiliconWebApp.ViewModels.Sections;

namespace SiliconWebApp.ViewModels.Views;

public class AccountSavedItemsViewModel
{
    public AccountProfileInfoViewModel ProfileInfo { get; set; } = null!;
    public IEnumerable<CourseEntity> UserCourses { get; set; } = new List<CourseEntity>();
    public string? ConfirmMessage { get; set; }
    public string? ErrorMessage { get; set; }
}
