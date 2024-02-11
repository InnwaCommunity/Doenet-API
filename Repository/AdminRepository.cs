using System.Data;
using System.Linq;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using TodoApi.Util;

namespace TodoApi.Repositories
{
  public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
  {
    public AdminRepository(TodoContext repositoryContext) : base(repositoryContext) { }
    public async Task<IEnumerable<Admin>> SearchAdmin(string searchTerm)
    {
      return await RepositoryContext.Admins.Where(s => s.AdminName.Contains(searchTerm))
      .OrderBy(s => s.AdminId).ToListAsync();
    }
    public async Task<IEnumerable<AdminResult>> ListAdmin()
    {
      return await RepositoryContext.Admins.Select(e => new AdminResult
      {
        AdminId = e.AdminId,
        AdminName = e.AdminName,
        AdminEmail = e.AdminEmail,
        AdminLevelId = e.AdminLevelId,
        AdminLevelName = e.AdminLevel!.AdmLevName
      })
      .OrderBy(s => s.AdminId).ToListAsync();
    }

    public async Task<dynamic> GetUserList(string username, int curRow, int limitRow, int loginUserid)
    {

      dynamic parameters = new ExpandoObject();
      parameters.username = username;
      parameters.loginUserid=loginUserid;
      string query = "SELECT admin_id as UserId,admin_name as UserName FROM tbl_hc_admin WHERE admin_name LIKE CONCAT(@username, '%') AND admin_id != @loginUserid ORDER BY admin_name ASC;";

      dynamic userList = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
      List<dynamic> mainQuery = new List<dynamic>();
      List<dynamic> response = new List<dynamic>();
      mainQuery.AddRange(userList);
      mainQuery = mainQuery.Skip(curRow).Take(limitRow).ToList();
      foreach (var item in mainQuery)
      {
        var newres = new
        {
          UserIdval = Encryption.EncryptID(item.UserId.ToString(), loginUserid.ToString()),
          UserName = item.UserName
        };
        response.Add(newres);
      }
      return response;

    }
    public bool IsExists(long id)
    {
      return RepositoryContext.Admins.Any(e => e.AdminId == id);
    }


  }

}