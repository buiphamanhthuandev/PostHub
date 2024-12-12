using PostHub.Models;

namespace PostHub.Repositories.Contacts
{
    public interface IUserContactRepository
    {
        void CreateAsync(Contact contact);
    }
}
