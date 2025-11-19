using ReservaGol.Modelos;

namespace ReservaGol.Repositorios.Interfaces
{
    public interface IReservaRepositorio
    {
        Task<List<Reserva>> ObtenerReserva();
        Task<Reserva> ObtenerReserva(int id);

        Task<bool> CrearReserva(Reserva reserva);

        Task<bool> ActualizarReserva(Reserva reserva);


        Task<bool> EliminarReserva(int id);

    }

}
}
