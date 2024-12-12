using PostHub.Models;

namespace PostHub.Repositories.CategoryTypes
{
    public interface IUserCategoryTypeRepository
    {
        Task<List<CategoryType>> GetAllAsync();
    }
}
