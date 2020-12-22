USE [db_clip]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[apellido] [varchar](30) NOT NULL,
	[dni] [int] NOT NULL,
	[email] [varchar](40) NOT NULL,
	[telefono] [varchar](18) NOT NULL,
	[cuil] [int] NULL,
	[direccion] [varchar](30) NULL,
	[nacionalidad] [varchar](20) NULL,
	[sexo] [varchar](15) NULL,
	[usuario] [varchar](16) NOT NULL,
	[clave] [varchar](16) NOT NULL,
	[situacion_crediticia] [varchar](30) NULL,
	[imagen] [image] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[num_de_cuenta] [int] NOT NULL,
	[tipo_de_cuenta] [varchar](30) NOT NULL,
	[estado_de_cuenta] [varchar](10) NOT NULL,
	[saldo] [money] NOT NULL,
	[cbu] [bigint] NOT NULL,
	[cvu] [bigint] NOT NULL,
	[id_cliente] [int] NOT NULL,
 CONSTRAINT [PK_cuenta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[operaciones]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[operaciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[origen] [bigint] NULL,
	[destino] [bigint] NULL,
	[monto] [money] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo] [varchar](15) NOT NULL,
	[id_cuenta] [int] NULL,
 CONSTRAINT [PK_operaciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id], [nombre], [apellido], [dni], [email], [telefono], [cuil], [direccion], [nacionalidad], [sexo], [usuario], [clave], [situacion_crediticia], [imagen]) VALUES (2, N'Fabricio', N'Blas', 40403744, N'fabricio@gmail.com', N'1284971', 2316387, N'aosidfjas', N'asdfasdf', N'asdfasd', N'asdfassa', N'asdfasdf', N'asdfasdf', NULL)
INSERT [dbo].[cliente] ([id], [nombre], [apellido], [dni], [email], [telefono], [cuil], [direccion], [nacionalidad], [sexo], [usuario], [clave], [situacion_crediticia], [imagen]) VALUES (3, N'Juan', N'Blasdfas', 40403744, N'asdfsa@gmail.com', N'12421', 116387, N'aosidfjas', N'asdfasdf', N'asdfasd', N'asdfassa', N'asdfasdf', N'asdfasdf', NULL)
INSERT [dbo].[cliente] ([id], [nombre], [apellido], [dni], [email], [telefono], [cuil], [direccion], [nacionalidad], [sexo], [usuario], [clave], [situacion_crediticia], [imagen]) VALUES (4, N'German', N'hjkuy', 40403744, N'hku@gmail.com', N'12421', 116387, N'xcv', N'rthr', N'wetrwet', N'vzxcv', N'zxcv', N'zxcvsd', NULL)
INSERT [dbo].[cliente] ([id], [nombre], [apellido], [dni], [email], [telefono], [cuil], [direccion], [nacionalidad], [sexo], [usuario], [clave], [situacion_crediticia], [imagen]) VALUES (5, N'Fabrici', N'Bla', 20892734, N'blasfabricio@gmail.com', N'3519873267', NULL, NULL, N'ARG', NULL, N'fablas', N'1234567', NULL, NULL)
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[cuenta] ON 

