
using TodoApi.Models;
using training.Models;

namespace TodoApi.Repositories
{
    public interface IClusterRepository : IRepositoryBase<Cluster>
    {
        Task<List<GetClusterListComboResult>> GetClusterListByUserId(int userid);//NumberOfMember
        Task<int> NumberOfMember(int clusterId);
        bool IsExists(long id);
    }
}