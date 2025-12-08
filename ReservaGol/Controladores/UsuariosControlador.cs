using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;
using ReservaGol.Repositorios;
using System.Linq.Expressions;

namespace ReservaGol.Controladores

{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControlador : ControllerBase
    {
        // inyectar dependencias paso 1
        private readonly IUsuarioRepositorio _usuarioRepositorio;//Variable global  es accesible desde cualquuier pRTE DEL codigo


        //crear dependencias con constructor personalizado
        public UsuariosControlador(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }
        [HttpGet("ObtenerUsuario")] //Obtener
        //Respuestas del metodo
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que el método puede devolver un código de estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que el método puede devolver un código de estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que el método puede devolver un código de estado 500 Internal Server Error
        public async Task<IActionResult> GetAllUsuario()
        {
            try//Es un bloque donde colocas el código que quieres ejecutar pero que podría generar un error (excepción).
            {
                var Usuarios = await _usuarioRepositorio.ObtenerUsuario();
                if (Usuarios == null || !Usuarios.Any())// verifica si los usuarios son nulos o esta vacia
                {
                    return NotFound("No se encontro usuarios.");
                }


                return Ok(Usuarios);
            }
            catch (Exception ex) //Es el bloque que captura el error si ocurre dentro del try, evitando que la aplicación se detenga o se cierre.
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener ususarios ");// por que se usa una coma preguntar al profe

            }

        }
        [HttpGet("ObtenerUsuarioPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuarioById(Guid id) // modificar a guid el int
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObtenerUsuario(id);

                if (usuario == null)
                {
                    return NotFound(" Se Encontro Usuario ");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Usuario ");
            }

            }
        

        [HttpPost("CrearUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CrearUsuarios([FromBody] Usuario usuario)
        {
            try
            {
                var resultados = await _usuarioRepositorio.CrearUsuarios(usuario);

                if (!resultados)
                {
                    return BadRequest("No se puede crear Usuario");
                    ;
                }
                return Ok("Usuario creado correctamente");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario ");
            }

        }
    
    [HttpPost("EliminarUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> EliminarUsuarios(Guid id)
        {
            try
            {
                var resultado = await _usuarioRepositorio.EliminarUsuarios(id);
                if (!resultado)
                {
                    return BadRequest("No se puede eliminar Usuario");

                }
                return Ok(" Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al elimnar el usuario");
            }
        }
        [HttpPost("ActualizarUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ActualizarUsuarios([FromBody] Usuario usuario)
        {
            try
            {
                var resultados = await _usuarioRepositorio.ActualizarUsuarios(usuario);

                if (!resultados)
                {
                    return BadRequest("No se puede Actualizar Usuario");
                    ;
                }
                return Ok("Usuario Actualizado correctamente");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Actualizar  n el usuario ");
            }

        }
    }
}
