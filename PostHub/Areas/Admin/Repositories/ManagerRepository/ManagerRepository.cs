using PostHub.Areas.Admin.Repositories.Categories;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.Repositories.Comments;
using PostHub.Areas.Admin.Repositories.Contacts;
using PostHub.Areas.Admin.Repositories.Posts;
using PostHub.Areas.Admin.Repositories.Subscribes;
using PostHub.Areas.Admin.Repositories.Users;
using PostHub.Data;
using Microsoft.AspNetCore.Identity;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.ManagerRepository
{
    public class ManagerRepository : IManagerRepositoy
    {
        private readonly PostHubDbContext _context;
        private readonly Lazy<ICategoryTypeRepository> _categoryTypeRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;
        private readonly Lazy<IContactRepository> _contactRepository;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<ISubscribeRepository> _subscribeRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        public ManagerRepository(PostHubDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _categoryTypeRepository = new Lazy<ICategoryTypeRepository>(() => new EFCategoryTypeRepository(context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new EFCategoryRepository(context));
            _commentRepository = new Lazy<ICommentRepository>(() => new EFCommentRepository(context));
            _contactRepository = new Lazy<IContactRepository>(() => new EFContactRepository(context));
            _postRepository = new Lazy<IPostRepository>(() => new EFPostRepository(context));
            _subscribeRepository = new Lazy<ISubscribeRepository>(() => new EFSubscribeRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new EFUserRepository(context, userManager));
        }
        public ICategoryTypeRepository CategoryType => _categoryTypeRepository.Value;
        public ICategoryRepository Category => _categoryRepository.Value;
        public ICommentRepository Comment => _commentRepository.Value;
        public IContactRepository Contact => _contactRepository.Value;
        public IPostRepository Post => _postRepository.Value;
        public ISubscribeRepository Subscribe => _subscribeRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
