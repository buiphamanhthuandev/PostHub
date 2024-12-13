using PostHub.Areas.Admin.ViewModels.CategoryTypeViewModels;
using PostHub.Models;

namespace PostHub.Areas.Admin.Services.CategoryTypes
{
    public interface ICategoryTypeService
    {
        Task<List<CategoryType>> GetAllAsync(bool trackChanges);
        Task<CategoryTypeViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<bool> CreateAsync(CategoryTypeFormViewModel model);
        Task<CategoryTypeFormViewModel> EditAsync(int id, bool trackChanges);
        Task<bool> UpdateAsync(int id, CategoryTypeFormViewModel model, bool trackChanges);
        Task<bool> DeleteAsync(int id, bool trackChanges);
    }
}
