using PostHub.Areas.Admin.ViewModels.CategoryViewModels;
using PostHub.Models;
namespace PostHub.Areas.Admin.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync(bool trackChanges);
        Task<CategoryViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<bool> CreateAsync(CategoryFormViewModel model);
        Task<CategoryFormViewModel> EditAsync(int id, bool trackChanges);
        Task<bool> UpdateAsync(int id, CategoryFormViewModel model, bool trackChanges);
        Task<bool> DeleteAsync(int id, bool trackChanges);
    }
}
