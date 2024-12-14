using PostHub.Areas.Admin.ViewModels.PostViewModels;
using PostHub.Models;
namespace PostHub.Areas.Admin.Services.Posts
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync(bool trackChanges);
        Task<PostViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<bool> CreateAsync(PostFormViewModel model);
        Task<PostFormViewModel> EditAsync(int id, bool trackChanges);
        Task<bool> UpdateAsync(int id, PostFormViewModel model, bool trackChanges);
        Task<bool> UpdateStateAsync(int id, bool trackChanges);
        Task<bool> DeleteAsync(int id, bool trackChanges);
    }
}
