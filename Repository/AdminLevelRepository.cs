using System.Data;
using System.Linq;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repositories
{
  public class AdminLevelRepository : RepositoryBase<AdminLevel>, IAdminLevelRepository
  {
    public AdminLevelRepository(TodoContext repositoryContext) : base(repositoryContext) { }


    // public async Task<IEnumerable<AdminLevel>> SearchAdminLevel(string searchTerm)
    // {
    //   return await RepositoryContext.AdminLevels.Where(s => s.AdmLevName.Contains(searchTerm))
    //   .OrderBy(s => s.AdminLevelId).ToListAsync();
    // }

    // public async Task<IEnumerable<AdminLevel>> ListAdminLevel()
    // {
    //   return await RepositoryContext.AdminLevels.Select(e => new AdminLevel
    //   {
    //     AdminLevelId = e.AdminLevelId,
    //     AdmLevName = e.AdmLevName,
    //   })
    //   .OrderBy(s => s.AdminLevelId).ToListAsync();
    // }

    // public bool IsExists(long id)
    // {
    //   return RepositoryContext.AdminLevels.Any(e => e.AdminLevelId == id);
    // }

  }

}