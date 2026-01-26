namespace EfCoreTpc.Models;

public class FullTimeEmployee: Employee
{
    public decimal AnnualBonus { get; set; }
    public int VacationDays { get; set; }
}