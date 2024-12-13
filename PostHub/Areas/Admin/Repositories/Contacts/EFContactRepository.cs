using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Contacts
{
    public class EFContactRepository : GenericRepo<Contact>, IContactRepository
    {

        public EFContactRepository(PostHubDbContext context):base(context) { }
        public async Task<List<Contact>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await PageLinkAsync(page, pageSize, trackChanges).Where(c => c.Content.Contains(nameSearch)).ToListAsync();
            }
            return await PageLinkAsync(page, pageSize, trackChanges).ToListAsync();
        }
        public async Task<Contact> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindById(item => item.Id == id,trackChanges).FirstOrDefaultAsync();
        }
        public void UpdateAsync(Contact contact)
        {
            Update(contact);
        }
        public void DeleteAsync(Contact contact)
        {
            Delete(contact);
        }
        public async Task<int> GetCountAsync(string nameSearch, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await FindAll(trackChanges).Where(c => c.Content.Contains(nameSearch)).CountAsync();
            }
            return await FindAll(trackChanges).CountAsync();
        }
    }
}
