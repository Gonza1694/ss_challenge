using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Server.Services.ProductService;

namespace SpeedSolutionsChallenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            try
            {
                var createProduct = await _productService.CreateProduct(product);
                return Ok(createProduct);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al añadir el producto: {ex.Message}");
            }
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Error al obtener los productos: {ex.Message}");
            }
        }

        [HttpGet("getById/{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            try
            {
                var product = await _productService.GetProductById(productId);

               return product != null 
                    ? Ok(product) 
                    : NotFound($"Producto con el ID {productId} no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener el producto: {ex.Message}");
            }
        }

        [HttpPut("update/{productId}")]
        public async Task<ActionResult<Product>> UpdateProduct(int productId, [FromBody] Product updatedProduct)
        {
            var product = await _productService.UpdateProduct(productId, updatedProduct);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpDelete("delete/{productId}")]
        public async Task<ActionResult<Product>> DeleteProduct(int productId)
        {
            try
            {
                var isDeleted = await _productService.DeleteProduct(productId);

                if (isDeleted)
                    return Ok("Producto eliminado correctamente.");
                else
                    return NotFound($"Producto con el ID {productId} no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al borrar el producto: {ex.Message}");
            }
        }

    }
}
