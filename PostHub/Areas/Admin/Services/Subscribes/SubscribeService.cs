using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.ViewModels.SubscribeViewModels;
using PostHub.TagHelpers;
namespace PostHub.Areas.Admin.Services.Subscribes
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IManagerRepositoy _managerRepositoy;

        public SubscribeService(IManagerRepositoy managerRepositoy)
        {
            _managerRepositoy = managerRepositoy;
        }

        public async Task<SubscribeViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            var resultPages = await _managerRepositoy.Subscribe.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges);
            var resultCounts = await _managerRepositoy.Subscribe.GetCountAsync(nameSearch, trackChanges);
            var result = new SubscribeViewModel
            {
                Subscribes = resultPages,
                NameSearch = nameSearch,
                PagingInfo = new PagingInfo
                {
                    TotalItems = resultCounts,
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                }
            };
            return result;
        }
        public async Task<bool> DeleteAsync(int id, bool trackChanges)
        {
            try
            {
                var subscribe = await _managerRepositoy.Subscribe.GetByIdAsync(id, trackChanges);
                if (subscribe != null)
                {
                    _managerRepositoy.Subscribe.DeleteAsync(subscribe);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
