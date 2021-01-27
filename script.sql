USE [master]
GO
/****** Object:  Database [db_clip]    Script Date: 25/1/2021 22:15:32 ******/
CREATE DATABASE [db_clip]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_clip', FILENAME = N'f:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_clip.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_clip_log', FILENAME = N'f:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_clip_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_clip] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_clip].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_clip] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_clip] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_clip] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_clip] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_clip] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_clip] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_clip] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_clip] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_clip] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_clip] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_clip] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_clip] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_clip] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_clip] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_clip] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_clip] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_clip] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_clip] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_clip] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_clip] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_clip] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_clip] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_clip] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_clip] SET  MULTI_USER 
GO
ALTER DATABASE [db_clip] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_clip] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_clip] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_clip] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_clip] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_clip] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_clip] SET QUERY_STORE = OFF
GO
USE [db_clip]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[apellido] [varchar](30) NOT NULL,
	[dni] [int] NULL,
	[email] [varchar](40) NOT NULL,
	[telefono] [varchar](18) NOT NULL,
	[cuil] [int] NULL,
	[direccion] [varchar](30) NULL,
	[nacionalidad] [varchar](20) NULL,
	[sexo] [varchar](15) NULL,
	[usuario] [varchar](16) NOT NULL,
	[clave] [varchar](100) NOT NULL,
	[situacion_crediticia] [varchar](30) NULL,
	[doc_img] [ntext] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[num_de_cuenta] [varchar](19) NOT NULL,
	[tipo_de_cuenta] [varchar](30) NOT NULL,
	[estado_de_cuenta] [varchar](10) NOT NULL,
	[saldo] [money] NOT NULL,
	[cbu] [varchar](22) NOT NULL,
	[cvu] [varchar](22) NOT NULL,
	[id_cliente] [int] NOT NULL,
 CONSTRAINT [PK_cuenta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[operaciones]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[operaciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[origen] [varchar](22) NULL,
	[destino] [varchar](22) NULL,
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
/****** Object:  StoredProcedure [dbo].[actualizar_cliente]    Script Date: 25/1/2021 22:15:32 ******/
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
	@email varchar(40),
	@telefono varchar(18),
	@usuario varchar(16)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE cliente 
		   SET nombre = @nombre,
			   apellido = @apellido,
			   email = @email,
			   telefono = @telefono,
			   usuario = @usuario	   
		   WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[cargar_documento]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargar_documento] 
	@id int,
	@image ntext
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	UPDATE cliente 
	SET doc_img = @image
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[depositar_saldo]    Script Date: 25/1/2021 22:15:32 ******/
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

    

	INSERT INTO operaciones (monto,fecha,tipo,id_cuenta) VALUES (@monto,GETDATE(),'Ingreso',@id_cuenta) 

	UPDATE [dbo].[cuenta] 
	SET [saldo] = saldo + @monto
	WHERE id = @id_cuenta

	DECLARE @id_operacion int
	SET @id_operacion = (SELECT MAX(id) FROM operaciones)

	
END
GO
/****** Object:  StoredProcedure [dbo].[existe_documento]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[existe_documento] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 doc_img FROM cliente WHERE id =  @id 
END
GO
/****** Object:  StoredProcedure [dbo].[extraer_saldo]    Script Date: 25/1/2021 22:15:32 ******/
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


	INSERT INTO operaciones (monto,fecha,tipo,id_cuenta) VALUES (@monto,GETDATE(),'Extraccion',@id_cuenta) 

	UPDATE [dbo].[cuenta] 
	SET [saldo] = saldo - @monto
	WHERE id = @id_cuenta

	DECLARE @id_operacion int
	SET @id_operacion = (SELECT MAX(id) FROM operaciones)

	
END

GO
/****** Object:  StoredProcedure [dbo].[giro_al_descubierto]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[giro_al_descubierto]
@monto money, @id_cuenta int
	
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO operaciones (monto,fecha,tipo,id_cuenta) VALUES (@monto,GETDATE(),'Giro_Desc',@id_cuenta) 

	UPDATE [dbo].[cuenta] 
	SET [saldo] = saldo - @monto
	WHERE id = @id_cuenta

	DECLARE @id_operacion int
	SET @id_operacion = (SELECT MAX(id) FROM operaciones)
   
END
GO
/****** Object:  StoredProcedure [dbo].[lista_ultimos_movimientos]    Script Date: 25/1/2021 22:15:32 ******/
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
	FROM operaciones
	WHERE id_cuenta = @id_cuenta  ORDER BY id DESC 

END
GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 25/1/2021 22:15:32 ******/
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
	@contraseña varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id FROM cliente WHERE usuario =  @usuario AND clave = @contraseña
END
GO
/****** Object:  StoredProcedure [dbo].[nueva_cuenta]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[nueva_cuenta] 
	@Num_de_cuenta varchar(19),
	@Tipo_de_cuenta varchar(30),
	@Estado_de_cuenta varchar(10),
	@Saldo money,
	@Cbu varchar(22),
	@Cvu varchar(22),
	@Id_cliente int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO cuenta (num_de_cuenta,tipo_de_cuenta,estado_de_cuenta,saldo,cbu,cvu,id_cliente) 
		   VALUES (@Num_de_cuenta,@Tipo_de_cuenta,@Estado_de_cuenta,@Saldo,@Cbu,@Cvu,@Id_cliente)
END
GO
/****** Object:  StoredProcedure [dbo].[nuevo_cliente]    Script Date: 25/1/2021 22:15:32 ******/
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
	@clave varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO cliente (nombre,apellido,dni,email,telefono,usuario,clave) 
		   VALUES (@nombre,@apellido,@dni,@email,@telefono,@usuario,@clave)
END
GO
/****** Object:  StoredProcedure [dbo].[obtener_cliente]    Script Date: 25/1/2021 22:15:32 ******/
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
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM cliente WHERE (id = @id)
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerDatos_cuenta]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[obtenerDatos_cuenta]
	@id_cuenta  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,num_de_cuenta,tipo_de_cuenta,estado_de_cuenta,saldo,cbu,cvu,id_cliente from cuenta where id_cliente = @id_cuenta
                    
                     
                   
                   
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerDatos_cuenta2]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[obtenerDatos_cuenta2]
	@id_cuenta  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,num_de_cuenta,tipo_de_cuenta,estado_de_cuenta,saldo,cbu,cvu,id_cliente from cuenta where id = @id_cuenta
                    
          
