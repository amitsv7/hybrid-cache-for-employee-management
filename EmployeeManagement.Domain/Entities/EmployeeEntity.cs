using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities;

public class EmployeeEntity
{
    [Key] [Microsoft.Build.Framework.Required] 
    public Guid EmpNo { get; set; }
    [Required] [MaxLength(12)]
    public string FirstName { get; set; }
    [Required][MaxLength(12)]
    public string MiddleName { get; set; }
    [Required][MaxLength(12)]
    public string LastName { get; set; }
    [MaxLength(3)]
    public string WorkDept { get; set; }
    public string PhoneNo { get; set; }
    public DateTime? HireDate { get; set; }
    public string Job { get; set; }
    [Required]
    public short EmpLevel { get; set; }
    public char? Sex { get; set; }
    public DateTime? BirthDate { get; set; }
    public decimal? Salary { get; set; }
}