using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;


namespace Infrastructure.Services;

public class SubscriberService(NewsletterRepository newsletterRepository)
{
    private readonly NewsletterRepository _newsletterRepository = newsletterRepository;
    public async Task<NewsletterEntity> CreateNewsletterSubscriptionAsync(NewsletterSubscriptionRegistrationModel model)
    {
        try
        {
            var existingSubscriber = await _newsletterRepository.GetOneAsync(x => x.Email == model.Email);

            if (existingSubscriber != null)
            {
                return existingSubscriber;
            }

            var newSubscriber = new NewsletterEntity
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                DailyNewsletter = model.DailyNewsletter,
                WeekInReview = model.WeekInReview,
                StartupsWeekly = model.StartupsWeekly,
                AdvertisingUpdates = model.AdvertisingUpdates,
                EventUpdates = model.EventUpdates,
                Podcasts = model.Podcasts,
            };
            await _newsletterRepository.CreateAsync(newSubscriber);

            return newSubscriber;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public async Task<IEnumerable<NewsletterEntity>> GetAllNewsletterSubscribersAsync()
    {
        try
        {
            var existingSubscribers = await _newsletterRepository.GetAllAsync();

            if (existingSubscribers != null)
            {
                return existingSubscribers;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public async Task<NewsletterEntity> GetOneNewsletterSubscriberAsync(string email)
    {
        try
        {
            var existingNewsletterSubscriber = await _newsletterRepository.GetOneAsync(x => x.Email == email);

            if (existingNewsletterSubscriber != null)
            {
                return existingNewsletterSubscriber;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public async Task<bool> UpdateNewsletterSubscriberAsync(NewsletterEntity entity)
    {
        try
        {
            var existingSubscriber = await _newsletterRepository.GetOneAsync(x => x.Email == entity.Email);
            if (existingSubscriber != null!)
            {
                await _newsletterRepository.UpdateAsync(x => x.Email == entity.Email, existingSubscriber);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
    public async Task<bool> DeleteNewsletterSubscriberAsync(string email)
    {
        try
        {
            var existingSubscriber = await _newsletterRepository.GetOneAsync(x => x.Email == email);
            if (existingSubscriber != null!)
            {
                await _newsletterRepository.DeleteAsync(x => x.Id == existingSubscriber.Id);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false!;
    }
}
