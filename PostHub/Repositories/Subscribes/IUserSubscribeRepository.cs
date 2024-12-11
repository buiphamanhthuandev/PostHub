using PostHub.Models;

namespace PostHub.Repositories.Subscribes
{
    public interface IUserSubscribeRepository
    {
        void CreateAsync(Subscribe subscribe);
    }
}
