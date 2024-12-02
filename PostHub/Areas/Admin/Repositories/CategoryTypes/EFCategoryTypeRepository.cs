using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.CategoryTypes
{
    public class EFCategoryTypeRepository : ICategoryTypeRepository
    {
        private PostHubDbContext _context;
        public EFCategoryTypeRepository(PostHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryType>> GetAllAsync()
        {
            return await _context.CategoryTypes.Where(c => c.State == 1).ToListAsync();
        }
        public async Task<CategoryType> GetByIdAsync(int id)
        {
            return await _context.CategoryTypes.FirstAsync(c => c.Id == id);
        }

        public async Task AddAsync(CategoryType categoryType)
        {
            _context.CategoryTypes.Add(categoryType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CategoryType categoryType)
        {
            _context.CategoryTypes.Update(categoryType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(int id)
        {   
            var categoryType = await GetByIdAsync(id);
            if (categoryType != null)
            {
                _context.CategoryTypes.Remove(categoryType);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> GetCount()
        {
            return await _context.CategoryTypes.Where(c => c.State == 1).CountAsync();
        }
    }
}
