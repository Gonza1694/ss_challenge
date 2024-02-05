using Microsoft.EntityFrameworkCore;
using SpeedSolutionsChallenge.Data.DBContext;
using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Data.Repositories.HoseRepository
{
    public class HoseRepository : IHoseRepository
    {
        private readonly AppDBContext _dbContext;

        public HoseRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        //CREATE
        public async Task<Hose> CreateHose(Hose hose)
        {
            _dbContext.Hoses.Add(hose);
            await _dbContext.SaveChangesAsync();
            return hose;
        }

        //READ
        public async Task<List<Hose>> GetAllHoses()
        {
            return await _dbContext.Hoses.ToListAsync();
        }

        public async Task<Hose> GetHoseById(int hoseId)
        {
            return await _dbContext.Hoses.FindAsync(hoseId);
        }

        // UPDATE
        public async Task<Hose> UpdateHose(int hoseId, Hose updatedHose)
        {
            var existingHose = await _dbContext.Hoses.FindAsync(hoseId);

            if (existingHose != null)
            {
                existingHose.Name = updatedHose.Name;
                existingHose.ProductId = updatedHose.ProductId;
                existingHose.DispenserId = updatedHose.DispenserId;

                await _dbContext.SaveChangesAsync();

                return existingHose;
            }
            else
            {
                throw new Exception($"No se encontró la manguera con el ID {hoseId}");
            }
        }


        //DELETE
        public async Task<bool> DeleteHose(int hoseId)
        {
            var hoseToDelete = await _dbContext.Hoses.FindAsync(hoseId);

            if (hoseToDelete != null)
            {
                hoseToDelete.DispenserId = null;
                hoseToDelete.IsDeleted = true;
                
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
