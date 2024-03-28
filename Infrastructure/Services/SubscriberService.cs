using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class SubscriberService(NewsletterRepository newsletterRepository, UserRepository userRepository, UserNewsletterSubscriptionRepository userNewsletterSubscriptionRepository)
{
    private readonly NewsletterRepository _newsletterRepository = newsletterRepository;
    private readonly UserRepository _userRepository = userRepository;
    private readonly UserNewsletterSubscriptionRepository _userNewsletterSubscriptionRepository = userNewsletterSubscriptionRepository;
    public async Task<NewsletterEntity> CreateNewsletterSubscriptionAsync(NewsletterSubscriptionRegistrationModel model)
    {
        try
        {
            var existingUser = await _userRepository.GetOneAsync(x => x.Email == model.Email);
            if (existingUser == null) { return null!; };

            var existingSubscription = await _newsletterRepository.GetOneAsync(x => x.Email == model.Email);
            if (existingSubscription == null)
            {
                var newSubscriber = new NewsletterEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = model.Email,
                };

                await _newsletterRepository.CreateAsync(newSubscriber);

                var userSubscription = new UserNewsletterSubscriptionEntity
                {
                    User = existingUser,
                    UserId = existingUser.Id,
                    NewsletterId = newSubscriber.Id
                };

                await _userNewsletterSubscriptionRepository.CreateAsync(userSubscription);

                return newSubscriber;
            }

            if (existingSubscription != null)
            {
                var existingSubscriptionUser = await _userNewsletterSubscriptionRepository.GetOneAsync(x => x.NewsletterId == existingSubscription.Id);
                if (existingSubscriptionUser == null) 
                {
                    existingSubscription.Id = existingSubscriptionUser!.NewsletterId;
                    
                }
                return existingSubscription;
            }

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
    public async Task<bool> UpdateNewsletterSubscriberAsync(NewsletterEntity newsletterEntity)
    {
        try
        {
            var existingSubscriber = await _newsletterRepository.GetOneAsync(x => x.Email == newsletterEntity.Email);
            if (existingSubscriber != null!)
            {
                await _newsletterRepository.UpdateAsync(x => x.Email == newsletterEntity.Email, newsletterEntity);
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
            var existingUser = await _userRepository.GetOneAsync(x => x.Email == email);
            if (existingUser == null) { return false; }

            var existingSubscriber = await _newsletterRepository.GetOneAsync(x => x.Email == email);
            if (existingSubscriber != null!)
            {
                await _newsletterRepository.DeleteAsync(x => x.Email == email && x.UserNewsletterSubscription.Any(sub => sub.UserId == existingUser.Id));
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
