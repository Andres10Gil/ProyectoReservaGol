using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionControladores : ControllerBase
    {
        private readonly IFacturacionRepositorio _facturacionRepositorio;//Variable global  es accesible desde cualquuier pRTE DEL codigo


        //crear dependencias con constructor personalizado
        public FacturacionControladores(IFacturacionRepositorio facturacionRepositorio)
        {
            _facturacionRepositorio = facturacionRepositorio;

        }
        [HttpGet("ObtenerFactura")] //Obtener
        //Respuestas del metodo
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que el método puede devolver un código de estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que el método puede devolver un código de estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que el método puede devolver un código de estado 500 Internal Server Error
        public async Task<IActionResult> GetAllFacturacion()
        {
            try//Es un bloque donde colocas el código que quieres ejecutar pero que podría generar un error (excepción).
            {
                var Facturacion = await _facturacionRepositorio.ObtenerFactura();
                if (Facturacion == null || !Facturacion.Any())// verifica si los usuarios son nulos o esta vacia
                {
                    return NotFound("No se encontro factura.");
                }


                return Ok(Facturacion);
            }
            catch (Exception ex) //Es el bloque que captura el error si ocurre dentro del try, evitando que la aplicación se detenga o se cierre.
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener factura ");// por que se usa una coma preguntar al profe

            }

        }
        [HttpGet("ObtenerFacturaPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFacturacionById(Guid id) // modificar a guid el int
        {
            try
            {
                var facturacion = await _facturacionRepositorio.ObtenerFactura(id);

                if (facturacion == null)
                {
                    return NotFound(" Se Encontro factura ");
                }
                return Ok(facturacion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el factura ");
            }

        }


        [HttpPost("CrearFactura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CrearFactura([FromBody]Facturacion facturacion)
        {
            try
            {
                var resultados = await _facturacionRepositorio.CrearFactura(facturacion);

                if (!resultados)
                {
                    return BadRequest("No se puede crear factura");
                    ;
                }
                return Ok("Factura creado correctamente");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el factura ");
            }

        }

        [HttpPost("EliminarFactura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> EliminarFactura(Guid id)
        {
            try
            {
                var resultado = await _facturacionRepositorio.EliminarFactura(id);
                if (!resultado)
                {
                    return BadRequest("No se puede eliminar Factura");

                }
                return Ok(" Factura eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al elimnar la factura");
            }
        }
        [HttpPost("ActualizarFactura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ActualizarFactura([FromBody] Facturacion facturacion)
        {
            try
            {
                var resultados = await _facturacionRepositorio.ActualizarFactura(facturacion);

                if (!resultados)
                {
                    return BadRequest("No se puede Actualizar factura");
                    ;
                }
                return Ok("Factura Actualizada correctamente");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Actualizar la factura ");
            }

        }
    }
}

