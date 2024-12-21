using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PostHub.Areas.Admin.Repositories.Users;
using PostHub.Areas.Admin.Services.ManagerService;
using PostHub.Areas.Admin.ViewModels.UserViewModel;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private UserManager<User> _userManager;

        public UserController(IManagerService managerService, IWebHostEnvironment webHostEnvironment, UserManager<User> userManager)
        {
            _managerService = managerService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string nameSearch, int page = 1, int pageSize = 10)
        {
            var result = await _managerService.User.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges: false);
            return View(result);
        }
        public async Task<IActionResult> Edit(string userName)
        {
            var result = await _managerService.User.EditProfileAsync(userName, trackChanges: true);
            if(result == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(string id, string fullName, string phoneNumber, DateOnly dateOfBirth)
        {
            var result = await _managerService.User.UpdateProfileAsync(id, fullName, phoneNumber, dateOfBirth, trackChanges: true);
            if (result)
            {
                TempData["MessageSuccess"] = $"Chỉnh sửa thông tin tài khoản thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Chỉnh sửa thông tin tài khoản không thành công!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditProfileImage(string id, IFormFile image)
        {
            var result = await _managerService.User.UpdateProfileImageAsync(id, image, trackChanges: true);
            if (result)
            {
                TempData["MessageSuccess"] = $"Chỉnh sửa hinh ảnh tài khoản thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Chỉnh sửa hình ảnh tài khoản không thành công!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(string id)
        {
            var result = await _managerService.User.UpdateIsActive(id, trackChanges: true);
            if (result)
            {
                TempData["MessageSuccess"] = $"Khóa tài khoản thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Khóa tài khoản không thành công!";
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _managerService.User.CreateAccountAsync(model.FullName, model.Email, model.Password, model.Role);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Thêm tài khoản thành công.";
                    return RedirectToAction("Index");
                }
                TempData["MessageError"] = $"Thêm tài khoản không thành công!";
                return View(model);
            }
            TempData["MessageError"] = $"Kiểm tra dữ liệu nhập!";
            return View(model);
        }
    }
}
