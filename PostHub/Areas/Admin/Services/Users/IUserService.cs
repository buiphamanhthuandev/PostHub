using PostHub.Areas.Admin.ViewModels.UserViewModel;
using PostHub.Models;

namespace PostHub.Areas.Admin.Services.Users
{
    public interface IUserService
    {
        Task<UserViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<User> EditProfileAsync(string userName, bool trackChanges);
        Task<bool> UpdateProfileAsync(string id, string fullName, string phoneNumber, DateOnly dateOfBirth, bool trackChanges);
        Task<bool> UpdateProfileImageAsync(string id, IFormFile image, bool trackChanges);
        Task<bool> UpdateIsActive(string id, bool trackChanges);
    }
}
