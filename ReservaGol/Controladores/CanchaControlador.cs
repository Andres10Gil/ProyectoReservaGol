using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaGol.Repositorios;
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
            _canchaRepositorio = _canchaRepositorio;

        }
        [HttpGet("ObtenerCancha")] //Obtener
        //Respuestas del metodo
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que el método puede devolver un código de estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que el método puede devolver un código de estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que el método puede devolver un código de estado 500 Internal Server Error
        public async Task<IActionResult> GetAllCancha()
        {
            try//Es un bloque donde colocas el código que quieres ejecutar pero que podría generar un error (excepción).
            {
                var Cancha = await _canchaRepositorio.ObtenerCancha();
                if (Cancha == null || !Cancha.Any())// verifica si los usuarios son nulos o esta vacia
                {
                    return NotFound("No se encontro Cancha.");
                }


                return Ok(Cancha);
            }
            catch (Exception ex) //Es el bloque que captura el error si ocurre dentro del try, evitando que la aplicación se detenga o se cierre.
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener Cancha ");// por que se usa una coma preguntar al profe

            }

        }
        [HttpGet("ObtenerRolesPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCanchaById(Guid id) // modificar a guid el int
        {
            try
            {
                var Cancha = await _canchaRepositorio.ObtenerCancha(id);

                if (Cancha == null)
                {
                    return NotFound(" Se Encontro Cancha ");
                }
                return Ok(Cancha);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Cancha");
            }

        }


    }
}

