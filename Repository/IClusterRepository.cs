
using TodoApi.Models;
using training.Models;

namespace TodoApi.Repositories
{
    public interface IClusterRepository : IRepositoryBase<Cluster>
    {
        Task<List<GetClusterListComboResult>> GetClusterListByUserId(int userid);
        bool IsExists(long id);
    }
}