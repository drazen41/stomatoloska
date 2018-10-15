USE [stomatoloska]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND type in (N'U'))
DROP TABLE [dbo].[tZahvat]
GO
/****** Object:  Table [dbo].[tRadnoVrijeme]    Script Date: 15.10.2018. 9:46:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tRadnoVrijeme]') AND type in (N'U'))
DROP TABLE [dbo].[tRadnoVrijeme]
GO
/****** Object:  Table [dbo].[tPacijent]    Script Date: 15.10.2018. 9:46:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tPacijent]') AND type in (N'U'))
DROP TABLE [dbo].[tPacijent]
GO
/****** Object:  User [test]    Script Date: 15.10.2018. 9:46:07 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'test')
DROP USER [test]
GO
/****** Object:  User [test]    Script Date: 15.10.2018. 9:46:07 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'test')
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
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
	[adresa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tPacijent] PRIMARY KEY CLUSTERED 
(
	[pacijent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tRadnoVrijeme]    Script Date: 14.10.2018. 19:30:57 ******/
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
/****** Object:  Table [dbo].[tZahvat]    Script Date: 14.10.2018. 19:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tZahvat](
	[sifra] [nvarchar](10) NOT NULL,
	[naziv] [nvarchar](200) NOT NULL,
	[cijena] [decimal](9, 2) NOT NULL,
	[trajanje_minuta] [int] NOT NULL,
	[dcr] [datetime] NOT NULL,
 CONSTRAINT [PK_tZahvat] PRIMARY KEY CLUSTERED 
(
	[sifra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tPacijent] ON 
GO
INSERT [dbo].[tPacijent] ([pacijent_id], [prezime], [ime], [datum_rodjenja], [telefon], [adresa]) VALUES (1, N'Test prezime', N'Test ime', CAST(N'2001-12-01' AS Date), N'091/221-223', N'Test adresa')
GO
SET IDENTITY_INSERT [dbo].[tPacijent] OFF
GO
SET IDENTITY_INSERT [dbo].[tRadnoVrijeme] ON 
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (1, N'ponedjeljak', CAST(N'13:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'2018-10-14T13:46:58.087' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (2, N'srijeda', CAST(N'13:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'2018-10-14T13:46:58.087' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (3, N'utorak', CAST(N'08:00:00' AS Time), CAST(N'14:00:00' AS Time), CAST(N'2018-10-14T13:48:29.767' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (4, N'četvrtak', CAST(N'08:00:00' AS Time), CAST(N'14:00:00' AS Time), CAST(N'2018-10-14T13:48:29.767' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [pocetak], [kraj], [dcr]) VALUES (5, N'petak', CAST(N'08:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'2018-10-14T13:43:45.757' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tRadnoVrijeme] OFF
GO
