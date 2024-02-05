using Microsoft.AspNetCore.Mvc;
using SpeedSolutionsChallenge.Data.Models;
using SpeedSolutionsChallenge.Server.Services.HoseService;

namespace SpeedSolutionsChallenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoseController : ControllerBase
    {
        private readonly IHoseService _hoseService;

        public HoseController(IHoseService hoseService)
        {
            _hoseService = hoseService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Hose>> CreateHose([FromBody] Hose hose)
        {
            try
            {
                var createdHose = await _hoseService.CreateHose(hose);
                return Ok(createdHose);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al añadir la manguera: {ex.Message}");
            }
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Hose>> GetAllHoses()
        {
            try
            {
                var hoses = await _hoseService.GetAllHoses();
                return Ok(hoses);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener las mangueras: {ex.Message}");
            }
        }

        [HttpGet("getById/{hoseId}")]
        public async Task<ActionResult<Hose>> GetHoseById(int hoseId)
        {
            try
            {
                var hose = await _hoseService.GetHoseById(hoseId);

                return hose != null
                    ? Ok(hose)
                    : NotFound($"Manguera con el ID {hoseId} no encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener la manguera: {ex.Message}");
            }
        }

        [HttpPut("update/{hoseId}")]
        public async Task<ActionResult<Hose>> UpdateHose(int hoseId, [FromBody] Hose updatedHose)
        {
            try
            {
                var updatedHoseResult = await _hoseService.UpdateHose(hoseId, updatedHose);
                return Ok(updatedHoseResult);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error actualizando la manguera: {ex.Message}");
            }
        }


        [HttpDelete("delete/{hoseId}")]
        public async Task<ActionResult<Hose>> DeleteHose(int hoseId)
        {
            try
            {
                var isDeleted = await _hoseService.DeleteHose(hoseId);

                if (isDeleted)
                    return Ok("Manguera eliminada correctamente.");
                else
                    return NotFound($"Manguera con el ID {hoseId} no encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al borrar la manguera: {ex.Message}");
            }
        }
    }
}
