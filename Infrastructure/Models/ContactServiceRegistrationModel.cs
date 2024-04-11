using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class ContactServiceRegistrationModel
{
    [Display(Name = "Order")]
    public bool Order { get; set; }

    [Display(Name = "Support")]
    public bool Support { get; set; }
}
