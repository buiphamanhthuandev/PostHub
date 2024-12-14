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
        public async Task<int> GetCountAsync(string nameSearch, int id)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await _context.Posts.Where(p => p.State == 1 && p.Title.Contains(nameSearch)).CountAsync();
            }
            if(id != 0)
            {
                return await _context.Posts.Where(p => p.State == 1 && p.CategoryId == id).CountAsync();
            }
            return await _context.Posts.Where(p => p.State == 1).CountAsync();
           
        }
        public async Task<List<Post>> GetPageLinkAsync(string nameSearch, int id, int Page, int PageSize)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await _context.Posts.Where(p => p.State == 1 && p.Title.Contains(nameSearch))
                    .Skip((Page - 1)  * PageSize)
                    .Take(PageSize).ToListAsync();
            }
            if (id != 0)
            {
                return await _context.Posts.Where(p => p.State == 1 && p.CategoryId == id)
                    .Skip((Page - 1) * PageSize).
                    Take(PageSize).
                    ToListAsync();
            }
            return await _context.Posts
                .Where(p => p.State == 1)
                .Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            
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
            var post = await _context.Posts.Where(p => p.Id == id && p.State == 1).Include(p => p.Comments).ThenInclude(c => c.User).FirstOrDefaultAsync();
            return post;
        }
        public async Task<IEnumerable<Post>> GetPostRelateAsync(int countRelatedPost, int categoryId)
        {
            return await _context.Posts.Where(p => p.State == 1 && p.CategoryId == categoryId)
                .Take(countRelatedPost)
                .ToListAsync();
        }
        public void UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}
