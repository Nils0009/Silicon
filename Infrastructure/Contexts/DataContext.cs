using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<NewsletterEntity> AspNetNewsletters { get; set; }
    public DbSet<CourseEntity> AspNetCourses { get; set; }
    public DbSet<UserCourseRegistrationEntity> AspNetUserCourseRegistrations { get; set; }
    public DbSet<UserNewsletterSubscriptionEntity> AspNetUserNewsletterSubscriptions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserCourseRegistrationEntity>()
            .HasKey(ucr => new { ucr.UserId, ucr.CourseId });

        modelBuilder.Entity<UserNewsletterSubscriptionEntity>()
            .HasKey(uns => new { uns.UserId, uns.NewsletterId });
    }
}
