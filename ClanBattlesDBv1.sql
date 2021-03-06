USE [master]
GO
/****** Object:  Database [ClanBattles]    Script Date: 13/09/2018 5:51:08 ******/
CREATE DATABASE [ClanBattles] ON  PRIMARY 
( NAME = N'ClanBattles', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ClanBattles.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ClanBattles_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ClanBattles_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ClanBattles] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClanBattles].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClanBattles] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClanBattles] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClanBattles] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClanBattles] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClanBattles] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClanBattles] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ClanBattles] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClanBattles] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClanBattles] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClanBattles] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClanBattles] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClanBattles] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClanBattles] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClanBattles] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClanBattles] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ClanBattles] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClanBattles] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClanBattles] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClanBattles] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClanBattles] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClanBattles] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClanBattles] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClanBattles] SET RECOVERY FULL 
GO
ALTER DATABASE [ClanBattles] SET  MULTI_USER 
GO
ALTER DATABASE [ClanBattles] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClanBattles] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ClanBattles', N'ON'
GO
USE [ClanBattles]
GO
/****** Object:  Table [dbo].[Clans]    Script Date: 13/09/2018 5:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gameId] [int] NULL,
	[name] [varchar](200) NULL,
	[description] [varchar](800) NULL,
	[rating] [int] NULL CONSTRAINT [DF_Clans_rating]  DEFAULT ((0)),
	[win] [int] NULL CONSTRAINT [DF_Clans_win]  DEFAULT ((0)),
	[lose] [int] NULL CONSTRAINT [DF_Clans_lose]  DEFAULT ((0)),
	[winRate] [float] NULL CONSTRAINT [DF_Clans_win_rate]  DEFAULT ((0)),
	[urlToImage] [varchar](500) NULL,
	[status] [char](3) NULL,
 CONSTRAINT [PK_Clans] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Gamers]    Script Date: 13/09/2018 5:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Gamers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](200) NULL,
	[lastname] [varchar](200) NULL,
	[email] [varchar](200) NOT NULL,
	[birthDate] [date] NULL,
	[address] [varchar](500) NULL,
	[username] [varchar](200) NULL,
	[password] [varchar](200) NULL,
	[status] [char](3) NULL,
 CONSTRAINT [PK_Gamers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Games]    Script Date: 13/09/2018 5:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Games](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NULL,
	[description] [varchar](500) NULL,
	[urlWebPage] [varchar](500) NULL,
	[urlToImage] [varchar](500) NULL,
	[rating] [float] NULL CONSTRAINT [DF_Games_rating]  DEFAULT ((0)),
	[status] [char](3) NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LanCenters]    Script Date: 13/09/2018 5:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LanCenters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NULL,
	[ruc] [varchar](50) NULL,
	[email] [varchar](200) NULL,
	[address] [varchar](500) NULL,
	[latitud] [float] NULL,
	[longitud] [float] NULL,
	[username] [varchar](200) NULL,
	[password] [varchar](200) NULL,
	[status] [char](3) NULL,
 CONSTRAINT [PK_LanCenters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Members]    Script Date: 13/09/2018 5:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Members](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clanId] [int] NULL,
	[gamerId] [int] NULL,
	[status] [char](3) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 13/09/2018 5:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gamerId] [int] NULL,
	[lanCenterId] [int] NULL,
	[description] [varchar](800) NULL,
	[startDate] [datetime] NULL,
	[numberHours] [int] NULL,
	[response] [varchar](800) NULL,
	[isApproved] [bit] NULL,
	[status] [char](3) NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Clans] ON 

INSERT [dbo].[Clans] ([id], [gameId], [name], [description], [rating], [win], [lose], [winRate], [urlToImage], [status]) VALUES (1, 1, N'Team Liquid', NULL, 1, 7, 3, 0.8, NULL, N'ACT')
INSERT [dbo].[Clans] ([id], [gameId], [name], [description], [rating], [win], [lose], [winRate], [urlToImage], [status]) VALUES (2, 1, N'Mineski', NULL, 2, 7, 4, 0.69, NULL, N'ACT')
INSERT [dbo].[Clans] ([id], [gameId], [name], [description], [rating], [win], [lose], [winRate], [urlToImage], [status]) VALUES (3, 1, N'Cloud9', NULL, 3, 15, 10, 0.58, NULL, N'ACT')
INSERT [dbo].[Clans] ([id], [gameId], [name], [description], [rating], [win], [lose], [winRate], [urlToImage], [status]) VALUES (4, 2, N'Vici Gaming', NULL, 1, 20, 10, 0.8, NULL, N'ACT')
INSERT [dbo].[Clans] ([id], [gameId], [name], [description], [rating], [win], [lose], [winRate], [urlToImage], [status]) VALUES (5, 2, N'Virtus Pro Gaming', NULL, 2, 18, 13, 0.71, NULL, N'ACT')
INSERT [dbo].[Clans] ([id], [gameId], [name], [description], [rating], [win], [lose], [winRate], [urlToImage], [status]) VALUES (6, 1, N'Fnatic', NULL, 4, 13, 10, 0.51999998092651367, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clans] OFF
SET IDENTITY_INSERT [dbo].[Gamers] ON 

INSERT [dbo].[Gamers] ([id], [firstName], [lastname], [email], [birthDate], [address], [username], [password], [status]) VALUES (1, N'Kevin', N'Aranibar Villegas', N'kevinaranibarvillegas@gmail.com', CAST(N'1996-03-23' AS Date), N'kevinaranibar@gmail.com', N'u201512321@upc.edu.pe', N'u201512321', N'ACT')
INSERT [dbo].[Gamers] ([id], [firstName], [lastname], [email], [birthDate], [address], [username], [password], [status]) VALUES (2, N'Jose ', N'Veliz Francia', N'elniñorata@gmail.com', CAST(N'1900-03-19' AS Date), N'elniñorata@gmail.com', N'u201518521@gmail.com', N'niñorata', N'ACT')
INSERT [dbo].[Gamers] ([id], [firstName], [lastname], [email], [birthDate], [address], [username], [password], [status]) VALUES (3, N'Eduardo', N'Arias ', N'eduardoarias@gmail.com', CAST(N'1996-05-15' AS Date), N'eduardoarias@gmail.com', N'u201312548@gmail.com', N'u201312545', N'ACT')
SET IDENTITY_INSERT [dbo].[Gamers] OFF
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([id], [name], [description], [urlWebPage], [urlToImage], [rating], [status]) VALUES (1, N'League of Legends', N'League of Legends es un juego en línea de ritmo rápido y competitivo que combina la velocidad y la intensidad de un RTS con elementos de RPG. Dos equipos de campeones poderosos, cada uno con un diseño y un estilo de juego únicos, luchan mano a mano en múltiples campos de batalla y modos de juego.', N'https://lan.leagueoflegends.com/es/', NULL, 5, N'ACT')
INSERT [dbo].[Games] ([id], [name], [description], [urlWebPage], [urlToImage], [rating], [status]) VALUES (2, N'Dota 2', N'Dota 2 es un videojuego perteneciente al género ARTS, también conocido como MOBA, lanzado el 9 de julio de 2013. El juego fue desarrollado por la empresa Valve Corporation. ', N'http://es.dota2.com/', NULL, 3, N'ACT')
INSERT [dbo].[Games] ([id], [name], [description], [urlWebPage], [urlToImage], [rating], [status]) VALUES (3, N'Overwatch', N'En Overwatch, controlas a un héroe en partidas competitivas con dos equipos de 6 personas. Lucha por los objetivos, derrota al equipo rival y álzate con la victoria.', N'https://playoverwatch.com/es-es/', NULL, 4, N'INA')
INSERT [dbo].[Games] ([id], [name], [description], [urlWebPage], [urlToImage], [rating], [status]) VALUES (4, N'Fortnite', N'Fortnite es un videojuego del año 2017 desarrollado por la empresa Epic Games, lanzado como diferentes paquetes de software que presentan diferentes modos de juego, pero que comparten el mismo motor general de juego y las mecánicas.', N'https://www.epicgames.com/fortnite/es-ES/home', NULL, 5, N'ACT')
INSERT [dbo].[Games] ([id], [name], [description], [urlWebPage], [urlToImage], [rating], [status]) VALUES (5, N'Heroes of the Storm', N'Heroes of the Storm™ es un juego gratuito de lucha online en equipo protagonizado por tus personajes preferidos de Blizzard. En él, los legendarios héroes y villanos de Warcraft, StarCraft y Diablo entran en el Nexo (cruce de caminos del multiverso de Blizzard) para enfrentarse en combates sin cuartel.', N'https://heroesofthestorm.com/es-es/', NULL, 3, N'ACT')
INSERT [dbo].[Games] ([id], [name], [description], [urlWebPage], [urlToImage], [rating], [status]) VALUES (6, N'Counter Strike Go', N'Counter-Strike: Global Offensive es un videojuego de disparos en primera persona desarrollado por Valve Corporation en cooperación con Hidden Path Entertainment.', N'http://blog.counter-strike.net/', NULL, 5, N'INA')
SET IDENTITY_INSERT [dbo].[Games] OFF
SET IDENTITY_INSERT [dbo].[LanCenters] ON 

INSERT [dbo].[LanCenters] ([id], [name], [ruc], [email], [address], [latitud], [longitud], [username], [password], [status]) VALUES (1, N'FirstBlood', N'24543232353', N'firstblood@gmail.com', N'Av. Primavera 1971, Cercado de Lima 15023', 79.6565, 12.656565, N'firstblood@gmail.com', N'123456', NULL)
INSERT [dbo].[LanCenters] ([id], [name], [ruc], [email], [address], [latitud], [longitud], [username], [password], [status]) VALUES (2, N'LaBika', N'28563232353', N'labika@gmail.com', N'Av. Primavera 2261 Int. 201 Segundo piso del centro comercial Full Center.', 75.6565, 11.656565, N'labika@gmail.com', N'12345678', NULL)
INSERT [dbo].[LanCenters] ([id], [name], [ruc], [email], [address], [latitud], [longitud], [username], [password], [status]) VALUES (3, N'Gaming Factory', N'22563232553', N'gamingfactory@gmail.com', N'Jirón Tomás Guido 332, Lince 15046', 72.6565, 17.656565, N'gamingfactory@gmail.com', N'54800gmf', NULL)
SET IDENTITY_INSERT [dbo].[LanCenters] OFF
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([id], [clanId], [gamerId], [status]) VALUES (1, 1, 1, N'ACT')
INSERT [dbo].[Members] ([id], [clanId], [gamerId], [status]) VALUES (2, 1, 2, N'ACT')
INSERT [dbo].[Members] ([id], [clanId], [gamerId], [status]) VALUES (3, 1, 3, N'INA')
INSERT [dbo].[Members] ([id], [clanId], [gamerId], [status]) VALUES (4, 4, 1, N'ACT')
SET IDENTITY_INSERT [dbo].[Members] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([id], [gamerId], [lanCenterId], [description], [startDate], [numberHours], [response], [isApproved], [status]) VALUES (1, 1, 1, N'Solicito reserva de cabina a las 6.00 pm del día 23/09/18.', CAST(N'2018-03-23 00:00:00.000' AS DateTime), 4, NULL, 1, N'ACT')
INSERT [dbo].[Reservations] ([id], [gamerId], [lanCenterId], [description], [startDate], [numberHours], [response], [isApproved], [status]) VALUES (2, 1, 3, N'Solicito reserva de cabina a las 6.00 pm del día 25/09/18.', CAST(N'2018-03-25 00:00:00.000' AS DateTime), 2, NULL, 0, N'INA')
INSERT [dbo].[Reservations] ([id], [gamerId], [lanCenterId], [description], [startDate], [numberHours], [response], [isApproved], [status]) VALUES (3, 1, 3, N'Por favor, reservame una cabina con DOTA2, soy veliz el niño rata. Estoy llendo a las 6.00 pm.', CAST(N'2018-09-29 00:00:00.000' AS DateTime), 5, N'Buenas,te esperamos a las 6.00 pm. Tu número de cabina es la 012, esperaremos como máximo 5 minutos o cancelamos la reserva.', 1, N'ACT')
INSERT [dbo].[Reservations] ([id], [gamerId], [lanCenterId], [description], [startDate], [numberHours], [response], [isApproved], [status]) VALUES (4, 2, 3, N'Por favor, reservame una cabina con League of Legends. Ire a jugar a las 5.00 pm.', CAST(N'2018-03-27 00:00:00.000' AS DateTime), 5, NULL, 0, N'ACT')
SET IDENTITY_INSERT [dbo].[Reservations] OFF
ALTER TABLE [dbo].[Clans]  WITH CHECK ADD  CONSTRAINT [FK_Clans_Games] FOREIGN KEY([gameId])
REFERENCES [dbo].[Games] ([id])
GO
ALTER TABLE [dbo].[Clans] CHECK CONSTRAINT [FK_Clans_Games]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Clans] FOREIGN KEY([clanId])
REFERENCES [dbo].[Clans] ([id])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Clans]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Gamers] FOREIGN KEY([gamerId])
REFERENCES [dbo].[Gamers] ([id])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Gamers]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Gamers] FOREIGN KEY([gamerId])
REFERENCES [dbo].[Gamers] ([id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Gamers]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_LanCenters] FOREIGN KEY([lanCenterId])
REFERENCES [dbo].[LanCenters] ([id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_LanCenters]
GO
USE [master]
GO
ALTER DATABASE [ClanBattles] SET  READ_WRITE 
GO
