namespace EfCoreTph.Models;

public class PartTimeEmployee: Employee
{
    public decimal HourlyRate { get; set; }
    public int WeeklyHours { get; set; }
}