using PostHub.Areas.Admin.ViewModels.ContactViewModels;

namespace PostHub.Areas.Admin.Services.Contacts
{
    public interface IContactService
    {
        Task<ContactViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<bool> EditStateAsync(int id, bool trackChanges);
        Task<bool> DeleteAsync(int id, bool trackChanges);

    }
}
