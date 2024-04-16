namespace Infrastructure.Models;

public class ContactReqistrationModel
{
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string? SelectedService { get; set; }
    public ContactServiceRegistrationModel ContactServiceReg { get; set; } = new ContactServiceRegistrationModel();

}
