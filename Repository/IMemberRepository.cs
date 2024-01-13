
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        bool IsExists(long id);
    }
}