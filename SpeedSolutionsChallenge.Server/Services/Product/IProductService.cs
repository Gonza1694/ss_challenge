using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<Product> UpdateProduct(int productId, Product updatedProduct);
        Task<bool> DeleteProduct(int productId);
    }
}