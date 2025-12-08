using ReservaGol.Modelos;

namespace ReservaGol.Repositorios.Interfaces
{
    public interface IFacturacionRepositorio
    {
     
            Task<List<Facturacion>> ObtenerFactura(); // contrato tipo de documento

            Task<Facturacion> ObtenerFactura(Guid id);

            Task<bool> CrearFactura(Facturacion facturacion);

            Task<bool> ActualizarFactura(Facturacion facturacion);


            Task<bool> EliminarFactura(Guid id);

    }
}

