using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.ViewModels.Sections;

public class ContactRegistrationViewModel
{
    [Display(Name = "Full name", Prompt = "Enter your full name", Order = 0)]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Invalid full name")]
    [MinLength(2, ErrorMessage = "Invalid full name")]
    public string FullName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 1)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string EmailAddress { get; set; } = null!;

    [Display(Name = "Message", Prompt = "Enter your message here..", Order = 2)]
    [DataType(DataType.MultilineText)]
    [Required(ErrorMessage = "Invalid message")]
    [MinLength(2, ErrorMessage = "Invalid message")]
    public string Message { get; set; } = null!;

    [Display(Name = "Select a service")]
    public string? SelectedService { get; set; }
    public ContactServiceRegistrationModel ContactServiceReg { get; set; } = new ContactServiceRegistrationModel();
    public string? ConfirmMessage { get; set; }
    public string? ErrorMessage { get; set; }
}
