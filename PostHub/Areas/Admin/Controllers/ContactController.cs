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
using PostHub.Areas.Admin.ViewModels;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class ContactController : Controller
    {
        
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }


        // GET: Admin/Contact
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        // POST: Admin/Contact/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact != null)
            {
                contact.StateRes = contact.StateRes == 1 ? 0 : 1;
                await _repository.UpdateAsync(contact);
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/Contact/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact != null)
            {
                await _repository.DeleteAsync(id);
            }
            return RedirectToAction("Index");
        }

        
    }
}
