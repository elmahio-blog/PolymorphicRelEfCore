using EfCoreTpc.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTpc.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<FullTimeEmployee> FullTimeEmployees => Set<FullTimeEmployee>();
    public DbSet<PartTimeEmployee> PartTimeEmployees => Set<PartTimeEmployee>();
    public DbSet<Contractor> Contractors => Set<Contractor>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(
            "Host=localhost;Port=5433;Database=strongIdsDb;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .UseTpcMappingStrategy();
    }
}