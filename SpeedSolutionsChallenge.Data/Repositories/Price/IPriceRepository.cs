using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Data.Repositories.PriceRepository
{
    public interface IPriceRepository
    {
        Task<IEnumerable<Price>> GetAllPrices();
        Task<Price> GetPriceById(int priceId);
        Task<Price> CreatePrice(Price price);
        Task<Price> UpdatePrice(int priceId, Price price);
    }
}
