using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostHub.Areas.Admin.Repositories.Categories;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.Repositories.Comments;
using PostHub.Areas.Admin.Repositories.Contacts;
using PostHub.Areas.Admin.Repositories.Posts;
using PostHub.Areas.Admin.Repositories.Subscribes;
using PostHub.Areas.Admin.Repositories.Users;
using System.Xml.Linq;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IPostRepository _postRepository;
        private readonly ISubscribeRepository _subscribeRepository;
        private readonly IUserRepository _userRepository;

        public HomeController(ICategoryTypeRepository categoryTypeRepository, ICategoryRepository categoryRepository, ICommentRepository commentRepository, IContactRepository contactRepository, IPostRepository postRepository, ISubscribeRepository subscribeRepository, IUserRepository userRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
            _contactRepository = contactRepository;
            _postRepository = postRepository;
            _subscribeRepository = subscribeRepository;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index(string nameManager)
        {
            if (!string.IsNullOrEmpty(nameManager))
            {
                string[] listManager = { "Dashbroad", "CategoryType", "Category", "Post", "Contact", "Account" };
                foreach (string name in listManager)
                {
                    if(name.Contains(nameManager))
                    {
                        switch (name)
                        {
                            case "Dashbroad":
                                return RedirectToAction("Index", "Home", new { area = "Admin" });
                            case "CategoryType":
                                return RedirectToAction("Index", "CategoryType", new { area = "Admin" });
                            case "Category":
                                return RedirectToAction("Index", "Category", new { area = "Admin" });
                            case "Post":
                                return RedirectToAction("Index", "Post", new { area = "Admin" });
                            case "Contact":
                                return RedirectToAction("Index", "Contact", new { area = "Admin" });
                            case "Account":
                                return RedirectToAction("Index", "User", new { area = "Admin" });
                        }
                    }
                }
            }
            ViewBag.GetCountCateTypes = await _categoryTypeRepository.GetCount();
            ViewBag.GetCountCates = await _categoryRepository.GetCount();
            ViewBag.GetCountComments = await _commentRepository.GetCount();
            ViewBag.GetCountContacts = await _contactRepository.GetCount();
            ViewBag.GetCountPosts = await _postRepository.GetCount();
            ViewBag.GetCountSubs = await _subscribeRepository.GetCount();
            ViewBag.GetCountUsers = await _userRepository.GetCount();
            return View();
        }
    }
}
