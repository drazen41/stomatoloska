USE [stomatoloska]
GO
/****** Object:  Table [dbo].[tZahvat]    Script Date: 12.10.2018. 15:25:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND type in (N'U'))
DROP TABLE [dbo].[tZahvat]
GO
/****** Object:  Table [dbo].[tRadnoVrijeme]    Script Date: 12.10.2018. 15:25:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tRadnoVrijeme]') AND type in (N'U'))
DROP TABLE [dbo].[tRadnoVrijeme]
GO
/****** Object:  Table [dbo].[tRadnoVrijeme]    Script Date: 12.10.2018. 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tRadnoVrijeme]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tRadnoVrijeme](
	[radno_vrijeme_id] [int] IDENTITY(1,1) NOT NULL,
	[radni_dan] [nvarchar](50) NOT NULL,
	[od_dana] [date] NOT NULL,
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
/****** Object:  Table [dbo].[tZahvat]    Script Date: 12.10.2018. 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tZahvat]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tZahvat](
	[sifra] [int] NOT NULL,
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
SET IDENTITY_INSERT [dbo].[tRadnoVrijeme] ON 

GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [od_dana], [pocetak], [kraj], [dcr]) VALUES (1, N'ponedjeljak', CAST(N'2018-10-12' AS Date), CAST(N'08:00:00' AS Time), CAST(N'14:00:00' AS Time), CAST(N'2018-10-12 10:24:59.477' AS DateTime))
GO
INSERT [dbo].[tRadnoVrijeme] ([radno_vrijeme_id], [radni_dan], [od_dana], [pocetak], [kraj], [dcr]) VALUES (2, N'ponedjeljak', CAST(N'2018-10-19' AS Date), CAST(N'09:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'2018-10-12 15:15:59.733' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tRadnoVrijeme] OFF
GO
