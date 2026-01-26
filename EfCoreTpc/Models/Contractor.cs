namespace EfCoreTpc.Models;

public class Contractor: Employee
{
    public DateTime ContractEndDate { get; set; }
    public string AgencyName { get; set; } = string.Empty;
}