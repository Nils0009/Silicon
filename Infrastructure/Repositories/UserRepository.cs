using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class UserRepository(DataContext context) : GenericRepository<UserEntity>(context)
{
    private readonly DataContext _context = context;
}
