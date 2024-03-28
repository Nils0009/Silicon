using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CourseRepository(DataContext context) : GenericRepository<CourseEntity>(context)
{
    private readonly DataContext _context = context;

    public async override Task<IEnumerable<CourseEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Set<CourseEntity>()
                .Include(x => x.UserCourseRegistrations)
                .ThenInclude(uns => uns.User)
                .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }

    public async override Task<CourseEntity> GetOneAsync(Expression<Func<CourseEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<CourseEntity>()
                .Include(x => x.UserCourseRegistrations)
                .ThenInclude(uns => uns.User)
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