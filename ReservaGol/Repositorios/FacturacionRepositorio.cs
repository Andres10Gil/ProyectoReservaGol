using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorio.Interfaces;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol.Repositorios
{
    
    
        public class FacturacionRepositorio : IFacturacionRepositorio
        {
            private readonly BdReservaGolContext _context;

            public FacturacionRepositorio(BdReservaGolContext context)
            {
                _context = context;
            }


            public async Task<Facturacion> ObtenerFactura(Guid id)
            {
                try
                {
                    return await _context.facturacion.FirstOrDefaultAsync(x => x.id == id);
                }
                catch (Exception ex)

                {
                    throw new Exception(ex.Message.ToString()); // sentencia 




                }

            }
            public async Task<List<Facturacion>> ObtenerFactura() //metodo obtener tipo de documento
            {
                try
                {
                    return await _context.facturacion.ToListAsync();

                }
                catch (Exception ex) // captura errores dentro de la variable ex
                {
                    throw new Exception(ex.Message.ToString());
                }
            }

            public async Task<bool> CrearFactura(Facturacion facturacion)
            {

                try
                {
                    _context.facturacion.Add(facturacion);
                    await _context.SaveChangesAsync();
                    return true;
                }

                catch (Exception ex)
                {
                    return false;
                    throw new Exception(ex.Message.ToString()); // sentencia 

                }
            }
            public async Task<bool> EliminarFactura(Guid id)
            {
                {
                    try
                    {
                        var FacturacionExistente = await _context.facturacion.FirstOrDefaultAsync(x => x.id == id);
                        if (FacturacionExistente == null)
                        {
                            return false;
                            throw new Exception("No se puede eliminar factura");
                        }
                        _context.facturacion.Remove(FacturacionExistente);
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
            public async Task<bool> ActualizarFactura(Facturacion facturacion)
            {
                try
                {
                    var FacturacionExistente = await _context.facturacion.FirstOrDefaultAsync(x => x.id == facturacion.id);
                    if (FacturacionExistente == null)
                    {
                        return false;
                        throw new Exception("Factura Para Actualizar No Existe");
                    }
                    FacturacionExistente.MetodoPago = facturacion.MetodoPago;
                    FacturacionExistente.EstadoPago = facturacion.EstadoPago;
                    FacturacionExistente.ReferenciaTransanccion = facturacion.ReferenciaTransanccion;
                    

                    _context.facturacion.Update(FacturacionExistente);
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
