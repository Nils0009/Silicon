using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class UserNewsletterSubscriptionRepository(DataContext context) : GenericRepository<UserNewsletterSubscriptionEntity>(context)
{
    private readonly DataContext _context = context;
}
