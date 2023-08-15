using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
  public class EmployeeRequest
  {
    public int EmployeeId { get; set; }
    [Required]
    [StringLength(50)]
    public String EmployeeName { get; set; } = string.Empty;
    [StringLength(100)]
    public String EmployeeAddress { get; set; } = string.Empty;
    public int? EmpDepartmentId { get; set; }
  }
}