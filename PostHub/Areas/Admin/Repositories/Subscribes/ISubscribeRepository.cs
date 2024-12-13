using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Subscribes
{
    public interface ISubscribeRepository
    {
        Task<List<Subscribe>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<int> GetCountAsync(string nameSearch, bool trackChanges);
        void DeleteAsync(Subscribe subscribe);
        Task<Subscribe> GetByIdAsync(int id, bool trackChanges);
    }
}
