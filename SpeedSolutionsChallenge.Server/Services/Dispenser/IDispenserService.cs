using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Server.Services.DispenserService
{
    public interface IDispenserService
    {
        Task<Dispenser> CreateDispenser(Dispenser dispenser);
        Task<List<Dispenser>> GetAllDispensers();
        Task<Dispenser> GetDispenserById(int dispenserId);
        Task<Dispenser> UpdateDispenser(int dispenserId, Dispenser updatedDispenser);
    }
}
