using WebAPI.Models;
using WebAPI.Persistence.Repositores.Interface;
using WebAPI.Services.Interface;

namespace WebAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task DeleteCategory(Category category)
        {
            await _categoryRepository.DeleteCategory(category);
        }

        public async Task<IEnumerable<Category>> FindCategoriesByParamsAsync(string? name = null, bool status = true)
        {
            return await _categoryRepository.FindCategoriesByParamsAsync(name, status);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(long id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task Update(long id, Category category)
        {
            Category? categoryUpdate = await _categoryRepository.GetCategoryByIdAsync(id);

            if (categoryUpdate != null)
            {
                categoryUpdate.Name = category.Name;
                categoryUpdate.Status = category.Status;
                await _categoryRepository.Update(categoryUpdate);
            }

        }
    }
}
