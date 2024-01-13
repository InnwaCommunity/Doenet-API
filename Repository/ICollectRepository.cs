
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ICollectRepository : IRepositoryBase<Collect>
    {
        bool IsExists(long id);
    }
}