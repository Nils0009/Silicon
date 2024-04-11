namespace Infrastructure.Entities;

public class AddressEntity
{
    public string Id { get; set; } = null!;
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public ICollection<UserEntity> Users { get; set; } = [];
}
