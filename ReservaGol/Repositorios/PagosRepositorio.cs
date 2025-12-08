using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Repositorios
{
    public class PagosRepositorio : IPagosRepositorio
    {
        private readonly BdReservaGolContext _context;

        public PagosRepositorio(BdReservaGolContext context)
        {
            _context = context;
        }

        public async Task<List<Pagos>> ObtenerPagos()
        {
            try
            {
                return await _context.Pagos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<Pagos> ObtenerPagos(Guid id)
        {
            try
            {
                return await _context.Pagos.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

