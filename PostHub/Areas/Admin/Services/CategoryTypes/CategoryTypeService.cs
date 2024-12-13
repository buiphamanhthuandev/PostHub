using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.ViewModels.CategoryTypeViewModels;
using PostHub.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using PostHub.Models;
namespace PostHub.Areas.Admin.Services.CategoryTypes
{
    public class CategoryTypeService : ICategoryTypeService
    {
        private readonly IManagerRepositoy _managerRepository;

        public CategoryTypeService(IManagerRepositoy managerRepository)
        {
            _managerRepository = managerRepository;
        }
        public async Task<List<CategoryType>> GetAllAsync(bool trackChanges)
        {
            return await _managerRepository.CategoryType.GetAllAsync(trackChanges);
        }
        public async Task<CategoryTypeViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            var resultPages = await _managerRepository.CategoryType.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges);
            var resultCounts = await _managerRepository.CategoryType.GetCountAsync(nameSearch, trackChanges);
            var result = new CategoryTypeViewModel
            {
                CategoryTypes = resultPages,
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
        public async Task<bool> CreateAsync(CategoryTypeFormViewModel model)
        {
            try
            {
                var categoryType = new CategoryType
                {
                    Name = model.Name,
                };
                _managerRepository.CategoryType.CreateAsync(categoryType);
                await _managerRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message Create: ",ex.Message);
                return false;
            }
        }
        public async Task<CategoryTypeFormViewModel> EditAsync(int id, bool trackChanges)
        {
            var categoryType = await _managerRepository.CategoryType.GetByIdAsync(id, trackChanges);
            if(categoryType != null)
            {
                var result = new CategoryTypeFormViewModel
                {
                    Name = categoryType.Name,
                };
                return result;
            }
            return null;
        }
        public async Task<bool> UpdateAsync(int id, CategoryTypeFormViewModel model, bool trackChanges)
        {
            try
            {
                var categoryType = await _managerRepository.CategoryType.GetByIdAsync(id, trackChanges);
                if (categoryType != null)
                {
                    categoryType.Name = model.Name;
                    _managerRepository.CategoryType.UpdateAsync(categoryType);
                    await _managerRepository.SaveAsync();
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
                var categoryType = await _managerRepository.CategoryType.GetByIdAsync(id, trackChanges);
                if (categoryType != null)
                {
                    _managerRepository.CategoryType.DeleteAsync(categoryType);
                    await _managerRepository.SaveAsync();
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
