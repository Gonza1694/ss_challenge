using Microsoft.EntityFrameworkCore;
using SpeedSolutionsChallenge.Data.DBContext;
using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Data.Repositories.PriceRepository
{
    public class PriceRepository : IPriceRepository
    {
        private readonly AppDBContext _dbContext;

        public PriceRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CREATE
        public async Task<Price> CreatePrice(Price price)
        {
            _dbContext.Prices.Add(price);
            await _dbContext.SaveChangesAsync();
            return price;
        }

        //READ
        public async Task<IEnumerable<Price>> GetAllPrices()
        {
            return await _dbContext.Prices.ToListAsync();
        }

        public async Task<Price> GetPriceById(int priceId)
        {
            return await _dbContext.Prices.FindAsync(priceId);
        }

        //UPDATE
        public async Task<Price> UpdatePrice(int priceId, Price price)
        {
            var existingPrice = await _dbContext.Prices.FindAsync(priceId);
            if (existingPrice != null)
            {
                existingPrice.Value = price.Value;
                existingPrice.ProductId = price.ProductId;
                existingPrice.Date = price.Date;

                await _dbContext.SaveChangesAsync();

                return existingPrice;
            }

            return null;
        }
    }
}
