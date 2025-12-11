USE [master]
GO
/****** Object:  Database [Bd_ReservaGol]    Script Date: 18/11/2025 16:56:47 ******/
CREATE DATABASE [Bd_ReservaGol]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bd_ReservaGol', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Bd_ReservaGol.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bd_ReservaGol_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Bd_ReservaGol_log.ldf' , SIZE = 18432KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Bd_ReservaGol] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bd_ReservaGol].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bd_ReservaGol] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bd_ReservaGol] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bd_ReservaGol] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bd_ReservaGol] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bd_ReservaGol] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bd_ReservaGol] SET  MULTI_USER 
GO
ALTER DATABASE [Bd_ReservaGol] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bd_ReservaGol] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bd_ReservaGol] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bd_ReservaGol] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bd_ReservaGol] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bd_ReservaGol] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bd_ReservaGol', N'ON'
GO
ALTER DATABASE [Bd_ReservaGol] SET QUERY_STORE = OFF
GO
USE [Bd_ReservaGol]
GO
/****** Object:  Table [dbo].[Canchas]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canchas](
	[Id_Canchas] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Ubicacion] [nvarchar](250) NOT NULL,
	[Dimenciones] [nvarchar](50) NOT NULL,
	[Precio_Hora] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Canchas] PRIMARY KEY CLUSTERED 
(
	[Id_Canchas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[Id_Empresa] [uniqueidentifier] NOT NULL,
	[Id_Usuario] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Nit] [int] NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Ciudad] [nvarchar](70) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Correo] [nvarchar](250) NOT NULL,
	[Fecha_creacion] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[Id_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipamientos]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipamientos](
	[Id_Equipo] [uniqueidentifier] NOT NULL,
	[Id_Empresa] [uniqueidentifier] NOT NULL,
	[Nombre_equipo] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Equipamientos] PRIMARY KEY CLUSTERED 
(
	[Id_Equipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos_Promociones]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos_Promociones](
	[Id_Evento] [uniqueidentifier] NOT NULL,
	[Id_Empresa] [uniqueidentifier] NOT NULL,
	[Titulo] [nvarchar](250) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Fecha_inicio] [datetime] NOT NULL,
	[Fecha_fin] [datetime] NOT NULL,
	[Descuento] [decimal](18, 0) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Eventos_Promociones] PRIMARY KEY CLUSTERED 
(
	[Id_Evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[Id_Factura] [uniqueidentifier] NOT NULL,
	[Id_Reserva] [uniqueidentifier] NOT NULL,
	[Id_Usuario] [uniqueidentifier] NOT NULL,
	[Fecha_factura] [datetime] NOT NULL,
	[Metodo_pago] [nvarchar](50) NOT NULL,
	[Subtotal] [decimal](18, 0) NOT NULL,
	[Impuestos] [decimal](18, 0) NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Estado_pago] [nvarchar](50) NOT NULL,
	[Referencia_transaccion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Facturacion] PRIMARY KEY CLUSTERED 
(
	[Id_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos_detalle]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos_detalle](
	[Id_Pago] [uniqueidentifier] NOT NULL,
	[Id_Factura] [uniqueidentifier] NOT NULL,
	[Fecha_pago] [datetime] NOT NULL,
	[Monto] [decimal](18, 0) NOT NULL,
	[Metodo] [nvarchar](50) NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[Referencia] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Pagos_detalle] PRIMARY KEY CLUSTERED 
(
	[Id_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PQRS]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PQRS](
	[Id_Pqrs] [uniqueidentifier] NOT NULL,
	[Id_Usuario] [uniqueidentifier] NOT NULL,
	[Tipo] [nvarchar](150) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[Fecha_envio] [datetime] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[Respuesta] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_PQRS] PRIMARY KEY CLUSTERED 
(
	[Id_Pqrs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reportes_estadisticos]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reportes_estadisticos](
	[Id_Reporte] [uniqueidentifier] NOT NULL,
	[IdEmpresas] [uniqueidentifier] NOT NULL,
	[Fecha_generacion] [datetime] NOT NULL,
	[Tipo_reporte] [nvarchar](200) NOT NULL,
	[Periodo_inicio] [datetime] NOT NULL,
	[Periodo_fin] [datetime] NOT NULL,
	[Total_reservas] [int] NOT NULL,
	[Total_ingresos] [decimal](18, 0) NOT NULL,
	[Cancha_mas_reservada] [nvarchar](250) NOT NULL,
	[Usuario_mas_activo] [nvarchar](200) NOT NULL,
	[Tasa_ocupacion] [decimal](18, 0) NOT NULL,
	[Comentarios] [text] NOT NULL,
 CONSTRAINT [PK_Reportes_estadisticos] PRIMARY KEY CLUSTERED 
(
	[Id_Reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id_Reserva] [uniqueidentifier] NOT NULL,
	[Id_Usuario] [uniqueidentifier] NOT NULL,
	[Id_Cancha] [uniqueidentifier] NOT NULL,
	[Fecha_reserva] [datetime] NOT NULL,
	[Hora_inicio] [time](7) NOT NULL,
	[Hora_fin] [time](7) NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id_Reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id_Roles] [uniqueidentifier] NOT NULL,
	[Nombre_rol] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[Nivel_acceso] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Creando_em] [datetime] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id_Roles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/11/2025 16:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_Usuario] [uniqueidentifier] NOT NULL,
	[Id_Roles] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Contraseña] [varchar](250) NOT NULL,
	[Fecha_registro] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Empresas] CHECK CONSTRAINT [FK_Empresas_Usuarios]
GO
ALTER TABLE [dbo].[Equipamientos]  WITH CHECK ADD  CONSTRAINT [FK_Equipamientos_Empresas] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresas] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Equipamientos] CHECK CONSTRAINT [FK_Equipamientos_Empresas]
GO
ALTER TABLE [dbo].[Eventos_Promociones]  WITH CHECK ADD  CONSTRAINT [FK_Eventos_Promociones_Empresas] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresas] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Eventos_Promociones] CHECK CONSTRAINT [FK_Eventos_Promociones_Empresas]
GO
ALTER TABLE [dbo].[Pagos_detalle]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_detalle_Facturacion] FOREIGN KEY([Id_Factura])
REFERENCES [dbo].[Facturacion] ([Id_Factura])
GO
ALTER TABLE [dbo].[Pagos_detalle] CHECK CONSTRAINT [FK_Pagos_detalle_Facturacion]
GO
ALTER TABLE [dbo].[PQRS]  WITH CHECK ADD  CONSTRAINT [FK_PQRS_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
GO
ALTER TABLE [dbo].[PQRS] CHECK CONSTRAINT [FK_PQRS_Usuarios]
GO
ALTER TABLE [dbo].[Reportes_estadisticos]  WITH CHECK ADD  CONSTRAINT [FK_Reportes_estadisticos_Empresas1] FOREIGN KEY([IdEmpresas])
REFERENCES [dbo].[Empresas] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Reportes_estadisticos] CHECK CONSTRAINT [FK_Reportes_estadisticos_Empresas1]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Canchas] FOREIGN KEY([Id_Cancha])
REFERENCES [dbo].[Canchas] ([Id_Canchas])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Canchas]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Facturacion] FOREIGN KEY([Id_Reserva])
REFERENCES [dbo].[Facturacion] ([Id_Factura])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Facturacion]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Facturacion1] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Facturacion] ([Id_Factura])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Facturacion1]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([Id_Roles])
REFERENCES [dbo].[Roles] ([Id_Roles])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
USE [master]
GO
ALTER DATABASE [Bd_ReservaGol] SET  READ_WRITE 
GO
