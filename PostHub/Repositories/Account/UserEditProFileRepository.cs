using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Repositories.Account
{
    public class UserEditProFileRepository : IUserEditProFileRepository
    {
        private readonly PostHubDbContext _context;

        public UserEditProFileRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users.FirstAsync(u => u.UserName == userName);
        }
        public void EditProfile(User user)
        {
            _context.Users.Update(user);
        }
    }
}
