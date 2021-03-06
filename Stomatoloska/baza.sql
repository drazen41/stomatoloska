USE [stomatoloska]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tNarudzba_tZahvat]') AND parent_object_id = OBJECT_ID(N'[dbo].[tNarudzba]'))
ALTER TABLE [dbo].[tNarudzba] DROP CONSTRAINT [FK_tNarudzba_tZahvat]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tNarudzba_tPacijent]') AND parent_object_id = OBJECT_ID(N'[dbo].[tNarudzba]'))
ALTER TABLE [dbo].[tNarudzba] DROP CONSTRAINT [FK_tNarudzba_tPacijent]
GO
/****** Object:  Index [ix_sifra_uq]    Script Date: 22.10.2018. 13:45:12 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND name = N'ix_sifra_uq')
DROP INDEX [ix_sifra_uq] ON [dbo].[tZahvat]
GO
/****** Object:  Table [dbo].[tZahvat]    Script Date: 22.10.2018. 13:45:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND type in (N'U'))
DROP TABLE [dbo].[tZahvat]
GO
/****** Object:  Table [dbo].[tRadnoVrijeme]    Script Date: 22.10.2018. 13:45:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tRadnoVrijeme]') AND type in (N'U'))
DROP TABLE [dbo].[tRadnoVrijeme]
GO
/****** Object:  Table [dbo].[tPacijent]    Script Date: 22.10.2018. 13:45:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tPacijent]') AND type in (N'U'))
DROP TABLE [dbo].[tPacijent]
GO
/****** Object:  Table [dbo].[tNarudzba]    Script Date: 22.10.2018. 13:45:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tNarudzba]') AND type in (N'U'))
DROP TABLE [dbo].[tNarudzba]
GO
/****** Object:  User [test]    Script Date: 22.10.2018. 13:45:12 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'test')
DROP USER [test]
GO
USE [master]
GO
/****** Object:  Database [stomatoloska]    Script Date: 22.10.2018. 13:45:12 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'stomatoloska')
DROP DATABASE [stomatoloska]
GO
/****** Object:  Database [stomatoloska]    Script Date: 22.10.2018. 13:45:12 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'stomatoloska')
BEGIN
CREATE DATABASE [stomatoloska] ON  PRIMARY 
( NAME = N'stomatoloska', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\stomatoloska.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'stomatoloska_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\stomatoloska_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
ALTER DATABASE [stomatoloska] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [stomatoloska].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [stomatoloska] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [stomatoloska] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [stomatoloska] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [stomatoloska] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [stomatoloska] SET ARITHABORT OFF 
GO
ALTER DATABASE [stomatoloska] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [stomatoloska] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [stomatoloska] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [stomatoloska] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [stomatoloska] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [stomatoloska] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [stomatoloska] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [stomatoloska] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [stomatoloska] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [stomatoloska] SET  DISABLE_BROKER 
GO
ALTER DATABASE [stomatoloska] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [stomatoloska] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [stomatoloska] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [stomatoloska] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [stomatoloska] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [stomatoloska] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [stomatoloska] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [stomatoloska] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [stomatoloska] SET  MULTI_USER 
GO
ALTER DATABASE [stomatoloska] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [stomatoloska] SET DB_CHAINING OFF 
GO
USE [stomatoloska]
GO
/****** Object:  User [test]    Script Date: 22.10.2018. 13:45:12 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'test')
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[tNarudzba]    Script Date: 22.10.2018. 13:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tNarudzba]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tNarudzba](
	[narudzba_id] [int] IDENTITY(1,1) NOT NULL,
	[termin_pocetak] [datetime] NOT NULL,
	[termin_kraj] [datetime] NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[pacijent_id] [int] NOT NULL,
	[zahvat_id] [int] NOT NULL,
	[dcr] [datetime] NOT NULL,
 CONSTRAINT [PK_tNarudzba] PRIMARY KEY CLUSTERED 
(
	[narudzba_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tPacijent]    Script Date: 22.10.2018. 13:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tPacijent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tPacijent](
	[pacijent_id] [int] IDENTITY(1,1) NOT NULL,
	[prezime] [nvarchar](50) NOT NULL,
	[ime] [nvarchar](50) NOT NULL,
	[datum_rodjenja] [date] NOT NULL,
	[telefon] [nvarchar](50) NOT NULL,
	[adresa] [nvarchar](50) NULL,
 CONSTRAINT [PK_tPacijent] PRIMARY KEY CLUSTERED 
(
	[pacijent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tRadnoVrijeme]    Script Date: 22.10.2018. 13:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tRadnoVrijeme]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tRadnoVrijeme](
	[radno_vrijeme_id] [int] IDENTITY(1,1) NOT NULL,
	[radni_dan] [nvarchar](50) NOT NULL,
	[pocetak] [time](0) NOT NULL,
	[kraj] [time](0) NOT NULL,
	[dcr] [datetime] NOT NULL,
 CONSTRAINT [PK_tRadnoVrijeme] PRIMARY KEY CLUSTERED 
(
	[radno_vrijeme_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tZahvat]    Script Date: 22.10.2018. 13:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tZahvat](
	[zahvat_id] [int] IDENTITY(1,1) NOT NULL,
	[sifra] [nvarchar](10) NOT NULL,
	[naziv] [nvarchar](200) NOT NULL,
	[cijena] [decimal](9, 2) NOT NULL,
	[trajanje_minuta] [int] NOT NULL,
	[dcr] [datetime] NOT NULL,
 CONSTRAINT [PK_tZahvat_1] PRIMARY KEY CLUSTERED 
(
	[zahvat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tNarudzba] ON 

GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (1, CAST(N'2018-10-18 09:00:00.000' AS DateTime), CAST(N'2018-10-18 11:00:00.000' AS DateTime), N'Izvrsena', 14, 12, CAST(N'2018-10-18 10:44:10.567' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (2, CAST(N'2018-10-18 11:30:00.000' AS DateTime), CAST(N'2018-10-18 12:00:00.000' AS DateTime), N'Izvrsena', 11, 15, CAST(N'2018-10-18 10:44:56.247' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (3, CAST(N'2018-10-18 13:00:00.000' AS DateTime), CAST(N'2018-10-18 14:00:00.000' AS DateTime), N'NijeDosao', 10, 3, CAST(N'2018-10-18 10:45:19.130' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (4, CAST(N'2018-10-18 14:00:00.000' AS DateTime), CAST(N'2018-10-18 15:00:00.000' AS DateTime), N'NijeDosao', 13, 8, CAST(N'2018-10-18 10:45:32.890' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (5, CAST(N'2018-10-19 08:30:00.000' AS DateTime), CAST(N'2018-10-19 09:00:00.000' AS DateTime), N'NijeDosao', 9, 7, CAST(N'2018-10-18 10:46:20.817' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (6, CAST(N'2018-10-22 08:00:00.000' AS DateTime), CAST(N'2018-10-22 08:30:00.000' AS DateTime), N'Kreirana', 9, 14, CAST(N'2018-10-18 10:46:37.690' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (7, CAST(N'2018-10-19 09:00:00.000' AS DateTime), CAST(N'2018-10-19 10:00:00.000' AS DateTime), N'NijeDosao', 12, 8, CAST(N'2018-10-18 10:46:56.570' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (8, CAST(N'2018-10-19 10:00:00.000' AS DateTime), CAST(N'2018-10-19 11:00:00.000' AS DateTime), N'Izvrsena', 14, 8, CAST(N'2018-10-18 10:47:16.443' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (9, CAST(N'2018-10-19 11:00:00.000' AS DateTime), CAST(N'2018-10-19 12:00:00.000' AS DateTime), N'Greska', 11, 8, CAST(N'2018-10-18 10:47:28.097' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (10, CAST(N'2018-10-19 12:30:00.000' AS DateTime), CAST(N'2018-10-19 13:30:00.000' AS DateTime), N'Izvrsena', 10, 8, CAST(N'2018-10-18 10:51:50.087' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (11, CAST(N'2018-10-22 08:30:00.000' AS DateTime), CAST(N'2018-10-22 10:30:00.000' AS DateTime), N'Kreirana', 10, 4, CAST(N'2018-10-18 10:53:02.867' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (12, CAST(N'2018-10-22 11:00:00.000' AS DateTime), CAST(N'2018-10-22 13:00:00.000' AS DateTime), N'Kreirana', 13, 4, CAST(N'2018-10-18 10:53:12.313' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (13, CAST(N'2018-10-22 13:00:00.000' AS DateTime), CAST(N'2018-10-22 14:00:00.000' AS DateTime), N'Greska', 9, 6, CAST(N'2018-10-18 10:53:33.273' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (14, CAST(N'2018-10-15 08:30:00.000' AS DateTime), CAST(N'2018-10-15 09:30:00.000' AS DateTime), N'Izvrsena', 15, 16, CAST(N'2018-10-18 12:43:30.973' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (15, CAST(N'2018-10-15 10:00:00.000' AS DateTime), CAST(N'2018-10-15 10:30:00.000' AS DateTime), N'Izvrsena', 14, 7, CAST(N'2018-10-18 12:46:07.233' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (18, CAST(N'2018-10-17 09:00:00.000' AS DateTime), CAST(N'2018-10-17 11:00:00.000' AS DateTime), N'Izvrsena', 11, 11, CAST(N'2018-10-18 12:48:26.197' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (19, CAST(N'2018-10-17 11:30:00.000' AS DateTime), CAST(N'2018-10-17 13:30:00.000' AS DateTime), N'Izvrsena', 10, 11, CAST(N'2018-10-18 12:48:38.613' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (20, CAST(N'2018-10-16 08:00:00.000' AS DateTime), CAST(N'2018-10-16 10:00:00.000' AS DateTime), N'Izvrsena', 13, 4, CAST(N'2018-10-18 12:48:55.147' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (21, CAST(N'2018-10-16 10:00:00.000' AS DateTime), CAST(N'2018-10-16 12:00:00.000' AS DateTime), N'Izvrsena', 9, 5, CAST(N'2018-10-18 12:49:15.553' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (22, CAST(N'2018-10-16 12:00:00.000' AS DateTime), CAST(N'2018-10-16 13:00:00.000' AS DateTime), N'NijeDosao', 12, 16, CAST(N'2018-10-18 12:50:10.647' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (23, CAST(N'2018-10-15 09:30:00.000' AS DateTime), CAST(N'2018-10-15 10:00:00.000' AS DateTime), N'NijeDosao', 12, 13, CAST(N'2018-10-18 12:50:35.390' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (24, CAST(N'2018-10-08 08:00:00.000' AS DateTime), CAST(N'2018-10-08 10:00:00.000' AS DateTime), N'Izvrsena', 15, 12, CAST(N'2018-10-19 09:52:32.597' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (25, CAST(N'2018-10-09 08:30:00.000' AS DateTime), CAST(N'2018-10-09 09:00:00.000' AS DateTime), N'Izvrsena', 15, 18, CAST(N'2018-10-19 09:52:48.870' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (26, CAST(N'2018-10-10 09:00:00.000' AS DateTime), CAST(N'2018-10-10 11:00:00.000' AS DateTime), N'Izvrsena', 15, 5, CAST(N'2018-10-19 09:53:00.767' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (27, CAST(N'2018-10-11 11:30:00.000' AS DateTime), CAST(N'2018-10-11 13:30:00.000' AS DateTime), N'Izvrsena', 15, 9, CAST(N'2018-10-19 09:53:09.363' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (28, CAST(N'2018-10-12 10:00:00.000' AS DateTime), CAST(N'2018-10-12 11:00:00.000' AS DateTime), N'Izvrsena', 15, 3, CAST(N'2018-10-19 09:53:23.337' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (29, CAST(N'2018-10-08 10:00:00.000' AS DateTime), CAST(N'2018-10-08 11:00:00.000' AS DateTime), N'Izvrsena', 14, 16, CAST(N'2018-10-19 10:14:35.970' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (30, CAST(N'2018-10-09 09:00:00.000' AS DateTime), CAST(N'2018-10-09 09:30:00.000' AS DateTime), N'Izvrsena', 14, 7, CAST(N'2018-10-19 10:15:08.787' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (31, CAST(N'2018-10-10 11:00:00.000' AS DateTime), CAST(N'2018-10-10 12:00:00.000' AS DateTime), N'Izvrsena', 14, 8, CAST(N'2018-10-19 10:15:26.963' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (32, CAST(N'2018-10-11 13:30:00.000' AS DateTime), CAST(N'2018-10-11 14:00:00.000' AS DateTime), N'Izvrsena', 14, 14, CAST(N'2018-10-19 10:15:38.530' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (33, CAST(N'2018-10-12 08:30:00.000' AS DateTime), CAST(N'2018-10-12 09:00:00.000' AS DateTime), N'Izvrsena', 14, 15, CAST(N'2018-10-19 10:15:55.723' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (34, CAST(N'2018-10-08 11:00:00.000' AS DateTime), CAST(N'2018-10-08 13:00:00.000' AS DateTime), N'Izvrsena', 11, 12, CAST(N'2018-10-19 10:22:54.350' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (35, CAST(N'2018-10-09 09:30:00.000' AS DateTime), CAST(N'2018-10-09 11:30:00.000' AS DateTime), N'NijeDosao', 11, 11, CAST(N'2018-10-19 10:23:45.950' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (36, CAST(N'2018-10-10 12:00:00.000' AS DateTime), CAST(N'2018-10-10 14:00:00.000' AS DateTime), N'Izvrsena', 11, 9, CAST(N'2018-10-19 10:24:00.940' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (37, CAST(N'2018-10-11 14:00:00.000' AS DateTime), CAST(N'2018-10-11 14:30:00.000' AS DateTime), N'NijeDosao', 11, 10, CAST(N'2018-10-19 10:24:08.520' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (38, CAST(N'2018-10-12 11:00:00.000' AS DateTime), CAST(N'2018-10-12 11:30:00.000' AS DateTime), N'NijeDosao', 11, 14, CAST(N'2018-10-19 10:24:23.197' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (39, CAST(N'2018-10-08 13:00:00.000' AS DateTime), CAST(N'2018-10-08 13:30:00.000' AS DateTime), N'Izvrsena', 10, 14, CAST(N'2018-10-19 10:37:28.127' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (40, CAST(N'2018-10-09 11:30:00.000' AS DateTime), CAST(N'2018-10-09 12:30:00.000' AS DateTime), N'Izvrsena', 10, 16, CAST(N'2018-10-19 10:37:44.477' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (41, CAST(N'2018-10-10 14:00:00.000' AS DateTime), CAST(N'2018-10-10 15:00:00.000' AS DateTime), N'NijeDosao', 10, 3, CAST(N'2018-10-19 10:37:53.967' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (42, CAST(N'2018-10-11 09:30:00.000' AS DateTime), CAST(N'2018-10-11 10:30:00.000' AS DateTime), N'NijeDosao', 10, 8, CAST(N'2018-10-19 10:38:09.783' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (43, CAST(N'2018-10-12 11:30:00.000' AS DateTime), CAST(N'2018-10-12 13:30:00.000' AS DateTime), N'NijeDosao', 10, 4, CAST(N'2018-10-19 10:38:19.537' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (44, CAST(N'2018-10-08 13:30:00.000' AS DateTime), CAST(N'2018-10-08 14:00:00.000' AS DateTime), N'NijeDosao', 13, 13, CAST(N'2018-10-19 10:42:01.287' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (45, CAST(N'2018-10-09 12:30:00.000' AS DateTime), CAST(N'2018-10-09 14:30:00.000' AS DateTime), N'Izvrsena', 13, 12, CAST(N'2018-10-19 10:42:18.010' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (46, CAST(N'2018-10-11 10:30:00.000' AS DateTime), CAST(N'2018-10-11 11:00:00.000' AS DateTime), N'NijeDosao', 13, 18, CAST(N'2018-10-19 10:42:36.063' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (47, CAST(N'2018-10-15 10:30:00.000' AS DateTime), CAST(N'2018-10-15 11:30:00.000' AS DateTime), N'NijeDosao', 11, 3, CAST(N'2018-10-19 12:32:58.583' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (49, CAST(N'2018-10-15 11:30:00.000' AS DateTime), CAST(N'2018-10-15 12:30:00.000' AS DateTime), N'NijeDosao', 10, 8, CAST(N'2018-10-19 12:33:41.133' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (50, CAST(N'2018-10-16 13:00:00.000' AS DateTime), CAST(N'2018-10-16 14:00:00.000' AS DateTime), N'NijeDosao', 10, 16, CAST(N'2018-10-19 12:33:58.627' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (51, CAST(N'2018-10-15 12:30:00.000' AS DateTime), CAST(N'2018-10-15 13:30:00.000' AS DateTime), N'NijeDosao', 13, 16, CAST(N'2018-10-19 12:34:15.490' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (52, CAST(N'2018-10-22 13:00:00.000' AS DateTime), CAST(N'2018-10-22 13:30:00.000' AS DateTime), N'Kreirana', 15, 1, CAST(N'2018-10-22 09:25:24.823' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (53, CAST(N'2018-10-23 08:30:00.000' AS DateTime), CAST(N'2018-10-23 09:00:00.000' AS DateTime), N'Kreirana', 15, 15, CAST(N'2018-10-22 09:25:40.800' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (54, CAST(N'2018-10-24 10:00:00.000' AS DateTime), CAST(N'2018-10-24 12:00:00.000' AS DateTime), N'Kreirana', 15, 9, CAST(N'2018-10-22 09:25:59.253' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (55, CAST(N'2018-10-25 12:30:00.000' AS DateTime), CAST(N'2018-10-25 13:00:00.000' AS DateTime), N'Kreirana', 15, 10, CAST(N'2018-10-22 09:26:09.473' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (56, CAST(N'2018-10-26 13:30:00.000' AS DateTime), CAST(N'2018-10-26 14:00:00.000' AS DateTime), N'Kreirana', 15, 14, CAST(N'2018-10-22 09:26:23.137' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (57, CAST(N'2018-10-23 09:00:00.000' AS DateTime), CAST(N'2018-10-23 09:30:00.000' AS DateTime), N'Kreirana', 14, 14, CAST(N'2018-10-22 09:26:52.520' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (58, CAST(N'2018-10-24 12:00:00.000' AS DateTime), CAST(N'2018-10-24 12:30:00.000' AS DateTime), N'Kreirana', 14, 7, CAST(N'2018-10-22 09:27:04.460' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (59, CAST(N'2018-10-25 08:00:00.000' AS DateTime), CAST(N'2018-10-25 10:00:00.000' AS DateTime), N'Kreirana', 14, 17, CAST(N'2018-10-22 09:27:17.133' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (60, CAST(N'2018-10-26 10:30:00.000' AS DateTime), CAST(N'2018-10-26 12:30:00.000' AS DateTime), N'Kreirana', 14, 4, CAST(N'2018-10-22 09:27:27.760' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (61, CAST(N'2018-10-22 13:30:00.000' AS DateTime), CAST(N'2018-10-22 14:00:00.000' AS DateTime), N'Kreirana', 11, 15, CAST(N'2018-10-22 09:27:43.097' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (62, CAST(N'2018-10-23 09:30:00.000' AS DateTime), CAST(N'2018-10-23 11:30:00.000' AS DateTime), N'Kreirana', 11, 5, CAST(N'2018-10-22 09:28:07.843' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (63, CAST(N'2018-10-24 13:00:00.000' AS DateTime), CAST(N'2018-10-24 15:00:00.000' AS DateTime), N'Kreirana', 11, 9, CAST(N'2018-10-22 09:28:22.077' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (64, CAST(N'2018-10-25 10:30:00.000' AS DateTime), CAST(N'2018-10-25 11:00:00.000' AS DateTime), N'Kreirana', 11, 10, CAST(N'2018-10-22 09:28:42.047' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (65, CAST(N'2018-10-26 14:00:00.000' AS DateTime), CAST(N'2018-10-26 14:30:00.000' AS DateTime), N'Kreirana', 11, 14, CAST(N'2018-10-22 09:28:54.763' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (66, CAST(N'2018-10-23 12:00:00.000' AS DateTime), CAST(N'2018-10-23 14:00:00.000' AS DateTime), N'Kreirana', 10, 5, CAST(N'2018-10-22 09:29:12.673' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (67, CAST(N'2018-10-24 08:00:00.000' AS DateTime), CAST(N'2018-10-24 09:00:00.000' AS DateTime), N'Kreirana', 10, 8, CAST(N'2018-10-22 09:29:25.057' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (68, CAST(N'2018-10-25 11:00:00.000' AS DateTime), CAST(N'2018-10-25 11:30:00.000' AS DateTime), N'Kreirana', 10, 18, CAST(N'2018-10-22 09:29:34.603' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (69, CAST(N'2018-10-26 08:00:00.000' AS DateTime), CAST(N'2018-10-26 08:30:00.000' AS DateTime), N'Kreirana', 10, 7, CAST(N'2018-10-22 09:31:12.690' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (70, CAST(N'2018-10-23 14:00:00.000' AS DateTime), CAST(N'2018-10-23 15:00:00.000' AS DateTime), N'Kreirana', 13, 16, CAST(N'2018-10-22 09:31:28.700' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (71, CAST(N'2018-10-25 13:00:00.000' AS DateTime), CAST(N'2018-10-25 13:30:00.000' AS DateTime), N'Kreirana', 13, 7, CAST(N'2018-10-22 09:31:48.053' AS DateTime))
GO
INSERT [dbo].[tNarudzba] ([narudzba_id], [termin_pocetak], [termin_kraj], [status], [pacijent_id], [zahvat_id], [dcr]) VALUES (72, CAST(N'2018-10-26 08:30:00.000' AS DateTime), CAST(N'2018-10-26 10:30:00.000' AS DateTime), N'Kreirana', 9, 17, CAST(N'2018-10-22 09:34:53.107' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tNarudzba] OFF
GO
SET IDENTITY_INSERT [dbo].[tPacijent] ON 

GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (9, N'Srdjak', N'Srećko ', CAST(N'2001-12-01' AS Date), N'01/222-333', N'Avenija Dubrovnik 12A')
GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (10, N'Jorgić ', N'Ksenija ', CAST(N'1998-02-02' AS Date), N'01/231-231', N'Heinzlova 23')
GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (11, N'Granić', N'Marko ', CAST(N'1964-07-01' AS Date), N'023/111-222', N'Zagrebačka 1')
GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (12, N'Vražić', N'Domagoj ', CAST(N'1998-12-02' AS Date), N'091/221-223', N'Bla bla')
GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (13, N'Kovačić', N'Andrijana', CAST(N'2008-05-18' AS Date), N'042/765-432', N'Masarykova 17')
GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (14, N'Gjumlić', N'Martin', CAST(N'2004-06-22' AS Date), N'040/765-432', N'Masarykova 21')
GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (15, N'Bajza', N'Karlo', CAST(N'2008-06-10' AS Date), N'01/123-321', NULL)
GO
SET IDENTITY_INSERT [dbo].[tPacijent] OFF
GO
SET IDENTITY_INSERT [dbo].[tRadnoVrijeme] ON 

GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (1, N'ponedjeljak', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'2018-10-17 10:29:54.780' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (2, N'srijeda', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'2018-10-17 10:29:54.780' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (3, N'utorak', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'2018-10-17 10:29:54.780' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (4, N'četvrtak', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'2018-10-17 10:29:54.780' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (5, N'petak', CAST(N'08:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'2018-10-17 10:29:54.780' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tRadnoVrijeme] OFF
GO
SET IDENTITY_INSERT [dbo].[tZahvat] ON 

GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (1, N'DIAG01', N'Digitalni 2D ortopanski snimak', CAST(200.00 AS Decimal(9, 2)), 30, CAST(N'2018-10-17 12:48:42.850' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (2, N'DIAG04', N'Digitalni CBCT 3D snimak (dvije čeljusti)', CAST(600.00 AS Decimal(9, 2)), 60, CAST(N'2018-10-18 10:20:13.047' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (3, N'FP01', N'Metal-keramička krunica (CAD/CAM)', CAST(1650.00 AS Decimal(9, 2)), 60, CAST(N'2018-10-17 13:17:41.967' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (4, N'FP02', N'Potpuna keramička krunica – cirkon (CAD/CAM)', CAST(2400.00 AS Decimal(9, 2)), 120, CAST(N'2018-10-17 13:18:10.420' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (5, N'IZB01', N'Izbjeljivanje zubi Philips ZOOM tehnologijom', CAST(2500.00 AS Decimal(9, 2)), 120, CAST(N'2018-10-17 13:08:26.317' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (6, N'IZB02', N'Izbjeljivanje jednog zuba', CAST(700.00 AS Decimal(9, 2)), 60, CAST(N'2018-10-17 13:09:16.900' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (7, N'KONZ01', N'Kompozitni ispun jednoplošni', CAST(300.00 AS Decimal(9, 2)), 30, CAST(N'2018-10-17 12:50:17.470' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (8, N'KONZ02', N'Nadogradnja kompozitnim kolčićima', CAST(700.00 AS Decimal(9, 2)), 60, CAST(N'2018-10-17 12:50:46.197' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (9, N'LZ01', N'Liječenje korijenskog kanala', CAST(500.00 AS Decimal(9, 2)), 120, CAST(N'2018-10-17 12:31:46.410' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (10, N'LZ02', N'Revizija punjenja korijenskog kanala', CAST(600.00 AS Decimal(9, 2)), 30, CAST(N'2018-10-17 13:00:50.757' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (11, N'MP01', N'Wironit totalna proteza', CAST(6000.00 AS Decimal(9, 2)), 120, CAST(N'2018-10-17 13:19:20.250' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (12, N'MP02', N'Akrilatna totalna proteza', CAST(2500.00 AS Decimal(9, 2)), 120, CAST(N'2018-10-17 13:19:55.413' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (13, N'PREV01', N'Prvi pregled', CAST(200.00 AS Decimal(9, 2)), 30, CAST(N'2018-10-17 12:46:27.490' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (14, N'PREV02', N'Profesionalno odstranjivanje zubnih naslaga', CAST(350.00 AS Decimal(9, 2)), 30, CAST(N'2018-10-17 12:47:42.020' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (15, N'VZKI01', N'Vađenje zuba (obično)', CAST(300.00 AS Decimal(9, 2)), 30, CAST(N'2018-10-17 13:01:28.780' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (16, N'VZKI02', N'Kirurško vađenje zuba', CAST(700.00 AS Decimal(9, 2)), 60, CAST(N'2018-10-17 13:02:04.667' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (17, N'VZKI03', N'Implantat NOBEL BIOCARE + doživotno jamstvo', CAST(5250.00 AS Decimal(9, 2)), 120, CAST(N'2018-10-17 13:02:48.727' AS DateTime))
GO
INSERT [dbo].[tZahvat] ([zahvat_id], [sifra], [naziv], [cijena], [trajanje_minuta], [dcr]) VALUES (18, N'DIAG02', N'Ispis ortopanskog snimka na film', CAST(100.00 AS Decimal(9, 2)), 30, CAST(N'2018-10-18 10:21:13.087' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tZahvat] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [ix_sifra_uq]    Script Date: 22.10.2018. 13:45:12 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND name = N'ix_sifra_uq')
CREATE UNIQUE NONCLUSTERED INDEX [ix_sifra_uq] ON [dbo].[tZahvat]
(
	[sifra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tNarudzba_tPacijent]') AND parent_object_id = OBJECT_ID(N'[dbo].[tNarudzba]'))
ALTER TABLE [dbo].[tNarudzba]  WITH CHECK ADD  CONSTRAINT [FK_tNarudzba_tPacijent] FOREIGN KEY([pacijent_id])
REFERENCES [dbo].[tPacijent] ([pacijent_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tNarudzba_tPacijent]') AND parent_object_id = OBJECT_ID(N'[dbo].[tNarudzba]'))
ALTER TABLE [dbo].[tNarudzba] CHECK CONSTRAINT [FK_tNarudzba_tPacijent]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tNarudzba_tZahvat]') AND parent_object_id = OBJECT_ID(N'[dbo].[tNarudzba]'))
ALTER TABLE [dbo].[tNarudzba]  WITH CHECK ADD  CONSTRAINT [FK_tNarudzba_tZahvat] FOREIGN KEY([zahvat_id])
REFERENCES [dbo].[tZahvat] ([zahvat_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tNarudzba_tZahvat]') AND parent_object_id = OBJECT_ID(N'[dbo].[tNarudzba]'))
ALTER TABLE [dbo].[tNarudzba] CHECK CONSTRAINT [FK_tNarudzba_tZahvat]
GO
USE [master]
GO
ALTER DATABASE [stomatoloska] SET  READ_WRITE 
GO
