using Microsoft.AspNetCore.Mvc;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaControlador : ControllerBase
    {
        private readonly ICanchaRepositorio _canchaRepositorio;

        public CanchaControlador(ICanchaRepositorio canchaRepositorio)
        {
            _canchaRepositorio = canchaRepositorio;
        }

        [HttpGet("ObtenerCancha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCancha()
        {
            try
            {
                var canchas = await _canchaRepositorio.ObtenerCancha();
                if (canchas == null || !canchas.Any())
                    return NotFound("No se encontraron canchas.");
                return Ok(canchas);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener canchas."); }
        }

        [HttpGet("ObtenerCanchaPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCanchaById(Guid id)
        {
            try
            {
                var cancha = await _canchaRepositorio.ObtenerCancha(id);
                if (cancha == null)
                    return NotFound("Cancha no encontrada.");
                return Ok(cancha);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la cancha."); }
        }
    }
}
