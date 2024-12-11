using PostHub.Data;
using PostHub.Models;

namespace PostHub.Repositories.Subscribes
{
    public class UserSubscribeRepository : IUserSubscribeRepository
    {
        private readonly PostHubDbContext _context;

        public UserSubscribeRepository(PostHubDbContext context)
        {
            _context = context;
        }

        public void CreateAsync(Subscribe subscribe)
        {
            _context.Subscribes.Add(subscribe);
        }
    }
}
