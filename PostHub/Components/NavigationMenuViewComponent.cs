using Microsoft.AspNetCore.Mvc;
using PostHub.Repositories.ManagerRepository;

namespace PostHub.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IUserManagerRepository _userManagerRepository;

        public NavigationMenuViewComponent(IUserManagerRepository userManagerRepository)
        {
            _userManagerRepository = userManagerRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryTypes = await _userManagerRepository.CategoryType.GetAllAsync();
            return View(categoryTypes);
        }
    }
}
