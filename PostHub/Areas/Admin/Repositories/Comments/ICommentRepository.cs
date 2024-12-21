using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Comments
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<int> GetCountAsync(string nameSearch, bool trackChanges);
        void DeleteAsync(Comment comment);
        Task<Comment> GetByIdAsync(int id, bool trackChanges);
    }
}
