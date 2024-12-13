using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.ViewModels.CategoryViewModels;
using PostHub.Models;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IManagerRepositoy _managerRepositoy;

        public CategoryService(IManagerRepositoy managerRepositoy)
        {
            _managerRepositoy = managerRepositoy;
        }
        public async Task<List<Category>> GetAllAsync(bool trackChanges)
        {
            return await _managerRepositoy.Category.GetAllAsync(trackChanges);
        }
        public async Task<CategoryViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            var resultPages = await _managerRepositoy.Category.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges);
            var resultCounts = await _managerRepositoy.Category.GetCountAsync(nameSearch, trackChanges);
            var result = new CategoryViewModel
            {
                Categories = resultPages,
                NameSearch = nameSearch,
                PagingInfo = new PagingInfo
                {
                    TotalItems = resultCounts,
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                }
            };
            return result;
        }
        public async Task<bool> CreateAsync(CategoryFormViewModel model)
        {
            try
            {
                var category = new Category
                {
                    Name = model.Name,
                    CategoryTypeId = model.CategoryTypeId
                };
                _managerRepositoy.Category.CreateAsync(category);
                await _managerRepositoy.SaveAsync();
                return true;
            }catch (Exception ex) 
            {
                Console.WriteLine("Message Create: ", ex.Message);
                return false;
            }
        }
        public async Task<CategoryFormViewModel> EditAsync(int id, bool trackChanges)
        {
            var category = await _managerRepositoy.Category.GetByIdAsync(id, trackChanges);
            if (category != null)
            {
                var result = new CategoryFormViewModel
                {
                    Name = category.Name,
                    CategoryTypeId = category.CategoryTypeId,
                };
                return result;
            }
            return null;
        }
        public async Task<bool> UpdateAsync(int id, CategoryFormViewModel model, bool trackChanges)
        {
            try
            {
                var category = await _managerRepositoy.Category.GetByIdAsync(id, trackChanges);
                if (category != null)
                {
                    category.Name = model.Name;
                    category.CategoryTypeId = model.CategoryTypeId;
                    _managerRepositoy.Category.UpdateAsync(category);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id, bool trackChanges)
        {
            try
            {
                var category = await _managerRepositoy.Category.GetByIdAsync(id, trackChanges);
                if(category != null)
                {
                    _managerRepositoy.Category.DeleteAsync(category);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
            
                
       
    }
}
