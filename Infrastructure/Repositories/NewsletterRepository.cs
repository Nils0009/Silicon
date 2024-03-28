using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class NewsletterRepository(DataContext context) : GenericRepository<NewsletterEntity>(context)
{
    private readonly DataContext _context = context;

    public async override Task<IEnumerable<NewsletterEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Set<NewsletterEntity>().ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }

    public async override Task<NewsletterEntity> GetOneAsync(Expression<Func<NewsletterEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<NewsletterEntity>()
                .Include(x => x.UserNewsletterSubscription)
                .FirstOrDefaultAsync(predicate);
            if (result != null)
                return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }
}
