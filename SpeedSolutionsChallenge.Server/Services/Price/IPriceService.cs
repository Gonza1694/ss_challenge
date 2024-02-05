using SpeedSolutionsChallenge.Data.Models;


namespace SpeedSolutionsChallenge.Server.Services.PriceService
{
    public interface IPriceService
    {
        Task<Price> CreatePrice(Price price);
        Task<List<Price>> GetAllPrices();
        Task<Price> UpdatePrice(int priceId, Price updatedPrice);
    }
}