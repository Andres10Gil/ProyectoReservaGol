using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Repositorios
{
    public class CanchaRepositorio : ICanchaRepositorio
    {
        private readonly BdReservaGolContext _context;

        public CanchaRepositorio(BdReservaGolContext context)
        {
            _context = context;
        }

        public async Task<List<Cancha>> ObtenerCancha()
        {
            try { return await _context.Canchas.ToListAsync(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Cancha> ObtenerCancha(Guid id)
        {
            try { return await _context.Canchas.FirstOrDefaultAsync(x => x.Id_Canchas == id); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
