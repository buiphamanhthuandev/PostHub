using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Contacts
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges);
        Task<Contact> GetByIdAsync(int id, bool trackChanges);
        void UpdateAsync(Contact contact);
        void DeleteAsync(Contact contact);
        Task<int> GetCountAsync(string nameSearch, bool trackChanges);
    }
}
