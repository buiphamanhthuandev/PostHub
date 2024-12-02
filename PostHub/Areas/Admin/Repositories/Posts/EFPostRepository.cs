using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Posts
{
    public class EFPostRepository : IPostRepository
    {
        private PostHubDbContext _context;

        public EFPostRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.Include(p => p.Category).Where(p => p.State == 1).ToListAsync();
        }
        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.FirstAsync(c => c.Id == id);
        }

        public async Task AddAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> GetCount()
        {
            return await _context.Posts.Where(c => c.State == 1).CountAsync();
        }
    }
}
