using SiliconWebApp.ViewModels.Sections;

namespace SiliconWebApp.ViewModels.Views;

public class AccountSavedItemsViewModel
{
    public AccountProfileInfoViewModel ProfileInfo { get; set; } = null!;
    public AccountSavedItemsSectionViewModel SavedItemsSection { get; set; } = null!;

}
