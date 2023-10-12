using Microsoft.EntityFrameworkCore;
using Cars.Models;

namespace Cars.Data;

public class CarsContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;

    public CarsContext(DbContextOptions<CarsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.CreatedTime).IsRequired();
            entity.ToTable("cars");
        });
    }

}