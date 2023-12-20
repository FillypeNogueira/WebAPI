using WebAPI.Models;
using WebAPI.Persistence.Repositores.Interface;
using WebAPI.Services.Interface;

namespace WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteProduct(Product product)
        {
            await _productRepository.DeleteProduct(product);
        }

        public async Task<IEnumerable<Product>> FindProductsByParamsAsync(string? description = null, long? categoryId = null, bool status = true)
        {
            return await _productRepository.FindProductsByParamsAsync(description, categoryId, status);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product?> GetProductByIdAsync(long id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task Update(long id, Product product)
        {
            Product? productUpdate = await _productRepository.GetProductByIdAsync(id);

            if (productUpdate != null)
            {
                productUpdate.Name = product.Name ?? productUpdate.Name;
                productUpdate.Description = product.Description ?? productUpdate.Description;
                productUpdate.Price = product.Price;
                productUpdate.CategoryId = product.CategoryId;
                productUpdate.Status = product.Status;

                await _productRepository.Update(productUpdate);
            }

        }
    }
}