INSERT [dbo].[cuenta] ([id], [num_de_cuenta], [tipo_de_cuenta], [estado_de_cuenta], [saldo], [cbu], [cvu], [id_cliente]) VALUES (1, 12312, N'pesos', N'activo', 200.0000, 1230192, 1241298, 2)
INSERT [dbo].[cuenta] ([id], [num_de_cuenta], [tipo_de_cuenta], [estado_de_cuenta], [saldo], [cbu], [cvu], [id_cliente]) VALUES (3, 124123, N'pesos', N'activo', 123.0000, 12421, 1187, 3)
INSERT [dbo].[cuenta] ([id], [num_de_cuenta], [tipo_de_cuenta], [estado_de_cuenta], [saldo], [cbu], [cvu], [id_cliente]) VALUES (4, 756754, N'dolares', N'inactivo', 123.0000, 12421, 1187, 4)
INSERT [dbo].[cuenta] ([id], [num_de_cuenta], [tipo_de_cuenta], [estado_de_cuenta], [saldo], [cbu], [cvu], [id_cliente]) VALUES (7, 87345, N'pesos', N'activo', 5499.0000, 8764, 3467, 2)
INSERT [dbo].[cuenta] ([id], [num_de_cuenta], [tipo_de_cuenta], [estado_de_cuenta], [saldo], [cbu], [cvu], [id_cliente]) VALUES (9, 86456, N'dolares', N'inactivo', 420.0000, 8656734, 34557, 3)
INSERT [dbo].[cuenta] ([id], [num_de_cuenta], [tipo_de_cuenta], [estado_de_cuenta], [saldo], [cbu], [cvu], [id_cliente]) VALUES (10, 234545, N'pesos', N'inactivo', 6456.0000, 23565, 45323, 4)
SET IDENTITY_INSERT [dbo].[cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[operaciones] ON 

INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (3, 123123, 7567, 3545.0000, CAST(N'2020-09-30' AS Date), N'Extraccion', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (4, 123123, 7567, 3345.0000, CAST(N'2016-02-20' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (6, 765456, 2345, 5432.0000, CAST(N'2013-05-13' AS Date), N'Transaccion', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (7, 8665, 4345, 1231.0000, CAST(N'2010-04-20' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (8, 74545, 12345, 1509.0000, CAST(N'2020-09-11' AS Date), N'Giro', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (10, 64658, 234, 6543.0000, CAST(N'2020-04-20' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (11, 756456, 76532, 5234.0000, CAST(N'2020-09-26' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (12, 76456, 2345, 129.0000, CAST(N'2020-09-28' AS Date), N'Giro', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (13, 2345829, 12314, 2003.0000, CAST(N'2020-09-23' AS Date), N'Transaccion', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (14, NULL, NULL, 5000.0000, CAST(N'2020-10-07' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (15, NULL, NULL, 200.0000, CAST(N'2020-10-07' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (16, NULL, NULL, 200.0000, CAST(N'2020-10-07' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (17, NULL, NULL, 200.0000, CAST(N'2020-10-07' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (18, NULL, NULL, 200.0000, CAST(N'2020-10-07' AS Date), N'Ingreso', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (19, NULL, NULL, 200.0000, CAST(N'2020-10-07' AS Date), N'Extraccion', NULL)
INSERT [dbo].[operaciones] ([id], [origen], [destino], [monto], [fecha], [tipo], [id_cuenta]) VALUES (20, NULL, NULL, 200.0000, CAST(N'2020-10-07' AS Date), N'Extraccion', NULL)
SET IDENTITY_INSERT [dbo].[operaciones] OFF
GO
ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[cuenta] CHECK CONSTRAINT [FK_cuenta_cliente]
GO
ALTER TABLE [dbo].[operaciones]  WITH CHECK ADD  CONSTRAINT [FK_operaciones_cuenta] FOREIGN KEY([id_cuenta])
REFERENCES [dbo].[cuenta] ([id])
GO
ALTER TABLE [dbo].[operaciones] CHECK CONSTRAINT [FK_operaciones_cuenta]
GO
/****** Object:  StoredProcedure [dbo].[actualizar_cliente]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[actualizar_cliente] 
	-- Add the parameters for the stored procedure here
	@id int,
	@nombre varchar(30),
	@apellido varchar(30),
	@dni int,
	@email varchar(40),
	@telefono varchar(18),
	@cuil int,
	@direccion varchar(30),
	@nacionalidad varchar(20),
	@sexo varchar(15),
	@usuario varchar(16),
	@situacion_crediticia varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE cliente 
		   SET nombre = @nombre,
			   apellido = @apellido,
			   dni = @dni,
			   email = @email,
			   telefono = @telefono,
			   cuil = @cuil,
			   direccion = @direccion,
			   nacionalidad = @nacionalidad,
			   sexo = @sexo,
			   usuario = @usuario,
			   situacion_crediticia = @situacion_crediticia
		   WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[depositar_saldo]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[depositar_saldo]

@monto money, @id_cuenta int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    

	INSERT INTO operaciones (monto,fecha,tipo) VALUES (@monto,GETDATE(),'Ingreso') 

	UPDATE [dbo].[cuenta] 
	SET [saldo] = saldo + @monto
	WHERE id = @id_cuenta

	DECLARE @id_operacion int
	SET @id_operacion = (SELECT MAX(id) FROM operaciones)

	INSERT INTO detalle_de_cuenta (id_cuenta,id_operacion) VALUES (@id_cuenta, @id_operacion)
END
GO
/****** Object:  StoredProcedure [dbo].[extraer_saldo]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[extraer_saldo] 

	@monto money, @id_cuenta int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	INSERT INTO operaciones (monto,fecha,tipo) VALUES (@monto,GETDATE(),'Extraccion') 

	UPDATE [dbo].[cuenta] 
	SET [saldo] = saldo - @monto
	WHERE id = @id_cuenta

	DECLARE @id_operacion int
	SET @id_operacion = (SELECT MAX(id) FROM operaciones)

	INSERT INTO detalle_de_cuenta (id_cuenta,id_operacion) VALUES (@id_cuenta, @id_operacion)
END

GO
/****** Object:  StoredProcedure [dbo].[lista_ultimos_movimientos]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[lista_ultimos_movimientos]
	
	@id_cuenta int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT TOP 10 * 
	FROM detalle_de_cuenta 
	WHERE id_cuenta = @id_cuenta ORDER BY id_operacion DESC 

END
GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[login] 
	-- Add the parameters for the stored procedure here
	@usuario varchar(16),
	@contraseña varchar(16)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id FROM cliente WHERE usuario =  @usuario AND clave = @contraseña
END
GO
/****** Object:  StoredProcedure [dbo].[nuevo_cliente]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[nuevo_cliente] 
	@nombre varchar(30),
	@apellido varchar(30),
	@dni int,
	@email varchar(40),
	@telefono varchar(18),
	@usuario varchar(16),
	@clave varchar(16),
	@image image
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO cliente (nombre,apellido,dni,email,telefono,usuario,clave,imagen) 
		   VALUES (@nombre,@apellido,@dni,@email,@telefono,@usuario,@clave,@image)
END
GO
/****** Object:  StoredProcedure [dbo].[obtener_cliente]    Script Date: 21/12/2020 21:38:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[obtener_cliente]
	-- Add the parameters for the stored procedure here
	@usuario varchar(16)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT nombre,apellido,dni,email,telefono,usuario FROM cliente WHERE (usuario = @usuario)
END
GO
