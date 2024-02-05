using Microsoft.EntityFrameworkCore;
using SpeedSolutionsChallenge.Data.DBContext;
using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Data.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _dbContext;

        public ProductRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        //CREATE
        public async Task<Product> CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        //READ
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _dbContext.Products.FindAsync(productId);
        }

        //UPDATE
        public async Task<Product> UpdateProduct(int productId, Product updatedProduct)
        {
            var existingProduct = await _dbContext.Products.FindAsync(productId);

            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.ProductType = updatedProduct.ProductType;
                existingProduct.Unit = updatedProduct.Unit;

                await _dbContext.SaveChangesAsync();
            }

            return existingProduct;
        }

        //DELETE
        public async Task<bool> DeleteProduct(int productId)
        {
            var productToDelete = await _dbContext.Products.FindAsync(productId);

            if (productToDelete != null)
            {
                productToDelete.IsDeleted = true;
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

    }
}
