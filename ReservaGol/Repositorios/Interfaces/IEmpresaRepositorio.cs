using ReservaGol.Modelos;

namespace ReservaGol.Repositorios.Interfaces
{
    public interface IEmpresaRepositorio
    {
        Task<List<Empresas>> ObtenerEmpresas();

        Task<Empresas> ObtenerEmpresa(Guid id);
    }
    
}
