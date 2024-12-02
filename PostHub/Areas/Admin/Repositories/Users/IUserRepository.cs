using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> GetByUserNameAsync(string username);
        //Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<int> GetCount();
    }
}
