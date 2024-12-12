using PostHub.Repositories.Account;
using PostHub.Repositories.Categories;
using PostHub.Repositories.CategoryTypes;
using PostHub.Repositories.Comments;
using PostHub.Repositories.Contacts;
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
        public IUserContactRepository Contact { get; }
        public IUserCategoryTypeRepository CategoryType { get; }
        public IUserEditProFileRepository EditProFile { get; }
        Task SaveAsync();
    }
}
