using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Posts
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllAsync(bool trackChanges);
        Task<List<Post>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<Post> GetByIdAsync(int id, bool trackChanges);
        void CreateAsync(Post post);
        void UpdateAsync(Post post);
        void DeleteAsync(Post post);
        Task<int> GetCountAsync(string nameSearch, bool trackChange);
    }
}
