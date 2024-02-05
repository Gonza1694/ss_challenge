using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Data.Repositories.HoseRepository;

namespace SpeedSolutionsChallenge.Server.Services.HoseService
{
    public class HoseService : IHoseService
    {
        private readonly IHoseRepository _hoseRepository;

        public HoseService(IHoseRepository hoseRepository)
        {
            _hoseRepository = hoseRepository;
        }

        public async Task<Hose> CreateHose(Hose hose)
        {
            return await _hoseRepository.CreateHose(hose);
        }

        public async Task<List<Hose>> GetAllHoses()
        {
            return await _hoseRepository.GetAllHoses();
        }

        public async Task<Hose> GetHoseById(int hoseId)
        {
            return await _hoseRepository.GetHoseById(hoseId);
        }

        public async Task<Hose> UpdateHose(int hoseId, Hose updatedHose)
        {
            return await _hoseRepository.UpdateHose(hoseId , updatedHose);
        }

        public async Task<bool> DeleteHose(int hoseId)
        {
            return await _hoseRepository.DeleteHose(hoseId);
        }
    }
}
