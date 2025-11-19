using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            try
            {
                return await _context.Cancha.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<Cancha> ObtenerCancha(int id)
        {
            try
            {
                return await _context.Cancha.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
