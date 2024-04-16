using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class CategoryRepository(DataContext context) : GenericRepository<CategoryEntity>(context)
{
    private readonly DataContext _context = context;
}
