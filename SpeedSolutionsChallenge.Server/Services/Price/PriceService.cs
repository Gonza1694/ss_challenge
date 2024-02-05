using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Data.Repositories.PriceRepository;

namespace SpeedSolutionsChallenge.Server.Services.PriceService
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _priceRepository;

        public PriceService(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<Price> CreatePrice(Price price)
        {
            return await _priceRepository.CreatePrice(price);
        }

        public async Task<List<Price>> GetAllPrices()
        {
            return (List<Price>)await _priceRepository.GetAllPrices();
        }

        public async Task<Price> UpdatePrice(int priceId, Price updatedPrice)
        {
            return await _priceRepository.UpdatePrice(priceId, updatedPrice);
        }
    }
}