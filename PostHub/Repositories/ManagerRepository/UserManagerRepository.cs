using PostHub.Data;
using PostHub.Repositories.Account;
using PostHub.Repositories.Categories;
using PostHub.Repositories.CategoryTypes;
using PostHub.Repositories.Comments;
using PostHub.Repositories.Contacts;
using PostHub.Repositories.Posts;
using PostHub.Repositories.Subscribes;
using System.Security.Permissions;

namespace PostHub.Repositories.ManagerRepository
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly PostHubDbContext _context;
        private readonly Lazy<IUserCategoryRepository> _userCategoryRepository;
        private readonly Lazy<IUserPostRepository> _userPostRepository;
        private readonly Lazy<IUserCommentRepository> _userCommentRepository;
        private readonly Lazy<IUserSubscribeRepository> _userSubscribeRepository;
        private readonly Lazy<IUserContactRepository> _userContactRepository;
        private readonly Lazy<IUserCategoryTypeRepository> _userCategoryTypeRepository;
        private readonly Lazy<IUserEditProFileRepository> _userEditProFileRepository;
        public UserManagerRepository(PostHubDbContext context)
        {
            _context = context;
            _userCategoryRepository = new Lazy<IUserCategoryRepository>(() => new UserCategoryRepository(context));
            _userPostRepository = new Lazy<IUserPostRepository>(() => new UserPostRepository(context));
            _userCommentRepository = new Lazy<IUserCommentRepository>(() => new UserCommentRepository(context));
            _userSubscribeRepository = new Lazy<IUserSubscribeRepository>(() => new UserSubscribeRepository(context));
            _userContactRepository = new Lazy<IUserContactRepository>(() => new UserContactRepository(context));
            _userCategoryTypeRepository = new Lazy<IUserCategoryTypeRepository>(() => new UserCategoryTypeRepository(context));
            _userEditProFileRepository = new Lazy<IUserEditProFileRepository>(() => new UserEditProFileRepository(context));
        }
        public IUserCategoryRepository Category => _userCategoryRepository.Value;
        public IUserPostRepository Post => _userPostRepository.Value;
        public IUserCommentRepository Comment => _userCommentRepository.Value;
        public IUserSubscribeRepository Subscribe => _userSubscribeRepository.Value;
        public IUserContactRepository Contact => _userContactRepository.Value;
        public IUserCategoryTypeRepository CategoryType => _userCategoryTypeRepository.Value;
        public IUserEditProFileRepository EditProFile => _userEditProFileRepository.Value;
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
