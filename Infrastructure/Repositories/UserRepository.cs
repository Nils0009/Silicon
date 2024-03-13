using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserRepository(DataContext context) : GenericRepository<UserEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Users
                .Include(x => x.Address).ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }

    public override async Task<UserEntity> GetOneAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<UserEntity>().Include(x => x.Address).FirstOrDefaultAsync(predicate);
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
