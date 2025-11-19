using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaGol.Repositorio.Interfaces;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesControladores : ControllerBase
    {
        private readonly IRolesRepositorio _rolesRepositorio;

        public RolesControladores(IRolesRepositorio rolesRepositorio)
        {
            _rolesRepositorio = _rolesRepositorio;

        }
        [HttpGet("ObtenerRoles")] //Obtener
        //Respuestas del metodo
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que el método puede devolver un código de estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que el método puede devolver un código de estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que el método puede devolver un código de estado 500 Internal Server Error
        public async Task<IActionResult> GetAllRoles()
        {
            try//Es un bloque donde colocas el código que quieres ejecutar pero que podría generar un error (excepción).
            {
                var Roles = await _rolesRepositorio.ObtenerRoles();
                if (Roles == null || !Roles.Any())// verifica si los usuarios son nulos o esta vacia
                {
                    return NotFound("No se encontro Roles.");
                }


                return Ok(Roles);
            }
            catch (Exception ex) //Es el bloque que captura el error si ocurre dentro del try, evitando que la aplicación se detenga o se cierre.
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener Roles ");// por que se usa una coma preguntar al profe

            }

        }
        [HttpGet("ObtenerRolesPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRolesById(int id) // modificar a guid el int
        {
            try
            {
                var roles = await _rolesRepositorio.ObtenerRoles(id);

                if (roles == null)
                {
                    return NotFound(" Se Encontro Roles ");
                }
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Roles ");
            }

            }


        }
}
