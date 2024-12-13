using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostHub.Areas.Admin.Repositories.Contacts;
using PostHub.Areas.Admin.Services.ManagerService;
using PostHub.Areas.Admin.ViewModels;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class ContactController : Controller
    {

        private readonly IManagerService _managerService;

        public ContactController(IManagerService managerService)
        {
            _managerService = managerService;
        }


        // GET: Admin/Contact
        public async Task<IActionResult> Index(string nameSearch, int page = 1, int pageSize = 10)
        {
            var result = await _managerService.Contact.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges: false);
            return View(result);
        }

        // POST: Admin/Contact/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _managerService.Contact.EditStateAsync(id, trackChanges: true);
            if (result)
            {
                TempData["MessageSuccess"] = $"Chỉnh sửa trạng thái liên hệ: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Chỉnh sửa trạng thái liên hệ: {id} không thành công!";
            return RedirectToAction("Index");
        }

        // POST: Admin/Contact/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managerService.Contact.DeleteAsync(id, trackChanges: false);
            if (result)
            {
                TempData["MessageSuccess"] = $"Xóa liên hệ: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Xóa liên hệ: {id} không thành công!";
            return RedirectToAction("Index");
        }


    }
}
