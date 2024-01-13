
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class CollectRepository : RepositoryBase<Collect>, ICollectRepository
    {
        public CollectRepository(TodoContext repositoryContext) : base(repositoryContext) { }
        public bool IsExists(long id)
        {
            return RepositoryContext.Collects.Any(e => e.CollectId == id);
        }
    }
}