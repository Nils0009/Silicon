namespace Infrastructure.Entities;

public class NewsletterEntity
{
    public int Id { get; set; }
    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekInReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }

    public ICollection<UserEntity> Users { get; set; } = [];
}