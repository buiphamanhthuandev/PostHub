using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Comments
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
    }
}
