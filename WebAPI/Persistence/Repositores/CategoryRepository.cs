using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence.Context;
using WebAPI.Persistence.Repositores.Interface;

namespace WebAPI.Persistence.Repositores
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly DataAppDbContext _context;

        public CategoryRepository(DataAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> FindCategoriesByParamsAsync(string? name = null, bool status = true)
        {
            IList<Category> categories = new List<Category>();

            List<Category> categoriesOnRepository = await _context.Categories.ToListAsync();
            if (name != null)
                categoriesOnRepository.ForEach(p => { if (p.Name.Contains(name)) categories.Add(p); });


            categoriesOnRepository.ForEach(p => { if (p.Status == status) categories.Add(p); });

            return categories;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(long id)
        {
            Category? category = await _context.Categories.FindAsync(id);

            return category;
        }

        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
