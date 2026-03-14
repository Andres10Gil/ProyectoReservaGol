using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReservaGol.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutControlador : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IConfiguration _configuration;

        public AutControlador(IUsuarioRepositorio usuarioRepositorio, IConfiguration configuration)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.NombreUsuario) || string.IsNullOrEmpty(login.Contraseña))
                return Unauthorized("Credenciales inválidas.");

            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorCorreo(login.NombreUsuario);

            if (usuario == null || usuario.Contraseña != login.Contraseña)
                return Unauthorized("Usuario o contraseña incorrectos.");

            var token = GenerarToken(usuario);
            return Ok(new { token });
        }

        private string GenerarToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id_Usuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo)
            };

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
