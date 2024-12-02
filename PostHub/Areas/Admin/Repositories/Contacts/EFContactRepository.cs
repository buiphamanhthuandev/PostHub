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
        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstAsync(c => c.Id == id);
        }
        public async Task AddAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            if(result != null)
            {
                _context.Contacts.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> GetCount()
        {
            return await _context.Contacts.CountAsync();
        }
    }
}
