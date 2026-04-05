using Microsoft.AspNetCore.Mvc;
using ReservaGol.Modelos;
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
        [HttpPost("CrearCancha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearCancha([FromBody] Cancha cancha)
        {
            try
            {
                var resultado = await _canchaRepositorio.CrearCancha(cancha);
                if (!resultado)
                    return BadRequest("No se pudo crear la cancha.");
                return Ok("Cancha creada correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la cancha."); }
        }
        [HttpDelete("EliminarCancha/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarCancha(Guid id)
        {
            try
            {
                var resultado = await _canchaRepositorio.EliminarCancha(id);
                if (!resultado) return NotFound("Cancha no encontrada.");
                return Ok("Cancha eliminada correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la cancha."); }
        }

        [HttpGet("Estadisticas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EstadisticasCancha(Guid id)
        {
            try
            {
                var cancha = await _canchaRepositorio.ObtenerCancha(id);
                if (cancha == null) return NotFound("Cancha no encontrada.");
                return Ok(new {
                    nombre = cancha.Nombre,
                    precioHora = cancha.Precio_Hora,
                    totalReservas = 0,
                    horariosOcupados = new[] { "09:00", "14:00", "18:00" }
                });
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener estadísticas."); }
        }
    }
}
