using EfCoreTph.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTpt.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(
            "Host=localhost;Port=5433;Database=strongIdsDb;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().UseTptMappingStrategy();

        modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployees");
        modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployees");
        modelBuilder.Entity<Contractor>().ToTable("Contractors");
    }
}