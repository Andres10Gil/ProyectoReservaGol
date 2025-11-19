using ReservaGol.Modelos;

namespace ReservaGol.Repositorios.Interfaces
{
    public interface ICanchaRepositorio
    {
        Task<List<Cancha>> ObtenerCancha();

        Task<Cancha> ObtenerCancha(int id);

    }

}

