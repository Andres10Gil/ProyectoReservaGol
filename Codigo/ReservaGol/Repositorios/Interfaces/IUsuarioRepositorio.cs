using ReservaGol.Modelos;

namespace ReservaGol.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> ObtenerUsuario(); // contrato tipo de documento

        Task<Usuario> ObtenerUsuario(int id);

        Task<bool> CrearUsuarios(Usuario usuario);

        Task<bool> ActualizarUsuarios(Usuario usuario);


        Task<bool> EliminarUsuarios(int id);

    }
}
