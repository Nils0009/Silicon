using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class NewsletterRepository(DataContext context) : GenericRepository<NewsletterEntity>(context)
{
    private readonly DataContext _context = context;

}
