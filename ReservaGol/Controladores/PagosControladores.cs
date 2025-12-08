using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosControladores : ControllerBase
    {
        private readonly IPagosRepositorio _pagosRepositorio;

        public PagosControladores(IPagosRepositorio pagosRepositorio)
        {
            _pagosRepositorio = _pagosRepositorio;

        }
        [HttpGet("ObtenerPagos")] //Obtener
        //Respuestas del metodo
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que el método puede devolver un código de estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que el método puede devolver un código de estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que el método puede devolver un código de estado 500 Internal Server Error
        public async Task<IActionResult> GetAllPagos()
        {
            try//Es un bloque donde colocas el código que quieres ejecutar pero que podría generar un error (excepción).
            {
                var Pagos = await _pagosRepositorio.ObtenerPagos();
                if (Pagos == null || Pagos.Any())// verifica si los usuarios son nulos o esta vacia
                {
                    return NotFound("No se encontro pago.");
                }


                return Ok(Pagos);
            }
            catch (Exception ex) //Es el bloque que captura el error si ocurre dentro del try, evitando que la aplicación se detenga o se cierre.
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener pago ");// por que se usa una coma preguntar al profe

            }

        }
        [HttpGet("ObtenerPagosPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPagosById(Guid id) // modificar a guid el int
        {
            try
            {
                var pagos= await _pagosRepositorio.ObtenerPagos(id);

                if (pagos == null)
                {
                    return NotFound(" Se Encontro Cancha ");
                }
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Cancha");
            }

        }


    }
}

