using PostHub.Models;

namespace PostHub.Repositories.Posts
{
    public interface IUserPostRepository
    {
        Task<int> GetCountAsync(string nameSearch,int id);
        Task<List<Post>> GetPageLinkAsync(string nameSearch, int id,int Page,int PageSize);
        Task<IEnumerable<Post>> GetPostTopViewAsync(int countTopViews);
        Task<IEnumerable<Post>> GetPostRelateAsync(int countRelatedPost, int categoryId); 
        Task<Post> GetByIdAsync(int id);
        void UpdateAsync(Post post);
    }
}
