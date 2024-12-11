using PostHub.Data;
using PostHub.Models;

namespace PostHub.Repositories.Comments
{
    public class UserCommentRepository : IUserCommentRepository
    {
        private readonly PostHubDbContext _context;

        public UserCommentRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public void CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
        }
    }
}
