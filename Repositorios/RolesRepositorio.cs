using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Repositorios
{
    public class RolesRepositorio : IRolesRepositorio
    {
        private readonly BdReservaGolContext _context;

        public RolesRepositorio(BdReservaGolContext context)
        {
            _context = context;
        }

        public async Task<List<Roles>> ObtenerRoles()
        {
            try { return await _context.Roles.ToListAsync(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Roles> ObtenerRoles(Guid id)
        {
            try { return await _context.Roles.FirstOrDefaultAsync(x => x.Id_Roles == id); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
