using PostHub.Data;
using PostHub.Repositories.Categories;
using PostHub.Repositories.Posts;
using System.Security.Permissions;

namespace PostHub.Repositories.ManagerRepository
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly PostHubDbContext _context;
        private readonly Lazy<IUserCategoryRepository> _userCategoryRepository;
        private readonly Lazy<IUserPostRepository> _userPostRepository;

        public UserManagerRepository(PostHubDbContext context)
        {
            _context = context;
            _userCategoryRepository = new Lazy<IUserCategoryRepository>(() => new UserCategoryRepository(context));
            _userPostRepository = new Lazy<IUserPostRepository>(() => new UserPostRepository(context));
        }
        public IUserCategoryRepository Category => _userCategoryRepository.Value;
        public IUserPostRepository Post => _userPostRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
