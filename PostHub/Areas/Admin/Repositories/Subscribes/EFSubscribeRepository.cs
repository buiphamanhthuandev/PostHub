using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Subscribes
{
    public class EFSubscribeRepository : GenericRepo<Subscribe>, ISubscribeRepository
    {
        public EFSubscribeRepository(PostHubDbContext context):base(context) { }
        public async Task<List<Subscribe>> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await PageLinkAsync(page, pageSize, trackChanges).Where(s => s.Email.Contains(nameSearch)).ToListAsync();
            }
            return await PageLinkAsync(page, pageSize, trackChanges).ToListAsync();
        }
        public async Task<int> GetCountAsync(string nameSearch, bool trackChanges)
        {
            if (!string.IsNullOrEmpty(nameSearch))
            {
                return await FindAll(trackChanges).Where(s => s.Email.Contains(nameSearch)).CountAsync();
            }
            return await FindAll(trackChanges).CountAsync();
        }
        public void DeleteAsync(Subscribe subscribe)
        {
            Delete(subscribe);
        }
        public async Task<Subscribe> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindById(item => item.Id == id, trackChanges).FirstOrDefaultAsync();
        }
    }
}
