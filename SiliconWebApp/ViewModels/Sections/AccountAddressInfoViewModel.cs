using System.ComponentModel.DataAnnotations;

namespace SiliconWebApp.ViewModels.Sections;

public class AccountAddressInfoViewModel
{
    [Required(ErrorMessage = "Enter a valid address line")]
    [DataType(DataType.Text)]
    [Display(Name = "Address line 1", Prompt = "Enter your address line")]
    public string AddressLine1 { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Address line 2 (optional)", Prompt = "Enter your second address line")]
    public string? AddressLine2 { get; set; }

    [Required(ErrorMessage = "Enter a valid postal code")]
    [DataType(DataType.Text)]
    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "Enter a valid city")]
    [DataType(DataType.Text)]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;
}
