using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class NewsletterEntity
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<UserNewsletterSubscriptionEntity> UserNewsletterSubscription { get; set; } = null!;
}
