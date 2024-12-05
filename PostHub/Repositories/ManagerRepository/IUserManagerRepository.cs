using PostHub.Repositories.Categories;
using PostHub.Repositories.Posts;

namespace PostHub.Repositories.ManagerRepository
{
    public interface IUserManagerRepository
    {
        public IUserCategoryRepository Category { get; }
        public IUserPostRepository Post { get; }
    }
}
