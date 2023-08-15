using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AdminController : ControllerBase
  {
    private readonly IRepositoryWrapper _repositoryWrapper;
    public AdminController(IRepositoryWrapper RW)
    {
      _repositoryWrapper = RW;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdminResult>>> GetAdmins()
    {
      var adminItems = await _repositoryWrapper.Admin.ListAdmin();
      return Ok(adminItems);
    }
    [HttpGet("id")]
    public async Task<ActionResult<Admin>> GetAdmin(int id)
    {
      var admin = await _repositoryWrapper.Admin.FindByIDAsync(id);
      if (admin == null)
      {
        return NotFound();
      }
      return admin;
    }
    [HttpPut("id")]
    public async Task<IActionResult> PutAdmin(int id, Admin admin)
    {
      if (id != admin.AdminId)
      {
        return BadRequest();
      }
      Admin? objAdmin;
      try
      {
        objAdmin = await _repositoryWrapper.Admin.FindByIDAsync(id);
        if (objAdmin == null)
          throw new Exception("Invalid Admin ID");

        FileService.DeleteFileNameOnly("AdminPhoto", id.ToString());
        FileService.MoveTempFile("AdminPhoto", admin.AdminId.ToString(), admin.AdminPhoto);

        objAdmin.AdminName = admin.AdminName;
        await _repositoryWrapper.Admin.UpdateAsync(objAdmin);
        await _repositoryWrapper.EventLog.Update(objAdmin);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AdminExists(id))
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

    [HttpPost("search/{term}")]
    public async Task<ActionResult<IEnumerable<AdminResult>>> SearchAdmin(string admin)
    {
      var adminList = await _repositoryWrapper.Admin.SearchAdmin(admin);
      return Ok(adminList);
    }




    [HttpPost]
    public async Task<ActionResult<AdminRequest>> PostAdmin(AdminRequest adminRequest)
    {

      var newobj = new Admin
      {
        AdminId = adminRequest.AdminId,
        AdminName = adminRequest.AdminName,
        AdminLevelId = adminRequest.AdminLevelId,
        LoginName = adminRequest.LoginName,
        AdminEmail = adminRequest.AdminEmail,
        Password = adminRequest.Password,
        AdminPhoto = adminRequest.AdminPhoto,
        Inactive = false,
        // IsBlock = false,
        // CreateDate = System.DateTime.Now,
        // ModifiedDate = System.DateTime.Now
      };
      var password = adminRequest.Password;

      // if (password.ToString().Length < _minPasswordLength)
      // {
      //   throw new ValidationException("Invalid Password");
      // }


      string salt = Util.SaltedHash.GenerateSalt();
      password = Util.SaltedHash.ComputeHash(salt, password.ToString());
      newobj.Password = password;
      newobj.Salt = salt;
      Validator.ValidateObject(newobj, new ValidationContext(newobj), true); //server side validation by using
      await _repositoryWrapper.Admin.CreateAsync(newobj);
      // await _repositoryWrapper.EventLog.Update(newobj);
      await _repositoryWrapper.EventLog.Insert(newobj);

      if (newobj.AdminPhoto != null && newobj.AdminPhoto != "")
      {
        FileService.MoveTempFile("AdminPhoto", newobj.AdminId.ToString(), newobj.AdminPhoto);
        // FileService.MoveTempFileDir("AdminPhoto", newobj.AdminId.ToString(), newobj.AdminPhoto);
      }
      // return new { data = AdminId };


      return CreatedAtAction(nameof(GetAdmin), new { id = newobj.AdminId }, newobj);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
      var admin = await _repositoryWrapper.Admin.FindByIDAsync(id);
      if (admin == null)
      {
        return NotFound();
      }
      FileService.DeleteFileNameOnly("AdminPhoto", id.ToString());
      await _repositoryWrapper.Admin.DeleteAsync(admin, true);
      await _repositoryWrapper.EventLog.Delete(admin);
      return NoContent();
    }
    private bool AdminExists(int id)
    {
      return _repositoryWrapper.Admin.IsExists(id);
    }
  }
}