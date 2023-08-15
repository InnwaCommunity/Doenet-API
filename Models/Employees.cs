using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TodoApi.Models
{
  [Table("tbl_employee")]
  public class Employee : BaseModel
  {
    [Column("employee_id")]
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [Column("employee_name")]
    [StringLength(50)]
    public String EmployeeName { get; set; } = string.Empty;
    [Column("employee_address")]
    [StringLength(100)]
    public String EmployeeAddress { get; set; } = string.Empty;
    [Column("employee_department_id")]
    public int? EmpDepartmentId { get; set; }
    [ForeignKey("EmpDepartmentId")]
    public Department? EmpDepartment { get; set; }
  }
}