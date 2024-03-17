using SiliconWebApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.ViewModels.Sections;

public class AccountSecurityDeleteInfoViewModel
{
    [Display(Name = "Yes. I want to delete my account.")]
    [CheckBoxRequired(ErrorMessage = "You must have the checkbox checked if you want to delete your account!")]
    public bool DeleteAccount { get; set; } = false;
}
