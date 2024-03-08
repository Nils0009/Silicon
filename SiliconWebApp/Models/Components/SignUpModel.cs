using SiliconWebApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.Models.Components;

public class SignUpModel
{
    [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Invalid first name")]
    [MinLength(2, ErrorMessage = "Invalid first name")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Invalid last name")]
    [MinLength(2, ErrorMessage = "Invalid last name")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string EmailAddress { get; set; } = null!;


    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password")]
    public string Password { get; set; } = null!;


    [Display(Name = "Confirm password", Prompt = "Confirm you password", Order = 4)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Invalid password confirmation")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "I agree to the Terms & Conditions", Order = 5)]
    [CheckBoxRequired(ErrorMessage = "You must accept the terms and conditions")]
    public bool TermsAndConditions { get; set; } = false!;
}
