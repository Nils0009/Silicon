namespace Infrastructure.Entities;

public class ServiceEntity
{
    public string Id { get; set; } = null!;
    public bool? Order { get; set; }
    public bool? Support { get; set; }

    public string ContactId { get; set; } = null!;
    public List<ContactEntity> Contacts { get; set; } = [];
}
