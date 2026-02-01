using EfCoreTph.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTph.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(
            "Host=localhost;Port=5433;Database=tphDb;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasDiscriminator<EmployeeTypeEnum>("EmployeeType")
            .HasValue<FullTimeEmployee>(EmployeeTypeEnum.FullTimeEmployee)
            .HasValue<PartTimeEmployee>(EmployeeTypeEnum.PartTimeEmployee)
            .HasValue<Contractor>(EmployeeTypeEnum.Contractor);
    }
}