using WebAPI.Models;

namespace WebAPI.Services.Interface
{
    public interface ICategoryService
    {
        Task AddAsync(Category category);

        Task Update(long id, Category category);

        Task<Category?> GetCategoryByIdAsync(long id);

        Task DeleteCategory(Category category);

        Task<IEnumerable<Category>> FindCategoriesByParamsAsync(string? name = null, bool status = true);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
