using PostHub.Models;

namespace PostHub.Repositories.Account
{
    public interface IUserEditProFileRepository
    {
        Task<User> GetByUserNameAsync(string userName);
        void EditProfile(User user);
    }
}
