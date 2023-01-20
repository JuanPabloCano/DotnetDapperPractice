namespace EmployeeCrudDapper.entities;

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EmployeeCode { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
}