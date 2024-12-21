using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.ViewModels.UserViewModel;
using PostHub.Models;
using PostHub.TagHelpers;

namespace PostHub.Areas.Admin.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IManagerRepositoy _managerRepositoy;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserService(IManagerRepositoy managerRepositoy, IWebHostEnvironment webHostEnvironment)
        {
            _managerRepositoy = managerRepositoy;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<UserViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            var resultPages = await _managerRepositoy.User.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges);
            var resultCounts = await _managerRepositoy.User.GetCountAsync(nameSearch, trackChanges);
            var result = new UserViewModel
            {
                Users = resultPages,
                NameSearch = nameSearch,
                PagingInfo = new PagingInfo
                {
                    TotalItems = resultCounts,
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                }
            };
            return result;
        }
        public async Task<User> EditProfileAsync(string userName, bool trackChanges)
        {
            return await _managerRepositoy.User.GetByUserNameAsync(userName, trackChanges);
        }
        public async Task<bool> UpdateProfileAsync(string id, string fullName, string phoneNumber, DateOnly dateOfBirth, bool trackChanges)
        {
            try
            {
                var user = await _managerRepositoy.User.GetByIdAsync(id, trackChanges);
                if (user != null)
                {
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
                    _managerRepositoy.User.UpdateAsync(user);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateProfileImageAsync(string id, IFormFile image, bool trackChanges)
        {
            try
            {
                if (image != null && image.Length > 0)
                {
                    var fileImage = Path.GetFileNameWithoutExtension(image.FileName);
                    var fileExtention = Path.GetExtension(image.FileName);
                    var fileName = $"{fileImage}_{DateTime.Now.ToString("yyyymmdd_HHmmss")}{fileExtention}";
                    using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName), FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    var user = await _managerRepositoy.User.GetByIdAsync(id, trackChanges);
                    if (user != null)
                    {
                        user.ProfileImage = fileName;
                        _managerRepositoy.User.UpdateAsync(user);
                        await _managerRepositoy.SaveAsync();
                        return true;

                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateIsActive(string id, bool trackChanges)
        {
            try
            {
                var user = await _managerRepositoy.User.GetByIdAsync(id, trackChanges);
                if (user != null)
                {
                    user.IsActive = user.IsActive == 1 ? 0 : 1;
                    _managerRepositoy.User.UpdateAsync(user);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> CreateAccountAsync(string fullName, string email, string password, string role)
        {
            try
            {
                var user = new User
                {
                    FullName = fullName,
                    Email = email,
                    UserName = email,
                };
                var result = await _managerRepositoy.User.CreateAccountAsync(user, password);
                if (result)
                {
                    await _managerRepositoy.User.AddToRoleAsync(user, role);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
