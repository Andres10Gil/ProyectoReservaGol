using Microsoft.AspNetCore.Mvc;
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
            _rolesRepositorio = rolesRepositorio;
        }

        [HttpGet("ObtenerRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _rolesRepositorio.ObtenerRoles();
                if (roles == null || !roles.Any())
                    return NotFound("No se encontraron roles.");
                return Ok(roles);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener roles."); }
        }

        [HttpGet("ObtenerRolesPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRolesById(Guid id)
        {
            try
            {
                var rol = await _rolesRepositorio.ObtenerRoles(id);
                if (rol == null)
                    return NotFound("Rol no encontrado.");
                return Ok(rol);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el rol."); }
        }
    }
}
