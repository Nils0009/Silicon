using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.ViewModels.Sections;

public class ContactMainFormViewModel
{
    public string Title { get; set; } = "Get In Contact With Us";

    [Display(Name = "Full name", Prompt = "Enter your full name", Order = 0)]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Invalid name")]
    [MinLength(2, ErrorMessage = "Invalid name")]
    public string FullName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 1)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string EmailAddress { get; set; } = null!;

    [Display(Name = "Service(optional)", Prompt = "Choose the service you are interested in", Order = 2)]
    [DataType(DataType.Text)]
    public string? Service { get; set; }

    [Display(Name = "Message", Prompt = "Enter your message here..", Order = 3)]
    [DataType(DataType.MultilineText)]
    [Required(ErrorMessage = "Invalid message")]
    [MinLength(2, ErrorMessage = "Invalid message")]
    public string Message { get; set; } = null!;


}
