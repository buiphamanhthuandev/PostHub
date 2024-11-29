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
using PostHub.Areas.Admin.ViewModels;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryTypeRepository _categoryTypeRepository;

        public CategoryController(ICategoryRepository repository, ICategoryTypeRepository categoryTypeRepository)
        {
            _repository = repository;
            _categoryTypeRepository = categoryTypeRepository;
        }


        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        // GET: Admin/Category/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryTypes = new SelectList(await _categoryTypeRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    CategoryTypeId = model.CategoryTypeId,
                };
                await _repository.AddAsync(category);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryTypes = new SelectList(await _categoryTypeRepository.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            var category = new CategoryViewModel
            {
                Name = result.Name,
                CategoryTypeId = result.CategoryTypeId
            };
            ViewBag.CategoryTypes = new SelectList(await _categoryTypeRepository.GetAllAsync(), "Id", "Name");
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await _repository.GetByIdAsync(id);
                if (category == null)
                {
                    return View(model);
                }
                category.Name = model.Name;
                category.CategoryTypeId = model.CategoryTypeId;
                await _repository.UpdateAsync(category);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryTypes = new SelectList(await _categoryTypeRepository.GetAllAsync(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                category.State = 0;
                await _repository.UpdateAsync(category);
            }
            return RedirectToAction("Index");
        }
    }
}
