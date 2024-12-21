using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PostHub.Areas.Admin.Services.ManagerService;

namespace PostHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class CommentController : Controller
    {
        private readonly IManagerService _managerService;

        public CommentController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<IActionResult> Index(string nameSearch, int page = 1, int pageSize = 10)
        {
            var result = await _managerService.Comment.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges: false);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managerService.Comment.DeleteAsync(id, trackChanges: false);
            if (result)
            {
                TempData["MessageSuccess"] = $"Xóa bình luận: {id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["MessageError"] = $"Xóa bình luận: {id} không thành công!";
            return RedirectToAction("Index");
        }
    }
}
