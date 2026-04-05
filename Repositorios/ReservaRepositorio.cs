using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly BdReservaGolContext _context;

        public ReservaRepositorio(BdReservaGolContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> ObtenerReserva()
        {
            try { return await _context.Reserva.ToListAsync(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Reserva> ObtenerReserva(Guid id)
        {
            try { return await _context.Reserva.FirstOrDefaultAsync(x => x.Id_Reserva == id); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> CrearReserva(Reserva reserva)
        {
            try
            {
                reserva.Id_Reserva = Guid.NewGuid();
                _context.Reserva.Add(reserva);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR CrearReserva: {ex.Message} | Inner: {ex.InnerException?.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarReserva(Guid id)
        {
            try
            {
                var existente = await _context.Reserva.FirstOrDefaultAsync(x => x.Id_Reserva == id);
                if (existente == null) return false;
                _context.Reserva.Remove(existente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> ActualizarReserva(Reserva reserva)
        {
            try
            {
                var existente = await _context.Reserva.FirstOrDefaultAsync(x => x.Id_Reserva == reserva.Id_Reserva);
                if (existente == null) return false;
                existente.Fecha_reserva = reserva.Fecha_reserva;
                existente.Hora_inicio = reserva.Hora_inicio;
                existente.Hora_fin = reserva.Hora_fin;
                existente.Estado = reserva.Estado;
                _context.Reserva.Update(existente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
