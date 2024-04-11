namespace Infrastructure.Entities;

public class ContactEntity
{
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Message { get; set; } = null!;

    public string? ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }
}
