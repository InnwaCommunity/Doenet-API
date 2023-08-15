using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly IRepositoryWrapper _repositoryWrapper;
    public EmployeeController(IRepositoryWrapper RW)
    {
      _repositoryWrapper = RW;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeResult>>> GetEmployees()
    {
      var employeeItems = await _repositoryWrapper.Employee.ListEmployee();
      return Ok(employeeItems);
    }
    [HttpGet("id")]
    public async Task<ActionResult<Employee>> Getemployee(int id)
    {
      var employee = await _repositoryWrapper.Employee.FindByIDAsync(id);
      if (employee == null)
      {
        return NotFound();
      }
      return employee;
    }
    [HttpPut("id")]
    public async Task<IActionResult> PutEmployee(int id, Employee employee)
    {
      if (id != employee.EmployeeId)
      {
        return BadRequest();
      }
      Employee? objEmployee;
      try
      {
        objEmployee = await _repositoryWrapper.Employee.FindByIDAsync(id);
        if (objEmployee == null)
          throw new Exception("Invalid Employee ID");
        objEmployee.EmployeeName = employee.EmployeeName;
        await _repositoryWrapper.Employee.UpdateAsync(objEmployee);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EmployeeExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
    {
      await _repositoryWrapper.Employee.CreateAsync(employee, true);
      return CreatedAtAction(nameof(Getemployee), new { id = employee.EmployeeId }, employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
      var employee = await _repositoryWrapper.Employee.FindByIDAsync(id);
      if (employee == null)
      {
        return NotFound();
      }

      FileService.DeleteFileNameOnly("EmployeePhoto", id.ToString());
      await _repositoryWrapper.Employee.DeleteAsync(employee, true);
      return NoContent();
    }
    private bool EmployeeExists(int id)
    {
      return _repositoryWrapper.Employee.IsExists(id);
    }
  }
}