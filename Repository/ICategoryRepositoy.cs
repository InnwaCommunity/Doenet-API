
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<dynamic> GetCategoryListByUserId(int UserId,int ClusterId);
        bool IsExists(long id);
    }
}