using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.ViewModels.Sections;

public class AccountSecurityInfoViewModel
{
    [Required(ErrorMessage = "Enter your current password")]
    [Display(Name = "Current Password", Order = 0)]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;

    [Required(ErrorMessage = "Enter your new password")]
    [Display(Name = "New Password", Prompt = "Enter your new password", Order = 1)]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password")]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "Confirm your new password")]
    [Display(Name = "Confirm new password", Prompt = "Confirm you password", Order = 2)]
    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword), ErrorMessage = "Invalid password confirmation")]
    public string ConfirmNewPassword { get; set; } = null!;
}
