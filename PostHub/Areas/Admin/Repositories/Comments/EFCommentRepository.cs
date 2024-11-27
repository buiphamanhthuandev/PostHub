using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Comments
{
    public class EFCommentRepository : ICommentRepository
    {
        private PostHubDbContext _context;

        public EFCommentRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
