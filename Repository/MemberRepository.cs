
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(TodoContext repositoryContext) : base(repositoryContext) { }
        public bool IsExists(long id)
        {
            return RepositoryContext.Members.Any(e => e.MemberId == id);
        }
    }
}