using PostHub.Areas.Admin.ViewModels.SubscribeViewModels;

namespace PostHub.Areas.Admin.Services.Subscribes
{
    public interface ISubscribeService
    {
        Task<SubscribeViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<bool> DeleteAsync(int id, bool trackChanges);
    }
}
