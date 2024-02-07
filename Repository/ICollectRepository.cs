
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ICollectRepository : IRepositoryBase<Collect>
    {
        Task<dynamic> GetCollectReportList(int UserId,int CategoryId,int curRow,int pageSize);//GetCollectReportOfLoginUser
        Task<dynamic> GetCollectReportOfLoginUser(int UserId,int CategoryId,int curRow,int pageSize);
        bool IsExists(long id);
    }
}