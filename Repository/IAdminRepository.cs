using TodoApi.Models;

namespace TodoApi.Repositories
{
  public interface IAdminRepository : IRepositoryBase<Admin>
  {
    Task<IEnumerable<Admin>> SearchAdmin(string searchName);
    Task<IEnumerable<AdminResult>> ListAdmin();

    Task<dynamic> GetUserList(string userName,int curRow,int limitRow,int loginUserid);

    bool IsExists(long id);
  }
}