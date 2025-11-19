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
        public async Task<Reserva> ObtenerReserva(int id)
        {
            try
            {
                return await _context.Reserva.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message.ToString()); // sentencia 




            }

        }
        public async Task<List<Reserva>> ObtenerReserva() //metodo obtener tipo de documento
        {
            try
            {
                return await _context.Reserva.ToListAsync();

            }
            catch (Exception ex) // captura errores dentro de la variable ex
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<bool> CrearReserva(Reserva reserva)
        {

            try
            {
                _context.Reserva.Add(reserva);
                await _context.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString()); // sentencia 

            }
        }
        public async Task<bool> EliminarReserva(int id)
        {
            {
                try
                {
                    var ReservaExistente = await _context.Reserva.FirstOrDefaultAsync(x => x.Id == id);
                    if (ReservaExistente == null)
                    {
                        return false;
                        throw new Exception("Reserva para eliminar no existe");
                    }
                    _context.Reserva.Remove(ReservaExistente);
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
        public async Task<bool> ActualizarReserva(Reserva reserva)
        {
            try
            {
                var ReservaExistente = await _context.Reserva.FirstOrDefaultAsync(x => x.Id == reserva.Id);
                if (ReservaExistente == null)
                {
                    return false;
                    throw new Exception("Usuarios Para Actualizar No Existe");
                }
                ReservaExistente.FechaReserva = reserva.FechaReserva;
                ReservaExistente.HoraInicio = reserva.HoraInicio;
                ReservaExistente.HoraFin = reserva.HoraFin;
                ReservaExistente.Estado = reserva.Estado;

                _context.Reserva.Update(ReservaExistente);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }



    }
}
