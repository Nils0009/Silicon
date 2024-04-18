using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.ViewModels.Sections;

public class AccountBasicInfoViewModel
{
    public string UserId { get; set; } = null!;

    [Required(ErrorMessage = "Enter a valid first name")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Enter a valid last name")]
    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Enter a valid email address")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone", Prompt = "Enter your phone")]
    public string? Phone { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = "Bio", Prompt = "Add a short bio..")]
    public string? Bio { get; set; }
}
