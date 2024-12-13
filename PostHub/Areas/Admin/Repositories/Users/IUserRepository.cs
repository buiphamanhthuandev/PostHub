using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(bool trackChanges);
        Task<List<User>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<User> GetByIdAsync(string id, bool trackChanges);
        Task<User> GetByUserNameAsync(string username, bool trackChanges);
        void CreateAsync(User user);
        void UpdateAsync(User user);
        Task<int> GetCountAsync(string nameSearch, bool trackChanges);
    }
}
