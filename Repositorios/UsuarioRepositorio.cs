using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;

namespace ReservaGol.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BdReservaGolContext _context;

        public UsuarioRepositorio(BdReservaGolContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuario()
        {
            try { return await _context.Usuarios.ToListAsync(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Usuario> ObtenerUsuario(Guid id)
        {
            try { return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == id); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Usuario> ObtenerUsuarioPorCorreo(string correo)
        {
            try { return await _context.Usuarios.FirstOrDefaultAsync(x => x.Correo == correo); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> CrearUsuarios(Usuario usuario)
        {
            try
            {
                usuario.Id_Usuario = Guid.NewGuid();
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> EliminarUsuarios(Guid id)
        {
            try
            {
                var existente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == id);
                if (existente == null) return false;
                _context.Usuarios.Remove(existente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> ActualizarUsuarios(Usuario usuario)
        {
            try
            {
                var existente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == usuario.Id_Usuario);
                if (existente == null) return false;
                existente.Nombre = usuario.Nombre;
                existente.Correo = usuario.Correo;
                existente.Telefono = usuario.Telefono;
                existente.Contraseña = usuario.Contraseña;
                existente.Fecha_registro = usuario.Fecha_registro;
                _context.Usuarios.Update(existente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
