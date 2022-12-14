USE [master]
GO
/****** Object:  Database [BD_BluLogistics]    Script Date: 28/09/2022 16:05:02 ******/
CREATE DATABASE [BD_BluLogistics]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_Viajemos.com', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\BD_Viajemos.com.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_Viajemos.com_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\BD_Viajemos.com_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BD_BluLogistics] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_BluLogistics].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_BluLogistics] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_BluLogistics] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_BluLogistics] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_BluLogistics] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_BluLogistics] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_BluLogistics] SET  MULTI_USER 
GO
ALTER DATABASE [BD_BluLogistics] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_BluLogistics] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_BluLogistics] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_BluLogistics] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_BluLogistics] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_BluLogistics] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD_BluLogistics', N'ON'
GO
ALTER DATABASE [BD_BluLogistics] SET QUERY_STORE = OFF
GO
USE [BD_BluLogistics]
GO
/****** Object:  Table [dbo].[autores]    Script Date: 28/09/2022 16:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores](
	[autoresID] [uniqueidentifier] NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[apellidos] [varchar](45) NOT NULL,
 CONSTRAINT [PK_autores_1] PRIMARY KEY CLUSTERED 
(
	[autoresID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[autores_has_libros]    Script Date: 28/09/2022 16:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores_has_libros](
	[autores_has_librosID] [uniqueidentifier] NOT NULL,
	[autoresID] [uniqueidentifier] NOT NULL,
	[librosID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_autores_has_libros] PRIMARY KEY CLUSTERED 
(
	[autores_has_librosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[editoriales]    Script Date: 28/09/2022 16:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[editoriales](
	[editorialesID] [uniqueidentifier] NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[sede] [varchar](45) NULL,
 CONSTRAINT [PK_editoriales_1] PRIMARY KEY CLUSTERED 
(
	[editorialesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libros]    Script Date: 28/09/2022 16:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libros](
	[librosID] [uniqueidentifier] NOT NULL,
	[editorialesID] [uniqueidentifier] NOT NULL,
	[tittulo] [varchar](45) NOT NULL,
	[sinopsis] [text] NULL,
	[nPaginas] [varchar](45) NULL,
 CONSTRAINT [PK_libros_1] PRIMARY KEY CLUSTERED 
(
	[librosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[autores] ([autoresID], [nombre], [apellidos]) VALUES (N'207c86b9-ad53-42fc-ba8e-19cc6db37cfc', N'Esteban', N'Torres')
INSERT [dbo].[autores] ([autoresID], [nombre], [apellidos]) VALUES (N'c7c2fbd0-bf21-4ab5-8a25-468bc3cd007f', N'Elizabeth', N'Porras')
INSERT [dbo].[autores] ([autoresID], [nombre], [apellidos]) VALUES (N'10d91e80-7dac-402b-82e3-4a3e351f434c', N'Julio', N'Torres')
INSERT [dbo].[autores] ([autoresID], [nombre], [apellidos]) VALUES (N'4a9f3728-703f-4a90-8fc2-ac02d729479b', N'Ana', N'Torres')
INSERT [dbo].[autores] ([autoresID], [nombre], [apellidos]) VALUES (N'6f9c8886-998c-463d-aa1c-b152bbcd3b30', N'Angie', N'Cardozo')
GO
INSERT [dbo].[autores_has_libros] ([autores_has_librosID], [autoresID], [librosID]) VALUES (N'f16900b8-a04e-46ea-9208-6b8c4cb83bc6', N'6f9c8886-998c-463d-aa1c-b152bbcd3b30', N'8cb73adf-407c-4ab2-b95c-465e9f8de9f7')
INSERT [dbo].[autores_has_libros] ([autores_has_librosID], [autoresID], [librosID]) VALUES (N'453ba207-102c-42bc-8038-6d88580c367c', N'207c86b9-ad53-42fc-ba8e-19cc6db37cfc', N'fcb4de9d-8c3d-46a1-88da-27c3b9040d0b')
INSERT [dbo].[autores_has_libros] ([autores_has_librosID], [autoresID], [librosID]) VALUES (N'607d6bef-95c4-47d0-8578-8b3a012e85bb', N'207c86b9-ad53-42fc-ba8e-19cc6db37cfc', N'8df4b5ce-1e80-4da4-b3c7-64071e628528')
GO
INSERT [dbo].[editoriales] ([editorialesID], [nombre], [sede]) VALUES (N'1003398a-ad07-429d-b8c7-0100cb5580dd', N'Editorial3', N'Bogotá')
INSERT [dbo].[editoriales] ([editorialesID], [nombre], [sede]) VALUES (N'3a0eae84-55e7-41d8-9797-098916c1a384', N'Editorial2', N'Bogotá')
INSERT [dbo].[editoriales] ([editorialesID], [nombre], [sede]) VALUES (N'b4255954-853c-46f1-8499-60a992b4f822', N'Editorial4', N'Cartagena')
INSERT [dbo].[editoriales] ([editorialesID], [nombre], [sede]) VALUES (N'0a64f64f-77c2-4312-8f2f-e955d95b0e9f', N'Editorial1', N'Bogotá')
GO
INSERT [dbo].[libros] ([librosID], [editorialesID], [tittulo], [sinopsis], [nPaginas]) VALUES (N'fcb4de9d-8c3d-46a1-88da-27c3b9040d0b', N'0a64f64f-77c2-4312-8f2f-e955d95b0e9f', N'Librito2', N'libro 2', N'60')
INSERT [dbo].[libros] ([librosID], [editorialesID], [tittulo], [sinopsis], [nPaginas]) VALUES (N'8cb73adf-407c-4ab2-b95c-465e9f8de9f7', N'3a0eae84-55e7-41d8-9797-098916c1a384', N'Librito3', N'Libro 3', N'70')
INSERT [dbo].[libros] ([librosID], [editorialesID], [tittulo], [sinopsis], [nPaginas]) VALUES (N'8df4b5ce-1e80-4da4-b3c7-64071e628528', N'0a64f64f-77c2-4312-8f2f-e955d95b0e9f', N'Librito1', N'libro 1', N'50')
GO
ALTER TABLE [dbo].[autores_has_libros]  WITH CHECK ADD  CONSTRAINT [FK_autores_has_libros_autores] FOREIGN KEY([autoresID])
REFERENCES [dbo].[autores] ([autoresID])
GO
ALTER TABLE [dbo].[autores_has_libros] CHECK CONSTRAINT [FK_autores_has_libros_autores]
GO
ALTER TABLE [dbo].[autores_has_libros]  WITH CHECK ADD  CONSTRAINT [FK_autores_has_libros_libros] FOREIGN KEY([librosID])
REFERENCES [dbo].[libros] ([librosID])
GO
ALTER TABLE [dbo].[autores_has_libros] CHECK CONSTRAINT [FK_autores_has_libros_libros]
GO
ALTER TABLE [dbo].[libros]  WITH CHECK ADD  CONSTRAINT [FK_libros_editoriales] FOREIGN KEY([editorialesID])
REFERENCES [dbo].[editoriales] ([editorialesID])
GO
ALTER TABLE [dbo].[libros] CHECK CONSTRAINT [FK_libros_editoriales]
GO
USE [master]
GO
ALTER DATABASE [BD_BluLogistics] SET  READ_WRITE 
GO
