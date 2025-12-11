using Microsoft.EntityFrameworkCore;
using ReservaGol.context;
using ReservaGol.Repositorio.Interfaces;
using ReservaGol.Repositorios;
using ReservaGol.Repositorios.Interfaces;

namespace ReservaGol
{
    public static class DependenciasInyeccion
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = "";
            connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];//trae el valor no el objeto 

            services.AddDbContext<BdReservaGolContext>(options => options.UseSqlServer(connectionString)); //Configura el contexto de la base de datos para usar SQL Server con la cadena de conexión proporcionada
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>(); //Registra el repositorio de personas como un servicio con alcance (scoped) en el contenedor de inyección de dependencias
            services.AddScoped<IRolesRepositorio, RolesRepositorio>(); //Registra el repositorio de tipo de documento como un servicio con alcance (scoped) en el contenedor de inyección de dependencias
            services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
            services.AddScoped<ICanchaRepositorio, CanchaRepositorio>();
            services.AddScoped<IFacturacionRepositorio, FacturacionRepositorio>();
            services.AddScoped<IPagosRepositorio, PagosRepositorio>();
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            return services;
        }
    }
}
