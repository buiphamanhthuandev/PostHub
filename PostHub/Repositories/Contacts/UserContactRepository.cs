using PostHub.Data;
using PostHub.Models;

namespace PostHub.Repositories.Contacts
{
    public class UserContactRepository : IUserContactRepository
    {
        private readonly PostHubDbContext _context;

        public UserContactRepository(PostHubDbContext context)
        {
            _context = context;
        }

        public void CreateAsync(Contact contact) { 
            _context.Contacts.Add(contact);
        }
    }
}
