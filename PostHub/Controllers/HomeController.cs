using Microsoft.AspNetCore.Mvc;
using PostHub.Models;
using PostHub.Repositories.ManagerRepository;
using PostHub.ViewModels;
using System.Diagnostics;
using PostHub.TagHelpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
namespace PostHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, IUserManagerRepository userManagerRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _userManagerRepository = userManagerRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string nameSearch, int postId, int Page = 1, int PageSize = 10) {
            var postCounts = await _userManagerRepository.Post.GetCountAsync(nameSearch, postId);
            var pagePosts = await _userManagerRepository.Post.GetPageLinkAsync(nameSearch, postId, Page, PageSize);
            var result = new HomeViewModel
            {
                Posts = pagePosts,
                
                PagingInfo = new PagingInfo
                {
                    TotalItems = postCounts,
                    ItemsPerPage = PageSize,
                    CurrentPage = Page
                },
                CurrentCategory = postId
            };
            return View(result);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var post = await _userManagerRepository.Post.GetByIdAsync(id);
            var postRelated = await _userManagerRepository.Post.GetPostRelateAsync(4, post.CategoryId);
            var result = new DetailViewModel
            {
                Post = post, 
                PostRelates = postRelated,
            };
            if (post != null)
            {
                post.View = post.View + 1;
                _userManagerRepository.Post.UpdateAsync(post);
                await _userManagerRepository.SaveAsync();
            }
            return View(result);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(int postId, string content)
        {
            if (postId != 0 && !string.IsNullOrEmpty(content))
            {
                var result = new Comment
                {
                    Content = content,
                    PostId = postId,
                    UserId = _userManager.GetUserId(User)
                };
                _userManagerRepository.Comment.CreateAsync(result);
                await _userManagerRepository.SaveAsync();
                
                return RedirectToAction("Detail",new {id = postId});
                //return Json(new { success = true, message = "Thêm bình luận thành công." });
            }
            return RedirectToAction("Index");
            //return Json(new { success = false, message = "Thêm bình luận không thành công! vui lòng thử lại."});
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var subscribe = new Subscribe
                {
                    Email = email,
                };
                _userManagerRepository.Subscribe.CreateAsync(subscribe);
                await _userManagerRepository.SaveAsync();

                TempData["MessageSuccess"] = "Subscribe thành công. Bạn sẽ nhận thông báo về các tin tức nổi bật.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = "Có sự cố khi thêm email!, Vui lòng thử lại";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(string email, string content)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(content))
            {

                var result = new Contact
                {
                    Email = email,
                    Content = content,
                };
                _userManagerRepository.Contact.CreateAsync(result);
                await _userManagerRepository.SaveAsync();
                TempData["MessageSuccess"] = "Thêm liên hệ thành. Chúng tôi sẽ phản hồi sớm nhất cho bạn.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = "Có sự cố thêm liên hệ vui lòng thử lại!.";
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
