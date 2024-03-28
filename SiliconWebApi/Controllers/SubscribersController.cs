using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SiliconWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController(SubscriberService subscriberService) : ControllerBase
{
    private readonly SubscriberService _subscriberService = subscriberService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var subscribers = await _subscriberService.GetAllNewsletterSubscribersAsync();

            if (subscribers != null && subscribers.Any())
            {
                return Ok(subscribers);
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return BadRequest();
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetOne(string email)
    {
        try
        {
            var existingSubscriber = await _subscriberService.GetOneNewsletterSubscriberAsync(email!);
            
            if (existingSubscriber != null)
            {
                return Ok(existingSubscriber);
            }

            return NotFound();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewsletterSubscriptionRegistrationModel registrationModel)
    {
        try
        {

            if (!string.IsNullOrEmpty(registrationModel.Email))
            {
                var existingSubscriber = await _subscriberService.CreateNewsletterSubscriptionAsync(registrationModel);
                if (existingSubscriber != null)
                {
                    return Ok();
                }

                return Problem("Unable to create subscription.");
            }
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return BadRequest();
    }

    [HttpPut("{email}")]
    public async Task<IActionResult> UpdateOne (string email)
    {
        try
        {

            var existingSubscriber = await _subscriberService.GetOneNewsletterSubscriberAsync(email);

            if (existingSubscriber != null)
            {
                var updateSubscriber = await _subscriberService.UpdateNewsletterSubscriberAsync(existingSubscriber);

                if (updateSubscriber)
                    return Ok(updateSubscriber);
            }
            return NotFound();                   
                
            
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return BadRequest();   
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> DeleteOne (string email)
    {
        try
        {
            var existingSubscriber = _subscriberService.GetOneNewsletterSubscriberAsync (email);
                    
            if(existingSubscriber != null)
            {
                await _subscriberService.DeleteNewsletterSubscriberAsync(email);

                return NoContent();
            }
            return NotFound();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return BadRequest();
    }
}
