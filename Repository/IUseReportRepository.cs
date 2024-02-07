
using TodoApi.Models;
using training.Models;

namespace TodoApi.Repositories
{
    public interface IUseReportRepository : IRepositoryBase<UseReport>
    {
        Task<dynamic> GetUseReportList(int UserId,int CategoryId,int curRow,int pageSize);
        bool IsExists(long id);
    }
}