using Microsoft.AspNetCore.Mvc;
using PostHub.Repositories.ManagerRepository;
using System;
namespace PostHub.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IUserManagerRepository _userManagerRepository;

        public SideBarViewComponent(IUserManagerRepository userManagerRepository)
        {
            _userManagerRepository = userManagerRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["SelectedCategory"] = HttpContext.Request.Query["postId"].ToString();
            var categories = await _userManagerRepository.Category.GetAllAsync();
            return View(categories);
        }
    }
}
