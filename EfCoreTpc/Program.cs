
using EfCoreTpc.Data;
using EfCoreTpc.Models;

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


var employees = db.Employees.ToList();

foreach (var emp in employees)
{
    Console.WriteLine($"[{emp.GetType().Name}] {emp.Name}");
}
