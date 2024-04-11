namespace SiliconWebApp.ViewModels.Sections;

public class AccountProfileInfoViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ProfileImgUrl { get; set; } = "/profile-header.svg";
    public bool IsExternalAccount { get; set; }
}
