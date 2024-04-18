using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class UserCourseRegistrationRepository(DataContext context) : GenericRepository<UserCourseRegistrationEntity>(context)
{
    private readonly DataContext _context = context;
}
