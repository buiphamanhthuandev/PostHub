using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostHub.Areas.Admin.Repositories.Categories;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.Repositories.Comments;
using PostHub.Areas.Admin.Repositories.Contacts;
using PostHub.Areas.Admin.Repositories.Posts;
using PostHub.Areas.Admin.Repositories.Subscribes;
using PostHub.Areas.Admin.Repositories.Users;
using PostHub.Areas.Admin.Services.ManagerService;
using System.Xml.Linq;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        private readonly IManagerService _managerService;

        public HomeController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<IActionResult> Index(string nameManager)
        {
            if (!string.IsNullOrEmpty(nameManager))
            {
                string temp = nameManager.ToLower();
                string[] listManager = { "dashbroad", "categorytype", "category", "post", "contact", "account", "subscribe", "comment" };
                foreach (string name in listManager)
                {
                    
                    if (name.Contains(temp))
                    {
                        switch (name)
                        {
                            case "dashbroad":
                                return RedirectToAction("Index", "Home", new { area = "Admin" });
                            case "categorytype":
                                return RedirectToAction("Index", "CategoryType", new { area = "Admin" });
                            case "category":
                                return RedirectToAction("Index", "Category", new { area = "Admin" });
                            case "post":
                                return RedirectToAction("Index", "Post", new { area = "Admin" });
                            case "contact":
                                return RedirectToAction("Index", "Contact", new { area = "Admin" });
                            case "account":
                                return RedirectToAction("Index", "User", new { area = "Admin" });
                            case "subscribe":
                                return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
                            case "comment":
                                return RedirectToAction("Index", "Comment", new { area = "Admin" });
                        }
                    }
                }
            }
            var result = await _managerService.Home.GetDashbroadAsync(trackChange: false);
            ViewBag.GetCountCateTypes = result.CategoryTypeCounts;
            ViewBag.GetCountCates = result.CategoryCounts;
            ViewBag.GetCountComments = result.CommentCounts;
            ViewBag.GetCountContacts = result.ContactCounts;
            ViewBag.GetCountPosts = result.PostCounts;
            ViewBag.GetCountSubs = result.SubscribeCounts;
            ViewBag.GetCountUsers = result.UserCounts;
            return View();
        }
    }
}
