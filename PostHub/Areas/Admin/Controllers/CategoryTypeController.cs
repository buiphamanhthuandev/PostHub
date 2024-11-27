using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.ViewModels;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class CategoryTypeController : Controller
    {
        private ICategoryTypeRepository _repository;

        public CategoryTypeController(ICategoryTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var categoryTypes = await _repository.GetAllAsync();
            return View(categoryTypes);
        }

        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryType = new CategoryType
                {
                    Name = model.Name
                };
                await _repository.AddAsync(categoryType);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            var categorytype = new CategoryTypeViewModel
            {
                Name = result.Name
            };
            return View(categorytype);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryTypeViewModel model, int id) {
            if (ModelState.IsValid)
            {
                var categoryType = await _repository.GetByIdAsync(id);
                if (categoryType == null) {
                    return View(model);
                }
                categoryType.Name = model.Name;
                await _repository.UpdateAsync(categoryType);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result != null)
            {
                result.State = 0;
                await _repository.UpdateAsync(result);
            }
            return RedirectToAction("Index");
        }
    }
}
