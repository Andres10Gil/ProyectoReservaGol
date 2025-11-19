using Microsoft.EntityFrameworkCore;
using ReservaGol.Modelos;

namespace ReservaGol.context
{
    public class BdReservaGolContext : DbContext
    {// Constructor: recibe las opciones del contexto (configuradas en Program.cs)
        public BdReservaGolContext(DbContextOptions<BdReservaGolContext>options):   base(options)
        {
        }
        //Tablas (DbSets)
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Reserva> Reserva {  get; set; }

        public DbSet<Cancha> Cancha { get; set; }
        //relacion personalizada/  Configuración de las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100).HasColumnName("Nombre");
                entity.Property(e => e.Correo).IsRequired().HasMaxLength(50).HasColumnName("Correo");
                entity.Property(e => e.Telefono).IsRequired().HasColumnName("Telefono");
                entity.Property(e => e.Contraseña).IsRequired().HasMaxLength(250).HasColumnName("Contraseña");
                entity.Property(e => e.FechaRegistro).IsRequired().HasColumnName("Fecha_Registro");
                entity.HasOne(e => e.Roles)  // Relación con Roles
                      .WithMany(t => t.Usuarios)
                      .HasForeignKey(e => e.IdRoles);
                entity.ToTable("Usuarios");
            });
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NombreRol).IsRequired().HasMaxLength(50).HasColumnName("Nombre_Rol");
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(250).HasColumnName("Descripcion");
                entity.Property(e => e.NivelAcceso).IsRequired().HasColumnName("Nivel_Acceso");
                entity.Property(e => e.Activo).IsRequired().HasColumnName("Activo");   
                entity.Property(e => e.CreandoEm).IsRequired().HasColumnName("Creando_em");
                entity.ToTable("Roles");
            });
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FechaReserva).IsRequired().HasColumnName("Fecha_reserva");
                entity.Property(e => e.HoraFin).IsRequired().HasColumnName("Hora_fin");
                entity.Property(e => e.HoraInicio).IsRequired().HasColumnName("Hora_inicio");
                entity.Property(e => e.Estado).IsRequired().HasColumnName("Estado");
               
                entity.HasOne(i => i.Usuario)  // Relación con usuario
                      .WithMany(t => t.Reservas)
                      .HasForeignKey(e => e.IdUsusario);

                entity.HasOne(e => e.Cancha)  // Relación con Cancha
                      .WithMany(t => t.Reservas)
                      .HasForeignKey(e => e.IdCancha);
                entity.ToTable("Reserva");

            });
            modelBuilder.Entity<Cancha>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50).HasColumnName("Nombre");
                entity.Property(e => e.Ubicacion).IsRequired().HasMaxLength(250).HasColumnName("Ubicacion");
                entity.Property(e => e.Dimenciones).IsRequired().HasColumnName("Dimenciones");
                entity.Property(e => e.PrecioHora).IsRequired().HasColumnName("Precio_Hora");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
    