using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Contacts
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
    }
}
