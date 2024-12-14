using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Posts
{
    public class EFPostRepository : GenericRepo<Post>,IPostRepository
    {
        public EFPostRepository(PostHubDbContext context):base(context) { } 

        public async Task<List<Post>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Where(p => p.State == 1).ToListAsync();
        }
        public async Task<List<Post>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await PageLinkAsync(page, pageSize, trackChanges).Where(p => p.Title.Contains(nameSearch)).Include(c => c.Category).ToListAsync();
            }
            return await PageLinkAsync(page, pageSize, trackChanges).Include(c => c.Category).ToListAsync();
        }
        public async Task<Post> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindById(item => item.Id == id, trackChanges).Include(c => c.Category).FirstOrDefaultAsync();
        }

        public void CreateAsync(Post post)
        {
            Create(post);
        }
        public void UpdateAsync(Post post)
        {
            Update(post);
        }
        public void DeleteAsync(Post post)
        {
            Delete(post);
        }
        public async Task<int> GetCountAsync(string nameSearch, bool trackChange)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await FindAll(trackChange).Where(p => p.Title.Contains(nameSearch)).CountAsync();
            }
            return await FindAll(trackChange).CountAsync();
        }
    }
}
