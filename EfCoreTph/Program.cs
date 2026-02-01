

using EfCoreTph.Data;
using EfCoreTph.Models;
using Microsoft.EntityFrameworkCore;

using var db = new ApplicationDbContext();

var fullTime = new FullTimeEmployee
{
    Name = "Ali Hamza",
    Email = "ali@company.com",
    HireDate = DateTime.UtcNow.AddYears(-2),
    BaseSalary = 150000,
    AnnualBonus = 30000,
    VacationDays = 25
};

var partTime = new PartTimeEmployee
{
    Name = "James Anderson",
    Email = "james@anderson.com",
    HireDate = DateTime.UtcNow.AddMonths(-6),
    BaseSalary = 0,
    HourlyRate = 1200,
    WeeklyHours = 20
};

var contractor = new Contractor
{
    Name = "Frank Doe",
    Email = "Frank@agency.com",
    HireDate = DateTime.UtcNow.AddMonths(-3),
    BaseSalary = 0,
    ContractEndDate = DateTime.UtcNow.AddMonths(9),
    AgencyName = "TechStaff Ltd"
};

db.Employees.AddRange(fullTime, partTime, contractor);
db.SaveChanges();

Console.WriteLine("Employees inserted.");

var partTimers = 
    await db.Employees.OfType<PartTimeEmployee>().ToListAsync();

foreach (var item in partTimers)
{
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Email);
    Console.WriteLine(item.HireDate);
    Console.WriteLine(item.BaseSalary);
    Console.WriteLine(item.WeeklyHours);
    Console.WriteLine(item.HourlyRate);
}

var employees = await db.Employees.ToListAsync();

foreach (var emp in employees)
{
    Console.WriteLine($"[{emp.GetType().Name}] {emp.Name}");

    if (emp is FullTimeEmployee fte)
    {
        Console.WriteLine($"  Bonus: {fte.AnnualBonus}");
    }
    else if (emp is PartTimeEmployee pte)
    {
        Console.WriteLine($"  Hourly Rate: {pte.HourlyRate}");
    }
    else if (emp is Contractor c)
    {
        Console.WriteLine($"  Agency: {c.AgencyName}");
    }
}
