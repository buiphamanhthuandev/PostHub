using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.Services.ManagerService;
using PostHub.Areas.Admin.ViewModels;
using PostHub.Areas.Admin.ViewModels.CategoryTypeViewModels;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class CategoryTypeController : Controller
    {
        private readonly IManagerService _managerService;

        public CategoryTypeController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<IActionResult> Index(string nameSearch, int page = 1, int pageSize = 10)
        {
            var result = await _managerService.CategoryType.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges: false);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryTypeFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _managerService.CategoryType.CreateAsync(model);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Thêm loại danh mục: {model.Name} thành công.";
                    return RedirectToAction("Index");
                }
                TempData["MessageError"] = $"Thêm loại danh mục: {model.Name} không thành công!";
                return View(model);
            }
            TempData["MessageError"] = $"Thêm loại danh mục: {model.Name} không thành công!";
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _managerService.CategoryType.EditAsync(id, trackChanges: true);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryTypeFormViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _managerService.CategoryType.UpdateAsync(id, model, trackChanges: true);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Chỉnh sửa loại danh mục: {id} thành công.";
                    return RedirectToAction("Index");
                }
                TempData["MessageError"] = $"Chỉnh sửa loại danh mục: {id} không thành công!";
                return View(model);
            }
            TempData["MessageError"] = $"Chỉnh sửa loại danh mục: {id} không thành công!";
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managerService.CategoryType.DeleteAsync(id, trackChanges: false);
            if (result)
            {
                TempData["MessageSuccess"] = $"Xóa loại danh mục: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Xóa loại danh mục: {id} không thành công!";
            return RedirectToAction("Index");
        }
    }
}