END
GO
/****** Object:  StoredProcedure [dbo].[realizar_transferencia]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[realizar_transferencia] 
	 @id_cuenta int, @id_cuentadestino int, @monto money, @cbu_origen varchar(22), @cbu_destino varchar(22)
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO operaciones (monto,fecha,tipo,id_cuenta,origen,destino) VALUES (@monto,GETDATE(),'Transferencia',@id_cuenta,@cbu_origen,@cbu_destino) 
    INSERT INTO operaciones (monto,fecha,tipo,id_cuenta,origen,destino) VALUES (@monto,GETDATE(),'Transferencia',@id_cuentadestino,@cbu_origen,@cbu_destino) 
	UPDATE [dbo].[cuenta] 
	SET [saldo] = saldo - @monto
	WHERE id = @id_cuenta


	UPDATE [dbo].[cuenta] 
	SET [saldo] = saldo + @monto
	WHERE id = @id_cuentadestino

    
END
GO
/****** Object:  StoredProcedure [dbo].[restablecer_contraseña]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[restablecer_contraseña] 
	-- Add the parameters for the stored procedure here
	@id int,
	@contraseña varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE cliente SET clave = @contraseña  WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[verificar_cuenta_destino]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[verificar_cuenta_destino]
	@cbu_destino varchar(22)
AS
BEGIN
	
	SET NOCOUNT ON;

   SELECT id,tipo_de_cuenta, estado_de_cuenta FROM cuenta WHERE (cbu = @cbu_destino) and (tipo_de_cuenta = 'pesos')
END
GO
/****** Object:  StoredProcedure [dbo].[verificar_saldo]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[verificar_saldo]
	@id_cuenta int
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT saldo, estado_de_cuenta FROM cuenta WHERE (id = @id_cuenta)
END
GO
/****** Object:  StoredProcedure [dbo].[verificar_usuario]    Script Date: 25/1/2021 22:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[verificar_usuario]
	-- Add the parameters for the stored procedure here
	@usuario varchar(16),
	@email varchar(40)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 id FROM cliente WHERE usuario =  @usuario OR email =  @email
END
GO
USE [master]
GO
ALTER DATABASE [db_clip] SET  READ_WRITE 
GO
