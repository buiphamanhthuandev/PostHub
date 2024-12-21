using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;
using Microsoft.AspNetCore.Identity;

namespace PostHub.Areas.Admin.Repositories.Users
{
    public class EFUserRepository : GenericRepo<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public EFUserRepository(PostHubDbContext context, UserManager<User> userManager) : base(context) {
            _userManager = userManager;
        }
        
        public async Task<List<User>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public async Task<List<User>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await PageLinkAsync(page, pageSize, trackChanges).Where(u => u.FullName.Contains(nameSearch)).ToListAsync();
            }
            return await PageLinkAsync(page, pageSize, trackChanges).ToListAsync();
        }
        public async Task<User> GetByIdAsync(string id, bool trackChanges)
        {
            return await FindById(item => item.Id == id, trackChanges).FirstOrDefaultAsync();
        }
        public async Task<User> GetByUserNameAsync(string username, bool trackChanges)
        {
            return await FindById(item => item.UserName == username, trackChanges).FirstOrDefaultAsync();
        }
        public void CreateAsync(User user)
        {
            Create(user);
        }
        public void UpdateAsync(User user)
        {
            Update(user);
        }
        public async Task<int> GetCountAsync(string nameSearch, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await FindAll(trackChanges).Where(u => u.FullName.Contains(nameSearch)).CountAsync();
            }
            return await FindAll(trackChanges).CountAsync();
        }

        public async Task<bool> CreateAccountAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task AddToRoleAsync(User user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
