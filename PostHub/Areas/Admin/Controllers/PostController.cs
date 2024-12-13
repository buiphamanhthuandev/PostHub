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
using PostHub.Areas.Admin.ViewModels;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class PostController : Controller
    {
        private readonly IPostRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private IWebHostEnvironment _webHostEnvironment;

        public PostController(IPostRepository repository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //// GET: Admin/Post
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _repository.GetAllAsync());
        //}

        //// GET: Admin/Post/Create
        //public async Task<IActionResult> Create()
        //{
        //    //ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
        //    return View();
        //}

        //// POST: Admin/Post/Create
        //[HttpPost]
        //public async Task<IActionResult> Create(PostViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string fileName = string.Empty;
        //        if(model.Image != null && model.Image.Length > 0)
        //        {
        //            var fileImage = Path.GetFileNameWithoutExtension(model.Image.FileName);
        //            var fileExtension = Path.GetExtension(model.Image.FileName);
        //            fileName = $"{fileImage}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{fileExtension}";
        //            using(var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName), FileMode.Create))
        //            {
        //                await model.Image.CopyToAsync(stream);
        //            }
        //        }
        //        var post = new Post
        //        {
        //            Title = model.Title,
        //            Content = model.Content,
        //            CategoryId = model.CategoryId,
        //            Image = fileName,
        //            Slug = SlugHelper.GenerateSlug(model.Title),
        //        };
        //        await _repository.AddAsync(post);
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
        //    return View(model);
        //}

        //// GET: Admin/Post/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var result = await _repository.GetByIdAsync(id);
        //    if(result == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var post = new PostViewModel
        //    {
        //        Title = result.Title,
        //        Content = result.Content,
        //        CategoryId = result.CategoryId
        //    };
        //    //ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
        //    return View(post);
        //}

        //// POST: Admin/Post/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, PostViewModel model)
        //{
        //    if (model.Image == null)
        //    {
        //        ModelState.Remove("Image");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var post = await _repository.GetByIdAsync(id);
        //        if (post == null)
        //        {
        //            //ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
        //            return View(model);
        //        }
        //        post.Title = model.Title;
        //        post.Content = model.Content;
        //        post.CategoryId = model.CategoryId;
        //        post.Slug = SlugHelper.GenerateSlug(model.Title);

        //        if (model.Image != null && model.Image.Length > 0)
        //        {
        //            var fileImage = Path.GetFileNameWithoutExtension(model.Image.FileName);
        //            var fileExtension = Path.GetExtension(model.Image.FileName);
        //            var fileName = $"{fileImage}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{fileExtension}";
        //            using(var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath,"images",fileName), FileMode.Create))
        //            {
        //                await model.Image.CopyToAsync(stream);
        //            }
        //            post.Image = fileName;
        //        }
               
        //        await _repository.UpdateAsync(post);
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
        //    return View(model);
        //}


        //// POST: Admin/Post/Delete/5
        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var post = await _repository.GetByIdAsync(id);
        //    if (post != null)
        //    {
        //        post.State = 0;
        //        await _repository.UpdateAsync(post);
        //    }
        //    return RedirectToAction("Index");
        //}

        
    }
}
