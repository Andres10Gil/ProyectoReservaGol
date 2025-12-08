using ReservaGol.Modelos;

namespace ReservaGol.Repositorios.Interfaces
{
    public interface IPagosRepositorio
    {
      
        
            Task<List<Pagos>> ObtenerPagos(); // contrato tipo de documento

            Task<Pagos> ObtenerPagos(Guid id);



 
        }
    }


