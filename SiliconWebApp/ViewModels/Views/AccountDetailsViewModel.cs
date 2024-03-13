using SiliconWebApp.ViewModels.Sections;

namespace SiliconWebApp.ViewModels.Views;

public class AccountDetailsViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ProfileImgUrl { get; set; } = "/profile-header.svg";

    public AccountBasicInfoViewModel? BasicInfo { get; set; }
    public AccountAddressInfoViewModel? AddressInfo { get; set; }

}
