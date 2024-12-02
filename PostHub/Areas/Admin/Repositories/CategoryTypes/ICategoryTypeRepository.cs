using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.CategoryTypes
{
    public interface ICategoryTypeRepository
    {
        Task<IEnumerable<CategoryType>> GetAllAsync();
        Task<CategoryType> GetByIdAsync(int id);
        Task AddAsync(CategoryType categoryType);
        Task UpdateAsync(CategoryType categoryType);
        Task DeleteByIdAsync(int id);
        Task<int> GetCount();
    }
}
