using PostHub.Models;

namespace PostHub.Repositories.Posts
{
    public interface IUserPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetPageLinkAsync(int Page,int PageSize);
        Task<IEnumerable<Post>> GetPostTopViewAsync(int countTopViews);
        Task<Post> GetByIdAsync(int id);
    }
}
