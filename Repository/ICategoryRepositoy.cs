
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        bool IsExists(long id);
    }
}