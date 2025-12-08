using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;
using ReservaGol.Repositorios;

namespace ReservaGol.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BdReservaGolContext _context;

        public UsuarioRepositorio(BdReservaGolContext context)
        {
            _context = context;
        }
      

        public async Task<Usuario> ObtenerUsuario(Guid id)
        {
            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message.ToString()); // sentencia 




            }

        }
        public async Task<List<Usuario>> ObtenerUsuario() //metodo obtener tipo de documento
        {
            try
            {
                return await _context.Usuarios.ToListAsync();

            }
            catch (Exception ex) // captura errores dentro de la variable ex
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<bool> CrearUsuarios(Usuario usuario) {

            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString()); // sentencia 

            }
        }
        public async Task<bool> EliminarUsuarios(Guid id) {
            {
                try
                {
                    var UsuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
                    if (UsuarioExistente == null) 
                    {
                        return false;
                        throw new Exception("uUsuario para eliminar no existe");
                    }
                    _context.Usuarios.Remove(UsuarioExistente);
                    await _context.SaveChangesAsync();
                    return true;


                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(ex.Message.ToString()); // sentencia 

                }
            }
        }
        public async Task<bool> ActualizarUsuarios(Usuario usuario)
        {
            try
            {
                var UsuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuario.Id);
                if (UsuarioExistente == null) 
                {
                    return false;
                    throw new Exception("Usuarios Para Actualizar No Existe");
                }
                UsuarioExistente.Nombre = usuario.Nombre;
                UsuarioExistente.Correo = usuario.Correo;
                UsuarioExistente.Telefono = usuario.Telefono;
                UsuarioExistente.Contraseña = usuario.Contraseña;
                UsuarioExistente.FechaRegistro = usuario.FechaRegistro;

                _context.Usuarios.Update(UsuarioExistente);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception (ex.Message.ToString());
            }
        }

        }
    
}

        
    
