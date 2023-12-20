using WebAPI.Models;

namespace WebAPI.Persistence.Repositores.Interface
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task Update(Product product);

        Task<Product?> GetProductByIdAsync(long id);

        Task DeleteProduct(Product product);

        Task<IEnumerable<Product>> FindProductsByParamsAsync(string? description = null, long? categoryId = null, bool status = true);

        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
