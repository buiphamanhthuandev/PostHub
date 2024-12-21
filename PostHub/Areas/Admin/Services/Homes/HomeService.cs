using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.ViewModels.HomeViewModels;
namespace PostHub.Areas.Admin.Services.Homes
{
    public class HomeService : IHomeService
    {
        private readonly IManagerRepositoy _managerRepositoy;

        public HomeService(IManagerRepositoy managerRepositoy)
        {
            _managerRepositoy = managerRepositoy;
        }

        public async Task<HomeViewModel> GetDashbroadAsync(bool trackChange)
        {
            var result = new HomeViewModel
            {
                CategoryTypeCounts = await _managerRepositoy.CategoryType.GetCountAsync(null, trackChange),
                CategoryCounts = await _managerRepositoy.Category.GetCountAsync(null, trackChange),
                ContactCounts = await _managerRepositoy.Contact.GetCountAsync(null, trackChange),
                CommentCounts = await _managerRepositoy.Comment.GetCountAsync(null, trackChange),
                PostCounts = await _managerRepositoy.Post.GetCountAsync(null, trackChange),
                SubscribeCounts = await _managerRepositoy.Subscribe.GetCountAsync(null, trackChange),
                UserCounts = await _managerRepositoy.User.GetCountAsync(null, trackChange),
            };
            return result;
        }
    }
}
