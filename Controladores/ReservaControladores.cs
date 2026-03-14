using Microsoft.AspNetCore.Mvc;
using ReservaGol.Modelos;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaControladores : ControllerBase
    {
        private readonly IReservaRepositorio _reservaRepositorio;

        public ReservaControladores(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        [HttpGet("ObtenerReservas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllReserva()
        {
            try
            {
                var reservas = await _reservaRepositorio.ObtenerReserva();
                if (reservas == null || !reservas.Any())
                    return NotFound("No se encontraron reservas.");
                return Ok(reservas);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener reservas."); }
        }

        [HttpGet("ObtenerReservaPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReservaById(Guid id)
        {
            try
            {
                var reserva = await _reservaRepositorio.ObtenerReserva(id);
                if (reserva == null)
                    return NotFound("Reserva no encontrada.");
                return Ok(reserva);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la reserva."); }
        }

        [HttpPost("CrearReserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearReserva([FromBody] Reserva reserva)
        {
            try
            {
                var resultado = await _reservaRepositorio.CrearReserva(reserva);
                if (!resultado)
                    return BadRequest("No se pudo crear la reserva.");
                return Ok("Reserva creada correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la reserva."); }
        }

        [HttpDelete("EliminarReserva/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarReserva(Guid id)
        {
            try
            {
                var resultado = await _reservaRepositorio.EliminarReserva(id);
                if (!resultado)
                    return BadRequest("No se pudo eliminar la reserva.");
                return Ok("Reserva eliminada correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la reserva."); }
        }

        [HttpPut("ActualizarReserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarReserva([FromBody] Reserva reserva)
        {
            try
            {
                var resultado = await _reservaRepositorio.ActualizarReserva(reserva);
                if (!resultado)
                    return BadRequest("No se pudo actualizar la reserva.");
                return Ok("Reserva actualizada correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la reserva."); }
        }
    }
}
