using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostHub.Areas.Admin.Services.ManagerService;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class SubscribeController : Controller
    {
        private readonly IManagerService _managerService;

        public SubscribeController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<IActionResult> Index(string nameSearch, int page = 1, int pageSize = 10)
        {
            var result = await _managerService.Subscribe.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges: false);
            return View(result);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managerService.Subscribe.DeleteAsync(id, trackChanges: false);
            if (result)
            {
                TempData["MessageSuccess"] = $"Xóa đăng ký: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Xóa đăng ký: {id} không thành công!";
            return RedirectToAction("Index");
        }
    }
}
