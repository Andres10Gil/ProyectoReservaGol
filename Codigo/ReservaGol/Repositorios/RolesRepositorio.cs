using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorios.Interfaces;
using static ReservaGol.Repositorios.RolesRepositorio;

namespace ReservaGol.Repositorios
{
    public class RolesRepositorio : IRolesRepositorio
    {
    
        
            private readonly BdReservaGolContext _context;

            public RolesRepositorio (BdReservaGolContext context)
            {
                _context = context;
            }

            public async Task<List<Roles>> ObtenerRoles()
            {
                try
                {
                    return await _context.Roles.ToListAsync();
            }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }

            public async Task<Roles> ObtenerRoles(int id)
            {
                try
                {
                    return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }

