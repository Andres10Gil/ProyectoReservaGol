using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaControladores : ControllerBase
    {
        private readonly IReservaRepositorio _reservaRepositorio;//Variable global  es accesible desde cualquuier pRTE DEL codigo


        //crear dependencias con constructor personalizado
        public ReservaControladores(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;

        }
        [HttpGet("ObtenerReserva")] //Obtener
        //Respuestas del metodo
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que el método puede devolver un código de estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que el método puede devolver un código de estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que el método puede devolver un código de estado 500 Internal Server Error
        public async Task<IActionResult> GetAllReserva()
        {
            try//Es un bloque donde colocas el código que quieres ejecutar pero que podría generar un error (excepción).
            {
                var Reserva = await _reservaRepositorio.ObtenerReserva();
                if (Reserva == null || !Reserva.Any())// verifica si los usuarios son nulos o esta vacia
                {
                    return NotFound("No se encontro Reserva");
                }


                return Ok(Reserva);
            }
            catch (Exception ex) //Es el bloque que captura el error si ocurre dentro del try, evitando que la aplicación se detenga o se cierre.
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener Reserva ");// por que se usa una coma preguntar al profe

            }

        }
        [HttpGet("ObtenerReservaPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReservaById(int id) // modificar a guid el int
        {
            try
            {
                var Reserva = await _reservaRepositorio.ObtenerReserva(id);

                if (Reserva == null)
                {
                    return NotFound(" Se Encontro reserva ");
                }
                return Ok(Reserva);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Reserva");
            }

            }
        

        [HttpPost("CrearReserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CrearReserva([FromBody] Reserva reserva)
        {
            try
            {
                var resultados = await _reservaRepositorio.CrearReserva(reserva);

                if (!resultados)
                {
                    return BadRequest("No se puede crear Resrva");
                    ;
                }
                return Ok("Reserva creado correctamente");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el Reserva");
            }

        }

        [HttpPost("EliminarReserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> EliminarReserva(int id)
        {
            try
            {
                var resultado = await _reservaRepositorio.EliminarReserva(id);
                if (!resultado)
                {
                    return BadRequest("No se puede eliminar ");

                }
                return Ok(" Reserva eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al elimnar la reserva");
            }
        }
        [HttpPost("ActualizarReserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ActualizarReserva([FromBody] Reserva reserva)
        {
            try
            {
                var resultados = await _reservaRepositorio.ActualizarReserva(reserva);

                if (!resultados)
                {
                    return BadRequest("No se puede Actualizar Reserva");
                    ;
                }
                return Ok("Reserva actulizada correctamente ");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "al actualizar la Reserva ");
            }

        }
    }
}

