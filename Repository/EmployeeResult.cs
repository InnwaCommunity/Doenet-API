using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TodoApi.Models
{
  public class EmployeeResult
  {
    public int EmployeeId { get; set; }
    public String EmployeeName { get; set; } = string.Empty;
    public String EmployeeAddress { get; set; } = string.Empty;
    public int? EmpDepartmentId { get; set; }
    public String? EmpDepartmentName { get; set; }
  }
}