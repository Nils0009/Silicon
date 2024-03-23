using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<NewsletterEntity> Newsletters { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<UserCourseRegistrationEntity> UserCourseRegistrations { get; set; }
    public DbSet<UserNewsletterSubscription> UserNewsletterSubscriptions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserCourseRegistrationEntity>()
            .HasKey(ucr => new { ucr.UserId, ucr.CourseId });

        modelBuilder.Entity<UserNewsletterSubscription>()
            .HasKey(uns => new { uns.UserId, uns.NewsletterId });
    }
}
