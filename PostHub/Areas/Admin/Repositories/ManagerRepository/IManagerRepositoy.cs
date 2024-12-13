using PostHub.Areas.Admin.Repositories.Categories;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.Repositories.Comments;
using PostHub.Areas.Admin.Repositories.Contacts;
using PostHub.Areas.Admin.Repositories.Posts;
using PostHub.Areas.Admin.Repositories.Subscribes;
using PostHub.Areas.Admin.Repositories.Users;

namespace PostHub.Areas.Admin.Repositories.ManagerRepository
{
    public interface IManagerRepositoy
    {
        public ICategoryTypeRepository CategoryType { get; }
        public ICategoryRepository Category { get; }
        public ICommentRepository Comment { get; }
        public IContactRepository Contact { get; }
        public IPostRepository Post { get; }
        public ISubscribeRepository Subscribe { get; }
        public IUserRepository User { get; }
        Task SaveAsync();
    }
}
