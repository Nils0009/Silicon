using SiliconWebApp.ViewModels.Sections;

namespace SiliconWebApp.ViewModels.Views;

public class AccountDetailsViewModel
{
    public AccountProfileInfoViewModel ProfileInfo { get; set; } = null!;
    public AccountBasicInfoViewModel BasicInfo { get; set; } = null!;
    public AccountAddressInfoViewModel AddressInfo { get; set; } = null!;

}
