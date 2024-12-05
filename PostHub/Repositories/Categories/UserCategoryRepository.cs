using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Repositories.Categories
{
    public class UserCategoryRepository : IUserCategoryRepository
    {
        private readonly PostHubDbContext _context;

        public UserCategoryRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.Where(c => c.State == 1).ToListAsync();
            return categories;
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            return category;
        }
    }
}
