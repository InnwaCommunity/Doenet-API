
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        bool IsExists(long id);
        Task<dynamic> GetUserListInCluster(string userName, int clusterId,int curRow,int limitRow,int loginUserid);
    }
}