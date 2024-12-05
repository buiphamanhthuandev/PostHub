using Microsoft.AspNetCore.Mvc;
using PostHub.Models;
using PostHub.Repositories.ManagerRepository;
using PostHub.ViewModels;
using System.Diagnostics;
using PostHub.TagHelpers;
namespace PostHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserManagerRepository _userManagerRepository;
        public HomeController(ILogger<HomeController> logger, IUserManagerRepository userManagerRepository)
        {
            _logger = logger;
            _userManagerRepository = userManagerRepository;
        }

        public async Task<IActionResult> Index(int Page = 1, int PageSize = 10) { 
            var posts = await _userManagerRepository.Post.GetAllAsync();
            var pagePosts = await _userManagerRepository.Post.GetPageLinkAsync(Page, PageSize);
            var postTopViews = await _userManagerRepository.Post.GetPostTopViewAsync(5);
            var categories = await _userManagerRepository.Category.GetAllAsync();
            var result = new HomeViewModel
            {
                Posts = pagePosts,
                PostTopViews = postTopViews,
                Categories = categories,
                PagingInfo = new PagingInfo
                {
                    TotalItems = posts.Count(),
                    ItemsPerPage = PageSize,
                    CurrentPage = Page
                }
            };
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
