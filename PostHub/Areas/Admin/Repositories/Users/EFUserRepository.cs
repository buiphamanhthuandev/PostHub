using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Users
{
    public class EFUserRepository : IUserRepository
    {
        private readonly PostHubDbContext _context;

        public EFUserRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.Users.FirstAsync(u => u.Id == id);
        }
        public async Task<User> GetByUserNameAsync(string username)
        {
            return await _context.Users.FirstAsync(u => u.UserName == username);
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
