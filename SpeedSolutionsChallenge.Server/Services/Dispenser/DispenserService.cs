using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Data.Repositories.DispenserRepository;

namespace SpeedSolutionsChallenge.Server.Services.DispenserService
{
    public class DispenserService : IDispenserService
    {
        private readonly IDispenserRepository _dispenserRepository;

        public DispenserService(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }

        public async Task<Dispenser> CreateDispenser(Dispenser dispenser)
        {
            return await _dispenserRepository.CreateDispenser(dispenser);
        }

        public async Task<List<Dispenser>> GetAllDispensers()
        {
            return await _dispenserRepository.GetAllDispensers();
        }

        public async Task<Dispenser> GetDispenserById(int dispenserId)
        {
            return await _dispenserRepository.GetDispenserById(dispenserId);
        }

        public async Task<Dispenser> UpdateDispenser(int dispenserId, Dispenser updatedDispenser)
        {
            return await _dispenserRepository.UpdateDispenser(dispenserId, updatedDispenser);
        }
    }
}
