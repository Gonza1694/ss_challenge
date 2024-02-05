using Microsoft.AspNetCore.Mvc;
using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Server.Services.DispenserService;

namespace SpeedSolutionsChallenge.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispenserController : ControllerBase
    {
        private readonly IDispenserService _dispenserService;

        public DispenserController(IDispenserService dispenserService)
        {
            _dispenserService = dispenserService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Dispenser>> CreateDispenser(Dispenser dispenser)
        {
            var createdDispenser = await _dispenserService.CreateDispenser(dispenser);
            return Ok(createdDispenser);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Dispenser>>> GetAllDispensers()
        {
            var allDispensers = await _dispenserService.GetAllDispensers();
            return Ok(allDispensers);
        }

        [HttpGet("getById/{dispenserId}")]
        public async Task<ActionResult<Dispenser>> GetDispenserById(int dispenserId)
        {
            var dispenser = await _dispenserService.GetDispenserById(dispenserId);

            if (dispenser == null)
                return NotFound($"Dispensador ID {dispenserId} no encontrado");

            return Ok(dispenser);
        }

        [HttpPut("update/{dispenserId}")]
        public async Task<ActionResult<Dispenser>> UpdateDispenser(int dispenserId, Dispenser updatedDispenser)
        {
            var updatedDispenserResult = await _dispenserService.UpdateDispenser(dispenserId, updatedDispenser);

            if (updatedDispenserResult == null)
                return NotFound($"Dispensador ID {dispenserId} no encontrado");

            return Ok(updatedDispenserResult);
        }
    }
}
