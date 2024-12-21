using PostHub.Areas.Admin.ViewModels.HomeViewModels;

namespace PostHub.Areas.Admin.Services.Homes
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetDashbroadAsync(bool trackChange);
    }
}
