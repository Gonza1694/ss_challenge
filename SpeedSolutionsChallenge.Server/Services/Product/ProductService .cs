using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Data.Repositories.ProductRepository;

namespace SpeedSolutionsChallenge.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productRepository.CreateProduct(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        public async Task<Product> UpdateProduct(int productId, Product updatedProduct)
        {
            return await _productRepository.UpdateProduct(productId, updatedProduct);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productRepository.DeleteProduct(productId);
        }
    }
}
