
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface IInviteMemberRepository : IRepositoryBase<InviteMember>
    {
        bool IsExists(long id);
    }
}