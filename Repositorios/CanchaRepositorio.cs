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

        // Crea una nueva cancha en la BD
        // Genera un nuevo GUID como ID y guarda el registro
        public async Task<bool> CrearCancha(Cancha cancha)
        {
            try
            {
                cancha.Id_Canchas = Guid.NewGuid();
                _context.Canchas.Add(cancha);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> EliminarCancha(Guid id)
        {
            try
            {
                var existente = await _context.Canchas.FirstOrDefaultAsync(x => x.Id_Canchas == id);
                if (existente == null) return false;
                _context.Canchas.Remove(existente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
