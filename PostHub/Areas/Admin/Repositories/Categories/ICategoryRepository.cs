using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync(bool trackChanges);
        Task<List<Category>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<Category> GetByIdAsync(int id, bool trackChanges);
        void CreateAsync(Category category);
        void UpdateAsync(Category category);
        void DeleteAsync(Category category);

        Task<int> GetCountAsync(string nameSearch, bool trackChanges);
    }
}
