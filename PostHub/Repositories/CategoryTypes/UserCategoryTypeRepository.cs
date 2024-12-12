using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Repositories.CategoryTypes
{
    public class UserCategoryTypeRepository : IUserCategoryTypeRepository
    {
        private readonly PostHubDbContext _context;

        public UserCategoryTypeRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryType>> GetAllAsync()
        {
            return await _context.CategoryTypes.Where(c => c.State == 1).Include(c => c.Categories.Where(c => c.State == 1)).ToListAsync();
        }
    }
}
