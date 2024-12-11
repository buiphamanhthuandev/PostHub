using PostHub.Models;

namespace PostHub.Repositories.Comments
{
    public interface IUserCommentRepository
    {
        void CreateAsync(Comment comment);
    }
}
