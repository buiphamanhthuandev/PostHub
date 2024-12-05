using PostHub.Models;

namespace PostHub.Repositories.Categories
{
    public interface IUserCategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);


    }
}
