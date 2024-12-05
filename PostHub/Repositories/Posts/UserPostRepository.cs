using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Repositories.Posts
{
    public class UserPostRepository : IUserPostRepository
    {
        private readonly PostHubDbContext _context;

        public UserPostRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var posts = await _context.Posts.Where(p => p.State == 1).ToListAsync();
            return posts;
        }
        public async Task<IEnumerable<Post>> GetPageLinkAsync(int Page, int PageSize)
        {
            var posts = await _context.Posts
                .Where(p => p.State == 1)
                .Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            return posts;
        }
        public async Task<IEnumerable<Post>> GetPostTopViewAsync(int countTopViews)
        {
            var postTopViews = await _context.Posts.Where(p =>p.State == 1)
                .OrderByDescending(p => p.View)
                .Take(countTopViews)
                .ToListAsync();
            return postTopViews;
        }
        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await _context.Posts.Where(p => p.Id == id && p.State == 1).FirstOrDefaultAsync();
            return post;
        }
    }
}
