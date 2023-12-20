using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence.Context;
using WebAPI.Persistence.Repositores.Interface;

namespace WebAPI.Persistence.Repositores
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly DataAppDbContext _context;
        public ProductRepository(DataAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> FindProductsByParamsAsync(string? description = null, long? categoryId = null, bool status = true)
        {
            IList<Product> products = new List<Product>();

            List<Product> productsOnRepository = await _context.Products.ToListAsync();
            if (description != null)
                productsOnRepository.ForEach(p => { if (p.Description.Contains(description)) products.Add(p); });

            if (categoryId != null)
                productsOnRepository.ForEach(p => { if (p.CategoryId == categoryId) products.Add(p); });


            productsOnRepository.ForEach(p => { if (p.Status == status) products.Add(p); });

            return products;
        }

        public async Task<Product?> GetProductByIdAsync(long id)
        {
            Product? product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync<Product>();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
