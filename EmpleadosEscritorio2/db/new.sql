USE [master]
GO
/****** Object:  Database [empleado_bd]    Script Date: 29/11/2021 11:04:51 p. m. ******/
CREATE DATABASE [empleado_bd]; 




USE [empleado_bd];
/****** Object:  Table [dbo].[tb_empleados]    Script Date: 29/11/2021 11:04:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_empleados](
	[documento] [nvarchar](15) NOT NULL,
	[nombres] [nvarchar](100) NOT NULL,
	[apellidos] [nvarchar](100) NOT NULL,
	[edad] [int] NOT NULL,
	[direccion] [nvarchar](100) NULL,
	[fecha_nacimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_empleados] ([documento], [nombres], [apellidos], [edad], [direccion], [fecha_nacimiento]) VALUES (N'11111', N'Cristian', N'serna', 25, N'calle 34', CAST(N'1998-12-23' AS Date))
GO
INSERT [dbo].[tb_empleados] ([documento], [nombres], [apellidos], [edad], [direccion], [fecha_nacimiento]) VALUES (N'6666666', N'CAMILA', N'PEREZ', 47, N'CALLE 56', CAST(N'2021-11-25' AS Date))
GO
USE [master]
GO
ALTER DATABASE [empleado_bd] SET  READ_WRITE 
GO



