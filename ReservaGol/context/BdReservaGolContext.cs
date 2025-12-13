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

        public DbSet<Facturacion> facturacion { get; set; }

        public DbSet<Pagos> Pagos { get; set; }

        public DbSet<Pqrs> Pqrs { get; set; }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Empresas> Equipamientos { get; set; }



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

            modelBuilder.Entity<Facturacion>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.FechaFactura).IsRequired().HasColumnName("Fecha_factura");
                entity.Property(e => e.MetodoPago).IsRequired().HasColumnName("Metodo_pago");
                entity.Property(e => e.SubTotal).IsRequired().HasColumnName("Subtotal");
                entity.Property(e => e.Impuestos).IsRequired().HasColumnName("Impuestos");
                entity.Property(e => e.Total).IsRequired().HasColumnName("Total");
                entity.Property(e => e.EstadoPago).IsRequired().HasColumnName("Estado_pago");
                entity.Property(e => e.ReferenciaTransanccion).IsRequired().HasColumnName("Referencia_transanccion");

                entity.HasOne(i => i.Usuario)  // Relación con usuario
                      .WithMany(t => t.Facturacion)
                      .HasForeignKey(e => e.IdUsuarios);

                entity.HasOne(e => e.Reserva)  // Relación con Cancha
                      .WithMany(t => t.Facturacion)
                      .HasForeignKey(e => e.IdReserva);
                entity.ToTable("Facturacion");

            });
            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FechaPago).IsRequired().HasColumnName("Fecha_pagos");
                entity.Property(e => e.Monto).IsRequired().HasColumnName("Monto");
                entity.Property(e => e.Metodo).IsRequired().HasMaxLength(50).HasColumnName("Monto");
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(50).HasColumnName("Estado");
                entity.Property(e => e.Referencia).IsRequired().HasMaxLength(100).HasColumnName("Referecia");

            });
            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);
                entity.Property(e => e.NombreEmpresa).IsRequired().HasMaxLength(100).HasColumnName("Nombre_Empresa");
                entity.Property(e => e.Nit).IsRequired().HasColumnName("Nit");
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(100).HasColumnName("Direccion");
                entity.Property(e => e.Ciudad).IsRequired().HasMaxLength(70).HasColumnName("Ciudad");
                entity.Property(e => e.Telefono).IsRequired().HasColumnName("Telefono");
                entity.Property(e => e.CorreoElectronico).IsRequired().HasMaxLength(250).HasColumnName("CorreoElectronico");
                entity.Property(e => e.FechaCreacion).IsRequired().HasColumnName("Fecha_Creacion");
                entity.Property(e => e.Activo).IsRequired().HasColumnName("Activo");

                entity.HasOne(i => i.usuario)  // Relación con usuario
                       .WithMany(t => t.Empresas)
                       .HasForeignKey(e => e.IdUsuarios);
            });

            modelBuilder.Entity<Equipamientos>(entity =>
            {
                entity.HasKey(e => e.IdEquipo);
                entity.Property(e => e.NombreEquipo).IsRequired().HasMaxLength(100).HasColumnName("NombreEquipo");
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(250).HasColumnName("Cantidad");
                entity.Property(e => e.Cantidad).IsRequired().HasColumnName("Cantidad");
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(250).HasColumnName("Estado");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
    