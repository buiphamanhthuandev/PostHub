using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostHub.Areas.Admin.Instructures;
using PostHub.Areas.Admin.Repositories.Categories;
using PostHub.Areas.Admin.Repositories.Posts;
using PostHub.Areas.Admin.Services.ManagerService;
using PostHub.Areas.Admin.ViewModels;
using PostHub.Areas.Admin.ViewModels.PostViewModels;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class PostController : Controller
    {
        private readonly IManagerService _managerService;

        public PostController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        // GET: Admin/Post
        public async Task<IActionResult> Index(string nameSearch, int page = 1, int pageSize = 10)
        {
            var result = await _managerService.Post.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges: false);
            return View(result);
        }

        // GET: Admin/Post/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _managerService.Category.GetAllAsync(trackChanges: false), "Id", "Name");
            return View();
        }

        // POST: Admin/Post/Create
        [HttpPost]
        public async Task<IActionResult> Create(PostFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _managerService.Post.CreateAsync(model);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Thêm bài viết: {model.Title} thành công.";
                    return RedirectToAction("Index");
                }
                TempData["MessageError"] = $"Thêm bài viết: {model.Title} không thành công!";
                ViewBag.Categories = new SelectList(await _managerService.Category.GetAllAsync(trackChanges: false), "Id", "Name");
                return View(model);
            }
            TempData["MessageError"] = $"Thêm bài viết: {model.Title} không thành công!";
            ViewBag.Categories = new SelectList(await _managerService.Category.GetAllAsync(trackChanges: false), "Id", "Name");
            return View(model);
        }

        // GET: Admin/Post/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _managerService.Post.EditAsync(id, trackChanges: true);
            if(result != null)
            {
                ViewBag.Categories = new SelectList(await _managerService.Category.GetAllAsync(trackChanges: false), "Id", "Name");
                return View(result);
            }
            TempData["MessageError"] = $"Lỗi khi nhấn bài viết: {id} không thành công!";
            return RedirectToAction("Index");
        }

        //// POST: Admin/Post/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormViewModel model)
        {
            if (model.Image == null)
            {
                ModelState.Remove("Image");
            }
            if (ModelState.IsValid)
            {
                var result = await _managerService.Post.UpdateAsync(id, model, trackChanges: true);
                if (result)
                {
                    TempData["MessageSuccess"] = $"Chỉnh sửa bài viết: {model.Title} thành công.";
                    return RedirectToAction("Index");
                }
                TempData["MessageError"] = $"Chỉnh sửa bài viết: {model.Title} không thành công!";
                ViewBag.Categories = new SelectList(await _managerService.Category.GetAllAsync(trackChanges: false), "Id", "Name");
                return View(model);
            }
            TempData["MessageError"] = $"Chỉnh sửa bài viết: {model.Title} không thành công!";
            ViewBag.Categories = new SelectList(await _managerService.Category.GetAllAsync(trackChanges: false), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateState(int id)
        {
            var result = await _managerService.Post.UpdateStateAsync(id, trackChanges: true);
            if (result)
            {
                TempData["MessageSuccess"] = $"Chỉnh sửa trạng thái bài viết: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Chỉnh sửa trạng thái bài viết: {id} không thành công!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managerService.Post.DeleteAsync(id, trackChanges: true);
            if (result)
            {
                TempData["MessageSuccess"] = $"Xóa bài viết: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Xóa bài viết: {id} không thành công!";
            return RedirectToAction("Index");
        }
    }
}
