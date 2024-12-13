using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.CategoryTypes
{
    public class EFCategoryTypeRepository : GenericRepo<CategoryType>, ICategoryTypeRepository
    {
        public EFCategoryTypeRepository(PostHubDbContext context):base(context) { }

        public async Task<List<CategoryType>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Where(c => c.State == 1).ToListAsync();
        }
        public async Task<List<CategoryType>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await PageLinkAsync(page, pageSize, trackChanges)
                    .Where(c => c.State == 1 && c.Name.Contains(nameSearch))
                    .ToListAsync();
            }
            return await PageLinkAsync(page, pageSize, trackChanges)
                .Where(c => c.State == 1)
                .ToListAsync();
        }
        public async Task<CategoryType> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindAll(trackChanges).Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public void CreateAsync(CategoryType categoryType)
        {
            Create(categoryType);
        }
        public void UpdateAsync(CategoryType categoryType)
        {
            Update(categoryType);
        }
        public void DeleteAsync(CategoryType categoryType)
        {
            Delete(categoryType);
        }

        public async Task<int> GetCountAsync(string nameSearch, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await FindAll(trackChanges).Where(item => item.Name.Contains(nameSearch) && item.State == 1).CountAsync();
            }
            return await FindAll(trackChanges).Where(c => c.State == 1).CountAsync();
        }
    }
}
