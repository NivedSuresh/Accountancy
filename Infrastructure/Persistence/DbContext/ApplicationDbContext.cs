using Domain.Entities;

namespace Infrastructure.Persistence.DbContext;

using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasOne(c => c.Address)
            .WithMany()
            .HasForeignKey(c => c.AddressId);

    }

    public DbSet<Company> Companies { get; set; } // Example DbSet
}

