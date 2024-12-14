using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.Services.Categories;
using PostHub.Areas.Admin.Services.CategoryTypes;
using PostHub.Areas.Admin.Services.Contacts;
using PostHub.Areas.Admin.Services.Posts;
using PostHub.Areas.Admin.Services.Subscribes;
using PostHub.Areas.Admin.Services.Users;

namespace PostHub.Areas.Admin.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly Lazy<ICategoryTypeService> _categoryTypeService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IContactService> _contactService;
        private readonly Lazy<ISubscribeService> _subscribeService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPostService> _postService;
        public ManagerService(IManagerRepositoy managerRepositoy, IWebHostEnvironment webHostEnvironment)
        {
            _categoryTypeService = new Lazy<ICategoryTypeService>(() => new CategoryTypeService(managerRepositoy));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(managerRepositoy));
            _contactService = new Lazy<IContactService>(() => new ContactService(managerRepositoy));
            _subscribeService = new Lazy<ISubscribeService>(() => new SubscribeService(managerRepositoy));
            _userService = new Lazy<IUserService>(() => new UserService(managerRepositoy, webHostEnvironment));
            _postService = new Lazy<IPostService>(() => new PostService(managerRepositoy, webHostEnvironment));
        }
        public ICategoryTypeService CategoryType => _categoryTypeService.Value; 
        public ICategoryService Category => _categoryService.Value;
        public IContactService Contact => _contactService.Value;
        public ISubscribeService Subscribe => _subscribeService.Value;
        public IUserService User => _userService.Value;
        public IPostService Post => _postService.Value;
    }
}
