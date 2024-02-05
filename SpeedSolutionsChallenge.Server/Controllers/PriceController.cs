using Microsoft.AspNetCore.Mvc;
using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Server.Services.PriceService;

namespace SpeedSolutionsChallenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }


        [HttpPost("create")]
        public async Task<ActionResult<Price>> CreatePrice(Price price)
        {
            try
            {
                var createdPrice = await _priceService.CreatePrice(price);
                return Ok(createdPrice);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el precio: {ex.Message}");
            }
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Price>>> GetAllPrices()
        {
            try
            {
                var prices = await _priceService.GetAllPrices();
                return Ok(prices);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener la lista de precios: {ex.Message}");
            }
        }

        [HttpPost("update/{priceId}")]
        public async Task<ActionResult<Price>> UpdatePrice(int priceId, Price price)
        {
            try
            {
                var updatedPrice = await _priceService.UpdatePrice(priceId, price);
                return Ok(updatedPrice);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el precio: {ex.Message}");
            }
        }
    }
}
