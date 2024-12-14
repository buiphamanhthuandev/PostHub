using PostHub.Areas.Admin.Services.Categories;
using PostHub.Areas.Admin.Services.CategoryTypes;
using PostHub.Areas.Admin.Services.Contacts;
using PostHub.Areas.Admin.Services.Posts;
using PostHub.Areas.Admin.Services.Subscribes;
using PostHub.Areas.Admin.Services.Users;

namespace PostHub.Areas.Admin.Services.ManagerService
{
    public interface IManagerService
    {
        public ICategoryTypeService CategoryType {  get; }
        public ICategoryService Category { get; }
        public IContactService Contact { get; }
        public ISubscribeService Subscribe { get; }
        public IUserService User { get; }
        public IPostService Post { get; }
    }
}
