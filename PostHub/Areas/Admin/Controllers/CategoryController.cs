using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostHub.Areas.Admin.Repositories.Categories;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.Services.ManagerService;
using PostHub.Areas.Admin.ViewModels;
using PostHub.Areas.Admin.ViewModels.CategoryViewModels;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly IManagerService _managerService;

        public CategoryController(IManagerService managerService)
        {
            _managerService = managerService;
        }


        // GET: Admin/Category
        public async Task<IActionResult> Index(string nameSearch, int page = 1, int pageSize = 10)
        {
            var result = await _managerService.Category.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges: false);
            return View(result);
        }

        // GET: Admin/Category/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryTypes = new SelectList(await _managerService.CategoryType.GetAllAsync(trackChanges: false), "Id", "Name");
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(CategoryFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _managerService.Category.CreateAsync(model);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Thêm danh mục: {model.Name} thành công.";
                    return RedirectToAction("Index");
                }
                TempData["MessageError"] = $"Thêm danh mục: {model.Name} không thành công!";
                ViewBag.CategoryTypes = new SelectList(await _managerService.CategoryType.GetAllAsync(trackChanges: false), "Id", "Name");
                return View(model);
            }
            TempData["MessageError"] = $"Thêm danh mục: {model.Name} không thành công!";
            ViewBag.CategoryTypes = new SelectList(await _managerService.CategoryType.GetAllAsync(trackChanges: false), "Id", "Name");
            return View(model);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var result = await _managerService.Category.EditAsync(id, trackChanges: true);
            if(result == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.CategoryTypes = new SelectList(await _managerService.CategoryType.GetAllAsync(trackChanges: false), "Id", "Name");
            return View(result);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _managerService.Category.UpdateAsync(id, model, trackChanges: true);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Chỉnh sửa danh mục: {model.Name} thành công.";
                    return RedirectToAction("Index");
                }
                TempData["MessageError"] = $"Chỉnh sửa danh mục: {model.Name} không thành công!";
                ViewBag.CategoryTypes = new SelectList(await _managerService.CategoryType.GetAllAsync(trackChanges: false), "Id", "Name");
                return View(model);
            }
            TempData["MessageError"] = $"Chỉnh sửa danh mục: {model.Name} không thành công!";
            ViewBag.CategoryTypes = new SelectList(await _managerService.CategoryType.GetAllAsync(trackChanges: false), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managerService.Category.DeleteAsync(id, trackChanges: false);
            if (result)
            {
                TempData["MessageSuccess"] = $"Xóa danh mục: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Xóa danh muc: {id} không thành công!";
            return RedirectToAction("Index");
        }
    }
}
