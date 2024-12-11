using PostHub.Repositories.Categories;
using PostHub.Repositories.Comments;
using PostHub.Repositories.Posts;
using PostHub.Repositories.Subscribes;

namespace PostHub.Repositories.ManagerRepository
{
    public interface IUserManagerRepository
    {
        public IUserCategoryRepository Category { get; }
        public IUserPostRepository Post { get; }
        public IUserCommentRepository Comment { get; }
        public IUserSubscribeRepository Subscribe { get; }
        Task SaveAsync();
    }
}
