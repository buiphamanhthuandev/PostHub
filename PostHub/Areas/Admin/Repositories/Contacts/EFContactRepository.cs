using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Contacts
{
    public class EFContactRepository : IContactRepository
    {
        private PostHubDbContext _context;

        public EFContactRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }
    }
}
