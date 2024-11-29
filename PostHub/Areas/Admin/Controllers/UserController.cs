using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PostHub.Areas.Admin.Repositories.Users;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private UserManager<User> _userManager;
        public UserController(IUserRepository repository, IWebHostEnvironment webHostEnvironment, UserManager<User> userManager)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }
        public async Task<IActionResult> Edit(string UserName)
        {   
            if(string.IsNullOrEmpty(UserName))
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _repository.GetByUserNameAsync(UserName);
            if (result == null)
            {
                return RedirectToAction("Index","Home","Admin");
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfileImage(string id, IFormFile image)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result != null)
            {
                if (image != null && image.Length > 0)
                {
                    var fileImage = Path.GetFileNameWithoutExtension(image.FileName);
                    var fileExtension = Path.GetExtension(image.FileName);
                    var fileName = $"{fileImage}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{fileExtension}";
                    using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName), FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    result.ProfileImage = fileName;
                }
                await _repository.UpdateAsync(result);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user != null)
            {
                user.IsActive = user.IsActive == 1 ? 0 : 1;
                await _repository.UpdateAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
