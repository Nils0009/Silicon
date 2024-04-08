using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ServiceRepository(DataContext context) : GenericRepository<ServiceEntity>(context)
{
    private readonly DataContext _context = context;
}
