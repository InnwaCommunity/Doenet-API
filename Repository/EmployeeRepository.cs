using System.Data;
using System.Linq;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repositories
{
  public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
  {
    public EmployeeRepository(TodoContext repositoryContext) : base(repositoryContext) { }
    public async Task<IEnumerable<Employee>> SearchEmployee(string searchTerm)
    {
      return await RepositoryContext.Employees.Where(s => s.EmployeeName.Contains(searchTerm))
      .OrderBy(s => s.EmployeeId).ToListAsync();
    }
    public async Task<IEnumerable<EmployeeResult>> ListEmployee()
    {
      return await RepositoryContext.Employees.Select(e => new EmployeeResult
      {
        EmployeeId = e.EmployeeId,
        EmployeeName = e.EmployeeName,
        EmployeeAddress = e.EmployeeAddress,
        EmpDepartmentId = e.EmpDepartmentId,
        EmpDepartmentName = e.EmpDepartment!.DeptName
      })
      .OrderBy(s => s.EmployeeId).ToListAsync();
    }
    public bool IsExists(long id)
    {
      return RepositoryContext.Employees.Any(e => e.EmployeeId == id);
    }

  }

}