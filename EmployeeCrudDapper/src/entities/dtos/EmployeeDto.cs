using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeCrudDapper.entities.dtos;

public class EmployeeDto
{
    [Required]
    [StringLength(maximumLength: 500)]
    public string? Name { get; set; }

    [Required]
    [StringLength(maximumLength: 4)]
    public string? EmployeeCode { get; set; }

    [Required]
    [StringLength(maximumLength: 255)]
    public string? Email { get; set; }
    
    public int Age { get; set; }

    [Required] public DateTime StartDate { get; set; }
}