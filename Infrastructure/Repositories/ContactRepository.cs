using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ContactRepository(DataContext context) : GenericRepository<ContactEntity>(context)
{
    private readonly DataContext _context = context;
}
