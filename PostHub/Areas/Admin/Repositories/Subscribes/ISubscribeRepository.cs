using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Subscribes
{
    public interface ISubscribeRepository
    {
        Task<IEnumerable<Subscribe>> GetAllAsync();
        Task<int> GetCount();
    }
}
