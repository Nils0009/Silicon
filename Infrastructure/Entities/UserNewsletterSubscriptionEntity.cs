namespace Infrastructure.Entities;

public class UserNewsletterSubscriptionEntity
{
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public string NewsletterId { get; set; } = null!;
    public NewsletterEntity Newsletter { get; set; } = null!;
}