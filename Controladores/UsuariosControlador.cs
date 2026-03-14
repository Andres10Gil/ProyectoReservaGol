using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControlador : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosControlador(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("ObtenerUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsuario()
        {
            try
            {
                var usuarios = await _usuarioRepositorio.ObtenerUsuario();
                if (usuarios == null || !usuarios.Any())
                    return NotFound("No se encontraron usuarios.");
                return Ok(usuarios);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener usuarios."); }
        }

        [HttpGet("ObtenerUsuarioPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuarioById(Guid id)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObtenerUsuario(id);
                if (usuario == null)
                    return NotFound("Usuario no encontrado.");
                return Ok(usuario);
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el usuario."); }
        }

        [HttpPost("CrearUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearUsuarios([FromBody] Usuario usuario)
        {
            try
            {
                var resultado = await _usuarioRepositorio.CrearUsuarios(usuario);
                if (!resultado)
                    return BadRequest("No se pudo crear el usuario.");
                return Ok("Usuario creado correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario."); }
        }

        [HttpDelete("EliminarUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarUsuarios(Guid id)
        {
            try
            {
                var resultado = await _usuarioRepositorio.EliminarUsuarios(id);
                if (!resultado)
                    return BadRequest("No se pudo eliminar el usuario.");
                return Ok("Usuario eliminado correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el usuario."); }
        }

        [HttpPut("ActualizarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarUsuarios([FromBody] Usuario usuario)
        {
            try
            {
                var resultado = await _usuarioRepositorio.ActualizarUsuarios(usuario);
                if (!resultado)
                    return BadRequest("No se pudo actualizar el usuario.");
                return Ok("Usuario actualizado correctamente.");
            }
            catch { return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario."); }
        }
    }
}
