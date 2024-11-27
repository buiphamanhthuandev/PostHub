using Microsoft.EntityFrameworkCore;
using PostHub.Data;
using PostHub.Models;

namespace PostHub.Areas.Admin.Repositories.Subscribes
{
    public class EFSubscribeRepository : ISubscribeRepository
    {
        private PostHubDbContext _context;

        public EFSubscribeRepository(PostHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subscribe>> GetAllAsync()
        {
            return await _context.Subscribes.ToListAsync();
        }
    }
}
