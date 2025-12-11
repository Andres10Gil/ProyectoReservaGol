using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Modelos;
using ReservaGol.Repositorios.Interfaces;
using static ReservaGol.Repositorios.EmpresaRepositorio;

namespace ReservaGol.Repositorios
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {


        private readonly BdReservaGolContext _context;

        public EmpresaRepositorio(BdReservaGolContext context)
        {
            _context = context;
        }
            
            public async Task<List<Empresas>> ObtenerEmpresas()
            {
                try
                {
                    return await _context.Empresas.ToListAsync();
                }
                catch (Exception ex)
                {
                    // Manejo de la excepción (puedes registrar el error o lanzar una excepción personalizada)
                    throw new Exception("Error al obtener las empresas", ex);
                }
            }
            public async Task<Empresas> ObtenerEmpresa(Guid id)
            {
                try
                {
                    return await _context.Empresas.FirstOrDefaultAsync(x => x.IdEmpresa == id);
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }

            }
        }
    }
}
