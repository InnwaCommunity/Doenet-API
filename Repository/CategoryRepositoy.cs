
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(TodoContext repositoryContext) : base(repositoryContext) { }
        public bool IsExists(long id)
        {
            return RepositoryContext.Categories.Any(e => e.CategoryId == id);
        }
    }
}