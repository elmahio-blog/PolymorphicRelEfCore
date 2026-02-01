namespace EfCoreTph.Models;

public abstract  class Employee
{
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime HireDate { get; set; } = DateTime.UtcNow.Date;
    public decimal BaseSalary { get; set; }
}