using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Categories
{
    public class EFCategoryRepository : GenericRepo<Category>, ICategoryRepository
    {
        public EFCategoryRepository(PostHubDbContext context):base(context) { }
        public async Task<List<Category>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Where(c => c.State == 1).ToListAsync();
        }
        public async Task<List<Category>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await PageLinkAsync(page, pageSize, trackChanges).Where(c => c.State == 1 && c.Name.Contains(nameSearch)).Include(c => c.CategoryType).ToListAsync();
            }
            return await PageLinkAsync(page, pageSize, trackChanges).Where(c => c.State == 1).Include(c => c.CategoryType).ToListAsync();
        }
        public async Task<Category> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindById(item => item.Id == id && item.State == 1, trackChanges).FirstOrDefaultAsync();
        }
        public void CreateAsync(Category category)
        {
            Create(category);
        }
        public void UpdateAsync(Category category)
        {
            Update(category);
        }
        public void DeleteAsync(Category category)
        {
            Delete(category);
        }
        public async Task<int> GetCountAsync(string nameSearch, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await FindAll(trackChanges).Where(c => c.State == 1 && c.Name.Contains(nameSearch)).CountAsync();
            }
            return await FindAll(trackChanges).Where(c => c.State == 1).CountAsync();
        }
    }
}
