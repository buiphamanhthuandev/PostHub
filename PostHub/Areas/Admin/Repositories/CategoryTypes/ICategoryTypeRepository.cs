using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.CategoryTypes
{
    public interface ICategoryTypeRepository
    {
        Task<List<CategoryType>> GetAllAsync(bool trackChanges);
        Task<List<CategoryType>> GetPageLinkAsync(string nameSearch,int page, int pageSize, bool trackChanges);
        Task<CategoryType> GetByIdAsync(int id, bool trackChanges);
        void CreateAsync(CategoryType categoryType);
        void UpdateAsync(CategoryType categoryType);
        void DeleteAsync(CategoryType categoryType);
        Task<int> GetCountAsync(string nameSearch, bool trackChanges);
    }
}
