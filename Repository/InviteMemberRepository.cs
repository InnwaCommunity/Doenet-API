
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class InviteMemberRepository : RepositoryBase<InviteMember>, IInviteMemberRepository
    {
        public InviteMemberRepository(TodoContext repositoryContext) : base(repositoryContext) { }
        public bool IsExists(long id)
        {
            return RepositoryContext.InviteMembers.Any(e => e.InviteId == id);
        }
    }
}