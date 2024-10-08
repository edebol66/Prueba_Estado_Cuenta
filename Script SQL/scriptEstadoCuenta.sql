USE [Estado_Cuenta]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Telefono] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[Id_Compras] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cuenta] [int] NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Monto] [float] NOT NULL,
	[Fecha_Compra] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Compras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuracion_Porcentajes]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuracion_Porcentajes](
	[Id_Configuracion_Porcentajes] [int] IDENTITY(1,1) NOT NULL,
	[NombreConfiguracion] [varchar](50) NOT NULL,
	[DatoConfiguracion] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Configuracion_Porcentajes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Id_Tipo_Cuenta] [int] NOT NULL,
	[Numero_Cuenta] [varchar](15) NOT NULL,
	[Saldo] [float] NOT NULL,
	[Fecha_Cuenta] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Numero_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[Id_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cuenta] [int] NOT NULL,
	[Monto] [float] NOT NULL,
	[Fecha_Pago] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Id_Tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[Id_Tipo_Tarjeta] [int] NOT NULL,
	[Id_Cuenta] [int] NOT NULL,
	[Numero_Tarjeta] [varchar](20) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Cuenta]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Cuenta](
	[Id_Tipo_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Cuenta] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_tarjeta]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_tarjeta](
	[Id_Tipo_Tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Tarjeta] [varchar](100) NOT NULL,
	[Limite] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Cuenta] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[Cuenta] ([Id_Cuenta])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Cuenta]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoCuenta] FOREIGN KEY([Id_Tipo_Cuenta])
REFERENCES [dbo].[Tipo_Cuenta] ([Id_Tipo_Cuenta])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoCuenta]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Cuenta] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[Cuenta] ([Id_Cuenta])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Cuenta]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Cuenta] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[Cuenta] ([Id_Cuenta])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Cuenta]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_TipoTarjeta] FOREIGN KEY([Id_Tipo_Tarjeta])
REFERENCES [dbo].[Tipo_tarjeta] ([Id_Tipo_Tarjeta])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_TipoTarjeta]
GO
/****** Object:  StoredProcedure [dbo].[realizarCompra]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[realizarCompra]
	@idCliente integer,
	@monto float,
	@descripcion varchar(250),
	@fecha datetime
AS
BEGIN
	DECLARE @idCuenta integer;

	SELECT @idCuenta = Id_Cuenta
	FROM Cuenta
	WHERE Id_Cliente = @idCliente;

	INSERT INTO Compra (Id_Cuenta,Monto,Descripcion,Fecha_Compra)
	VALUES (@idCuenta,@monto,@descripcion,@fecha);

	UPDATE Cuenta SET Saldo = Saldo + @monto
	WHERE Id_Cliente = @idCliente;
END;
GO
/****** Object:  StoredProcedure [dbo].[realizarPago]    Script Date: 5/9/2024 12:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[realizarPago]
	@idCliente integer,
	@monto float,
	@fecha datetime
AS
BEGIN
	DECLARE @idCuenta integer;

	SELECT @idCuenta = Id_Cuenta
	FROM Cuenta
	WHERE Id_Cliente = @idCliente;

	INSERT INTO Pago (Id_Cuenta,Monto,Fecha_Pago)
	VALUES (@idCuenta,@monto,@fecha);

	UPDATE Cuenta SET Saldo = Saldo - @monto
	WHERE Id_Cliente = @idCliente;
END;
GO

INSERT INTO Configuracion_Porcentajes (NombreConfiguracion, DatoConfiguracion)
VALUES
('IntBonificable', 0.25),
('SaldoMinimo', 0.05);

INSERT INTO Tipo_Cuenta (Tipo_Cuenta)
VALUES
('Tarjeta de Crédito Básica o Revolvente'),
('Tarjeta de Crédito Secured o Garantizada'),
('Tarjeta de Crédito con Beneficios Limitados'),
('Tarjeta de Crédito para Estudiantes');

INSERT INTO Tipo_Tarjeta (Tipo_Tarjeta, Limite)
VALUES
('Oro', 3000),
('Platinum', 4000),
('AhorroNu', 1000);


INSERT INTO Cliente (Nombre, Apellido, Direccion, Telefono)
VALUES
('Juan', 'Pérez', 'Calle 24 avenida felicidad, Santa Ana', '7825-1724'),
('María', 'González', 'Avenida Septiembre 25, San Salvador', '7661-8956'),
('Carlos', 'Rodríguez', 'Boulevard de los Sueños.Casa #6, Sonsonate', '6162-8549'),
('Jonathan Edenilson', 'Bolaños Bolaños', 'Colonia Grecia, Tacuba. Ahuachapán', '7815-7107');

INSERT INTO Cuenta (Id_Cliente, Id_Tipo_Cuenta, Numero_Cuenta, Saldo, Fecha_Cuenta)
VALUES
(1, 1, '123456789012345', 0, '2024-09-01 22:32:02.777'),
(2, 1, '123456789012346', 5.5, '2024-09-05 22:32:02.777'),
(3, 1, '123456789012347', 0, '2024-09-05 22:32:02.777'),
(4, 1, '123456789012348', 0, '2024-09-05 22:32:02.777');

INSERT INTO Tarjeta (Id_Tipo_Tarjeta, Id_Cuenta, Numero_Tarjeta, Fecha_Creacion)
VALUES
(3, 1, '4344 5478 4568 1245', '2024-09-01 22:34:37.673'),
(3, 2, '2457 1245 4578 8956', '2024-09-05 22:32:02.777'),
(3, 3, '2457 1245 4578 8957', '2024-09-05 22:32:02.777'),
(3, 4, '2457 1245 4578 8958', '2024-09-05 22:32:02.777');


