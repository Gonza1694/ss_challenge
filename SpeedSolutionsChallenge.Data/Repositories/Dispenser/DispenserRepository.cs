using Microsoft.EntityFrameworkCore;
using SpeedSolutionsChallenge.Data.DBContext;
using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Data.Repositories.DispenserRepository
{
    public class DispenserRepository : IDispenserRepository
    {
        private readonly AppDBContext _dbContext;

        public DispenserRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CREATE
        public async Task<Dispenser> CreateDispenser(Dispenser dispenser)
        {
            _dbContext.Dispensers.Add(dispenser);
            await _dbContext.SaveChangesAsync();
            return dispenser;
        }

        //READ
        public async Task<List<Dispenser>> GetAllDispensers()
        {
            return await _dbContext.Dispensers.ToListAsync();
        }

        public async Task<Dispenser> GetDispenserById(int dispenserId)
        {
            return await _dbContext.Dispensers.FindAsync(dispenserId);
        }

        //UPDATE
        public async Task<Dispenser> UpdateDispenser(int dispenserId, Dispenser updatedDispenser)
        {
            var existingDispenser = await _dbContext.Dispensers.FindAsync(dispenserId);

            if (existingDispenser != null)
            {
                existingDispenser.Name = updatedDispenser.Name;
                existingDispenser.HoseCount = updatedDispenser.HoseCount;

                await _dbContext.SaveChangesAsync();
                return existingDispenser;
            }

            return null;
        }
    }
}
