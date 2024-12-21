using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.Services.ManagerService;
using PostHub.Areas.Admin.ViewModels.CommentViewModels;
using PostHub.Areas.Admin.ViewModels.SubscribeViewModels;
using PostHub.TagHelpers;

namespace PostHub.Areas.Admin.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IManagerRepositoy _managerRepositoy;

        public CommentService(IManagerRepositoy managerRepositoy)
        {
            _managerRepositoy = managerRepositoy;
        }

        public async Task<CommentViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            var resultPages = await _managerRepositoy.Comment.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges);
            var resultCounts = await _managerRepositoy.Comment.GetCountAsync(nameSearch, trackChanges);
            var result = new CommentViewModel
            {
                Comments = resultPages,
                NameSearch = nameSearch,
                PagingInfo = new PagingInfo
                {
                    TotalItems = resultCounts,
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                }
            };
            return result;
        }
        public async Task<bool> DeleteAsync(int id, bool trackChanges)
        {
            try
            {
                var comment = await _managerRepositoy.Comment.GetByIdAsync(id, trackChanges);
                if (comment != null)
                {
                    _managerRepositoy.Comment.DeleteAsync(comment);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
