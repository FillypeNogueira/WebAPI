using WebAPI.Models;

namespace WebAPI.Services.Interface
{
    public interface IProductService
    {
        Task AddAsync(Product product);

        Task Update(long id, Product product);

        Task<Product?> GetProductByIdAsync(long id);

        Task DeleteProduct(Product product);

        Task<IEnumerable<Product>> FindProductsByParamsAsync(string? description = null, long? categoryId = null, bool status = true);

        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
