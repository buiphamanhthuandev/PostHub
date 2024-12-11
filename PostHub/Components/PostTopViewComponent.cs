using Microsoft.AspNetCore.Mvc;
using PostHub.Repositories.ManagerRepository;

namespace PostHub.Components
{
    public class PostTopViewComponent : ViewComponent
    {
        private readonly IUserManagerRepository _userManagerRepository;

        public PostTopViewComponent(IUserManagerRepository userManagerRepository)
        {
            _userManagerRepository = userManagerRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var postTopViews = await _userManagerRepository.Post.GetPostTopViewAsync(5);
            return View(postTopViews);
        }
    }
}
