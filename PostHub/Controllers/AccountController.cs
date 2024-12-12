using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using PostHub.Models;
using PostHub.Repositories.ManagerRepository;
using PostHub.ViewModels;

namespace PostHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IUserManagerRepository userManagerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userManagerRepository = userManagerRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Login()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    //var user = await _userManager.FindByEmailAsync(model.Email);
                    //if(user == null)
                    //{
                    //    return View(model);
                    //}
                    //var roles = await _userManager.GetRolesAsync(user);
                    //if (roles.Contains("admin"))
                    //{
                    //    return RedirectToAction("Index", "Home", new { area = "Admin" });
                    //}else if (roles.Contains("user"))
                    //{
                    //    return RedirectToAction("Index", "Home", new { area = "" });
                    //}
                    //else
                    //{
                    //    return View(model);
                    //}
                    return RedirectToAction("Index", "Home", new { area = "" });

                }
                else {
                    ModelState.AddModelError("", "Email or Password is incorrect!");
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName = model.Name
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult VerifyEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user == null)
                {
                    ModelState.AddModelError("", "Something is urong!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword","Account",new { email = model.Email});
                }
            }
            return View(model);
        }
        public IActionResult ChangePassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordViewModel { Email = email });
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.RemovePasswordAsync(user);
                    if (result.Succeeded)
                    {
                        result = await _userManager.AddPasswordAsync(user,model.NewPassword);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found!");
                    return View(model);
                }

            }
            else
            {
                ModelState.AddModelError("", "Something went urong try again!");
                return View(model);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> EditProfile(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Index");
            }
            var user = await _userManagerRepository.EditProFile.GetByUserNameAsync(userName);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(string userName, string fullName, string phoneNumber, DateOnly dateOfBirth)
        {
            if (!string.IsNullOrEmpty(userName)){
                var user = await _userManagerRepository.EditProFile.GetByUserNameAsync(userName);
                if (user == null)
                {
                    return RedirectToAction("Index");
                }
                if (!string.IsNullOrEmpty(fullName))
                {
                    user.FullName = fullName;
                }
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    user.PhoneNumber = phoneNumber;
                }
                
                if (dateOfBirth != DateOnly.MinValue)
                {
                    user.DateOfBirth = dateOfBirth.ToString();
                }
                _userManagerRepository.EditProFile.EditProfile(user);
                await _userManagerRepository.SaveAsync();
                return View(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditProfileImage(string userName, IFormFile image)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                if(image != null && image.Length > 0)
                {
                    var fileImage = Path.GetFileNameWithoutExtension(image.FileName);
                    var fileExtention = Path.GetExtension(image.FileName);

                    var fileName = $"{fileImage}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{fileExtention}";
                    using(var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName), FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    var user = await _userManagerRepository.EditProFile.GetByUserNameAsync(userName);
                    if (user != null)
                    {
                        user.ProfileImage = fileName;
                        _userManagerRepository.EditProFile.EditProfile(user);
                        await _userManagerRepository.SaveAsync();
                        return RedirectToAction("Index", user);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
