using PostHub.Areas.Admin.ViewModels.CommentViewModels;
using PostHub.Areas.Admin.ViewModels.SubscribeViewModels;

namespace PostHub.Areas.Admin.Services.Comments
{
    public interface ICommentService
    {
        Task<CommentViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<bool> DeleteAsync(int id, bool trackChanges);
    }
}
