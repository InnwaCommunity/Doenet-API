using System.Data;
using System.Linq;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

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
    public bool IsExists(long id)
    {
      return RepositoryContext.Admins.Any(e => e.AdminId == id);
    }


  }

}