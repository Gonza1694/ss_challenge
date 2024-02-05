using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Server.Services.HoseService
{
    public interface IHoseService
    {
        Task<Hose> CreateHose(Hose hose);
        Task<List<Hose>> GetAllHoses();
        Task<Hose> GetHoseById(int hoseId);
        Task<Hose> UpdateHose(int hoseId, Hose updatedHose);
        Task<bool> DeleteHose(int hoseId);
    }
}
