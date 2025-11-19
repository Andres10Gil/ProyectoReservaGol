using Microsoft.AspNetCore.Http;
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
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public AutControlador(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
        }
        public async Task<IActionResult> Login(Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.NombreUsuario) || string.IsNullOrEmpty(login.Contraseña))
            {
                return Unauthorized();
            }  
            if (login.Contraseña == Usuario.Contraseña)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:audience"],
                    claims: new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.NombreUsuario),
                        new Claim(ClaimTypes.R)
                    };
            }


        
    
}
