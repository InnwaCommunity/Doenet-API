using TodoApi.Models;

namespace TodoApi.Repositories
{
  public interface IAdminRepository : IRepositoryBase<Admin>
  {
    Task<IEnumerable<Admin>> SearchAdmin(string searchName);
    Task<IEnumerable<AdminResult>> ListAdmin();
    bool IsExists(long id);
  }
}