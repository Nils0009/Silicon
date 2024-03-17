using SiliconWebApp.ViewModels.Sections;

namespace SiliconWebApp.ViewModels.Views;

public class AccountSecurityViewModel
{
    public AccountProfileInfoViewModel ProfileInfo { get; set; } = null!;
    public AccountSecurityInfoViewModel SecurityInfo { get; set; } = null!;
    public AccountSecurityDeleteInfoViewModel SecurityDeleteInfo { get; set; } = null!;
    public string? ConfirmMessage { get; set; }
    public string? ErrorMessage { get; set; }
}
