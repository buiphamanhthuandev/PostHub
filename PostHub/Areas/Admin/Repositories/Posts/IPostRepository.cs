using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Posts
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(int id);
        Task<int> GetCount();
    }
}
