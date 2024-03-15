using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class NewsletterRepository(DataContext context) : GenericRepository<NewsletterEntity>(context)
{
    private readonly DataContext _context = context;
}
