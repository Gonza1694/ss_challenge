using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Data.Repositories.DispenserRepository
{
    public interface IDispenserRepository
    {
        Task<Dispenser> CreateDispenser(Dispenser dispenser);
        Task<List<Dispenser>> GetAllDispensers();
        Task<Dispenser> GetDispenserById(int dispenserId);
        Task<Dispenser> UpdateDispenser(int dispenserId, Dispenser updatedDispenser);
    }
}
