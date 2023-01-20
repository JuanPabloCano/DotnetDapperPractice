using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudDapper.entities.dtos;

public class DeleteEmployeeDto: EmployeeDto
{
    [Required]
    public DateTime? EndDate { get; set; }
    
    [Required]
    public bool IsActive { get; set; }
}