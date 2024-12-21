using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Comments
{
    public class EFCommentRepository : GenericRepo<Comment>, ICommentRepository
    {
        public EFCommentRepository(PostHubDbContext context):base(context) { }

        public async Task<List<Comment>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await PageLinkAsync(page, pageSize, trackChanges).Where(s => s.Content.Contains(nameSearch)).Include(c => c.User).Include(c => c.Post).ToListAsync();
            }
            return await PageLinkAsync(page, pageSize, trackChanges).Include(c => c.User).Include(c => c.Post).ToListAsync();
        }
        public async Task<int> GetCountAsync(string nameSearch, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await FindAll(trackChanges).Where(s => s.Content.Contains(nameSearch)).CountAsync();
            }
            return await FindAll(trackChanges).CountAsync();
        }
        public void DeleteAsync(Comment comment)
        {
            Delete(comment);
        }
        public async Task<Comment> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindById(item => item.Id == id, trackChanges).FirstOrDefaultAsync();
        }
    }
}
