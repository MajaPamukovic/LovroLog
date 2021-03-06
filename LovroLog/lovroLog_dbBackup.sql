USE [master]
GO
/****** Object:  Database [LovroLog]    Script Date: 5.1.2016. 19:29:45 ******/
CREATE DATABASE [LovroLog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LovroLog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\LovroLog.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LovroLog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\LovroLog_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LovroLog] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LovroLog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LovroLog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LovroLog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LovroLog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LovroLog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LovroLog] SET ARITHABORT OFF 
GO
ALTER DATABASE [LovroLog] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LovroLog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LovroLog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LovroLog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LovroLog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LovroLog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LovroLog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LovroLog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LovroLog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LovroLog] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LovroLog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LovroLog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LovroLog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LovroLog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LovroLog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LovroLog] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LovroLog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LovroLog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LovroLog] SET  MULTI_USER 
GO
ALTER DATABASE [LovroLog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LovroLog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LovroLog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LovroLog] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [LovroLog] SET DELAYED_DURABILITY = DISABLED 
GO
USE [LovroLog]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5.1.2016. 19:29:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LovroBaseEvents]    Script Date: 5.1.2016. 19:29:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LovroBaseEvents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Time] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.LovroBaseEvents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201512230442360_InitialCreate', N'LovroLog.LovroContext', 0x1F8B0800000000000400D558CD6EDB4610BE17E83B103C2580235A721BA40695C096AC4288651BA19D9E57E4485A74B9CBEE2E05E9D97AE823F51532CBFF1F8992EC206EA18BB89CF966F69BD9D919FEFBF73FEEA74DC8AC354845051FDAFDDEB96D01F74540F97268C77AF1EE83FDE9E3CF3FB93741B8B1BEE67217460E35B91ADA2BADA34BC751FE0A42A27A21F5A55062A17BBE081D120867707EFE9BD3EF3B801036625996FB25E69A86903CE0E348701F221D133613013095ADE31B2F41B5EE48082A223E0CED5BB196E2562C6DEB8A5182F63D600BDB229C0B4D347A77F9A4C0D352F0A517E102618FDB08506E419882CCEBCB52FCD80D9C0FCC069C523187F263A545782260FF2263C469AA3F8B57BB600C39BB416EF5D6EC3AE12DA3EC9A28B85903D7B6D534793962D28897E4F6923F89B8EAD5D5CFAC5CE8ACC8074C1BF33BB34631D3B1842187584BC2CEAC8778CEA8FF19B68FE24FE0431E3356F515BDC577B5055C7A902202A9B75F6091ED603AB62DA7AEE734150BB58A4EBAAB29D71703DBBA43E364CEA048850A039E16127E070E9268081E88D6203192D30012325BD61BB68C9DDC9AC9C70A7FE9AB96ED0378783872BC317A943E9F08722774E9949678A26D6B4636B7C0977A35B4F1AF6D4DE806827C25437DE2140B002A6919378CB84E995C87536E4C09FA335A11BE84E005B9D7C67979125A26A19B012BCF4827B11EBA1EAB76BC533FF3B79DD1DA4F641C3669ACA4D1544D185996C5EC08360DA26AE4E377A0EF890720D91693AA7AC6EAB4CD209C83CCB63286054164DBFA4A588CCFE7ADF4AD893F08A43C28A4FBDDD2571A264294E2836EF1093076A5184054685C746BFC815B7F2AA57FE996AE256CA1F46BB7D235D1AB8AF4FB76C2A4A971285DEA59F8B28CA962BD46D28C18107E74CA50A58E4F194F50067B33661FDDE6CC62B7A209E50552428B5984CDAE0287ED48C6B1CA4A6ADDAB14D4035DE4415684307A6591D85DA676D694C2BFB28D72D23E2AEFB79C3D0D973B235184D1A93460D98AE5A5DDD7E89D777A8312A6188EAF76F42985B78525BC8AC9121A6FD1347A3AA15269BC10C99C98641E05614BAC168D3D4CE7A65A84373B9192FF5CC5FCCFFA0B65FEDF2FDED42FAE02ED6D13AD6473821B0C5124D92B146EB53AB51640D2111346E48E5E6724581CF27DFD5297767AB754F5D395131092FEA48690AC1C8F90362B558474A58DE03A0D169B41735A513B25ACF568EE6861FE2F51CD6F802A42BEB613050F4D404DC9CA6BE2DE26AE0A39A6CA9734A49CE0AE5F3D5E1D2CBF7E9876135CA9E63F94D7FC7D590FBBEE92A64861BDB8531A77879BD5F1C3137DABB0A722B6853CAF69608ABAB7551AC29E11E8797FB111A3095FB9C08C70BA00A5D35EC3C6F17AD0F83CF0DF19D51DA50276D2BCFEC3E7656AB83D38119F3AD25646E4C4C00B46E2005DD22F1D89F99A487F45E49B906CDE5691DA63EFA111B0B19F63001AC7BBEE526D4EEF0F3E3C7B98DCD5AEB6FBA8EE7EB459A40EF6A4E9F1C528CD056E2CF5BA2EA39EDDB8B68B8AEB543F26BA6350745942989ACBC137A7B504CD65A67C21F2B0E07EAB1EE5228DA8CD40134C3E7225355D105FE36B1F944A3EAD6435FD06678C60CAEF631DC5FA0A279270CE6ADF8F5CA7DB7ED29DD77D76EF23F3A4BEC716D04D6ACECF3DBF8E292B07A0C98EBCDA03613228AB0CE895A74D85586E0BA43BC18F04CAE81B4304DCD4954708238660EA9E7B640DCFF10DA7AD5B58127F9BDF0DFB410E07A24EBB8BADD05292506518A5BEF940EE982FE41FBF015B2261ED53170000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[LovroBaseEvents] ON 

INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (48, 3, CAST(N'2015-12-27 20:11:03.777' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (49, 4, CAST(N'2015-12-27 23:01:45.790' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (50, 5, CAST(N'2015-12-27 23:01:54.110' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (51, 2, CAST(N'2015-12-27 23:28:06.420' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (52, 1, CAST(N'2015-12-27 23:57:09.447' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (53, 4, CAST(N'2015-12-28 05:00:48.630' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (54, 2, CAST(N'2015-12-28 05:00:49.637' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (55, 5, CAST(N'2015-12-28 05:14:02.297' AS DateTime), N'malo zelene kakice', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (56, 3, CAST(N'2015-12-28 05:46:02.323' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (58, 4, CAST(N'2015-12-28 08:06:19.140' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (59, 2, CAST(N'2015-12-28 08:28:12.217' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (60, 3, CAST(N'2015-12-28 00:30:00.000' AS DateTime), N'cca', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (61, 2, CAST(N'2015-12-28 10:44:47.577' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (62, 5, CAST(N'2015-12-28 09:45:00.000' AS DateTime), N'cca', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (63, 3, CAST(N'2015-12-28 10:45:00.000' AS DateTime), N'zaspao na sisi', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (64, 4, CAST(N'2015-12-28 11:00:00.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (65, 2, CAST(N'2015-12-28 12:42:51.313' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (66, 3, CAST(N'2015-12-28 12:42:57.320' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (67, 4, CAST(N'2015-12-28 14:41:41.517' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (68, 5, CAST(N'2015-12-28 14:49:09.650' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (69, 2, CAST(N'2015-12-28 15:23:52.573' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (70, 2, CAST(N'2015-12-28 16:56:32.503' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (71, 3, CAST(N'2015-12-28 16:56:33.727' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (72, 4, CAST(N'2015-12-28 17:37:47.517' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (73, 3, CAST(N'2015-12-28 17:42:45.443' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (74, 5, CAST(N'2015-12-28 17:59:58.507' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (75, 4, CAST(N'2015-12-28 17:55:00.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (76, 2, CAST(N'2015-12-28 18:45:23.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (77, 3, CAST(N'2015-12-28 18:55:35.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (78, 4, CAST(N'2015-12-28 19:00:00.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (79, 5, CAST(N'2015-12-28 19:23:17.857' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (80, 2, CAST(N'2015-12-28 19:40:32.777' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (81, 3, CAST(N'2015-12-28 19:40:36.720' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (82, 1, CAST(N'2015-12-28 19:18:44.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (83, 4, CAST(N'2015-12-28 20:00:01.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (84, 2, CAST(N'2015-12-28 20:42:22.510' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (85, 2, CAST(N'2015-12-28 21:50:23.817' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (86, 1, CAST(N'2015-12-28 21:57:41.127' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (87, 5, CAST(N'2015-12-28 22:41:05.893' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (88, 3, CAST(N'2015-12-28 23:15:09.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (89, 4, CAST(N'2015-12-28 23:45:23.370' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (90, 2, CAST(N'2015-12-29 07:01:24.360' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (91, 4, CAST(N'2015-12-29 07:01:38.520' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (92, 3, CAST(N'2015-12-28 23:50:00.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (93, 5, CAST(N'2015-12-29 08:07:24.063' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (95, 3, CAST(N'2015-12-29 08:30:00.000' AS DateTime), N'zaspao sam nemirno uz povremeno kmečanje', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (96, 4, CAST(N'2015-12-29 09:31:21.530' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (98, 2, CAST(N'2015-12-29 09:50:01.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (99, 5, CAST(N'2015-12-29 11:52:09.000' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (100, 6, CAST(N'2015-12-29 12:32:35.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (101, 2, CAST(N'2015-12-29 12:52:46.687' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (102, 3, CAST(N'2015-12-29 12:52:55.523' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (103, 4, CAST(N'2015-12-29 12:56:14.037' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (104, 3, CAST(N'2015-12-29 13:00:00.000' AS DateTime), N'cca - isprekidano spavanje', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (105, 4, CAST(N'2015-12-29 14:34:03.527' AS DateTime), N'cca - isprekidano spavanje', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (106, 5, CAST(N'2015-12-29 14:50:12.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (107, 2, CAST(N'2015-12-29 16:10:58.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (108, 3, CAST(N'2015-12-29 16:30:18.000' AS DateTime), N'cca - isprekidano spavanje', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (109, 4, CAST(N'2015-12-29 18:57:51.230' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (110, 2, CAST(N'2015-12-29 19:19:10.160' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (111, 3, CAST(N'2015-12-29 19:05:13.000' AS DateTime), N'zaspao još na sisi i nastavio u kolicima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (112, 4, CAST(N'2015-12-29 20:23:02.690' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (113, 5, CAST(N'2015-12-29 20:39:16.470' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (114, 2, CAST(N'2015-12-29 20:57:08.470' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (115, 2, CAST(N'2015-12-29 22:58:58.973' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (116, 3, CAST(N'2015-12-29 23:10:55.120' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (117, 4, CAST(N'2015-12-30 02:07:35.583' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (119, 5, CAST(N'2015-12-30 02:38:13.503' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (120, 2, CAST(N'2015-12-30 02:56:28.807' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (121, 3, CAST(N'2015-12-30 03:45:08.803' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (122, 4, CAST(N'2015-12-30 06:40:22.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (123, 2, CAST(N'2015-12-30 07:07:31.607' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (124, 3, CAST(N'2015-12-30 07:07:32.847' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (125, 5, CAST(N'2015-12-30 08:59:35.060' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (126, 4, CAST(N'2015-12-30 08:50:40.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (127, 2, CAST(N'2015-12-30 09:45:39.977' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (128, 1, CAST(N'2015-12-30 09:45:42.173' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (129, 5, CAST(N'2015-12-30 10:27:34.343' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (130, 2, CAST(N'2015-12-30 10:50:55.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (131, 3, CAST(N'2015-12-30 10:51:01.000' AS DateTime), N'zaspao na sisi', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (132, 4, CAST(N'2015-12-30 11:21:22.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (133, 3, CAST(N'2015-12-30 12:03:30.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (134, 4, CAST(N'2015-12-30 12:49:25.217' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (135, 5, CAST(N'2015-12-30 13:07:25.557' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (136, 2, CAST(N'2015-12-30 13:30:37.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (137, 5, CAST(N'2015-12-30 15:00:11.000' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (138, 5, CAST(N'2015-12-30 16:15:32.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (139, 5, CAST(N'2015-12-30 17:30:40.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (140, 2, CAST(N'2015-12-30 17:58:27.190' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (142, 2, CAST(N'2015-12-30 19:49:59.090' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (143, 5, CAST(N'2015-12-30 20:12:12.230' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (144, 2, CAST(N'2015-12-30 20:59:11.773' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (145, 3, CAST(N'2015-12-30 20:59:13.670' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (147, 4, CAST(N'2015-12-30 21:10:39.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (148, 3, CAST(N'2015-12-30 21:33:45.607' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (149, 4, CAST(N'2015-12-31 00:50:36.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (151, 2, CAST(N'2015-12-31 01:20:07.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (152, 3, CAST(N'2015-12-31 01:20:49.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (153, 4, CAST(N'2015-12-31 02:59:37.790' AS DateTime), N'', NULL, N'LovroBaseEvent')
GO
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (154, 5, CAST(N'2015-12-31 03:10:49.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (155, 2, CAST(N'2015-12-31 03:42:53.427' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (156, 3, CAST(N'2015-12-31 03:43:15.933' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (157, 3, CAST(N'2015-12-30 16:20:19.000' AS DateTime), N'cca - jana', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (158, 4, CAST(N'2015-12-30 17:05:47.000' AS DateTime), N'cca - jana', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (159, 4, CAST(N'2015-12-31 08:30:58.000' AS DateTime), N'cca', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (160, 2, CAST(N'2015-12-31 08:50:14.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (161, 5, CAST(N'2015-12-31 09:40:09.000' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (162, 2, CAST(N'2015-12-31 10:29:11.910' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (163, 3, CAST(N'2015-12-31 10:29:12.857' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (164, 4, CAST(N'2015-12-31 12:05:00.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (165, 5, CAST(N'2015-12-31 12:10:06.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (166, 2, CAST(N'2015-12-31 12:40:27.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (167, 2, CAST(N'2015-12-31 14:15:20.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (168, 3, CAST(N'2015-12-31 14:15:29.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (169, 4, CAST(N'2015-12-31 14:45:50.327' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (170, 1, CAST(N'2015-12-31 14:51:45.457' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (171, 5, CAST(N'2015-12-31 15:58:28.227' AS DateTime), N'zeleno', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (172, 2, CAST(N'2015-12-31 17:36:32.177' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (173, 3, CAST(N'2015-12-31 18:00:50.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (174, 2, CAST(N'2015-12-31 19:42:40.613' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (175, 5, CAST(N'2015-12-31 19:50:23.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (176, 2, CAST(N'2015-12-31 22:00:12.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (177, 2, CAST(N'2015-12-31 23:30:39.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (178, 3, CAST(N'2015-12-31 23:30:51.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (179, 4, CAST(N'2016-01-01 04:00:05.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (180, 2, CAST(N'2016-01-01 04:00:17.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (181, 5, CAST(N'2016-01-01 07:35:34.000' AS DateTime), N'cca - na vrbanima', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (182, 2, CAST(N'2016-01-01 07:45:52.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (183, 5, CAST(N'2016-01-01 12:00:22.000' AS DateTime), N'cca - na vrbanima', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (184, 5, CAST(N'2016-01-01 16:00:37.000' AS DateTime), N'cca - na vrbanima', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (185, 2, CAST(N'2016-01-01 09:00:59.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (186, 2, CAST(N'2016-01-01 11:00:11.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (187, 2, CAST(N'2016-01-01 14:00:20.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (188, 2, CAST(N'2016-01-01 16:00:31.000' AS DateTime), N'cca - na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (189, 2, CAST(N'2016-01-01 18:00:44.000' AS DateTime), N'cca - kod kuće', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (190, 2, CAST(N'2016-01-01 20:00:54.000' AS DateTime), N'cca - kod kuće', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (191, 5, CAST(N'2016-01-01 20:30:09.000' AS DateTime), N'cca - kod kuće', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (192, 3, CAST(N'2016-01-01 12:30:19.000' AS DateTime), N'cca - spavao cijeli dan na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (193, 4, CAST(N'2016-01-01 16:00:51.000' AS DateTime), N'cca - spavao cijeli dan na vrbanima', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (194, 2, CAST(N'2016-01-02 01:20:02.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (195, 3, CAST(N'2016-01-01 22:04:23.000' AS DateTime), N'cca - kod kuće', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (196, 4, CAST(N'2016-01-02 01:00:55.000' AS DateTime), N'cca - kod kuće', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (197, 3, CAST(N'2016-01-02 01:30:26.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (198, 1, CAST(N'2016-01-02 09:04:03.663' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (199, 5, CAST(N'2016-01-02 09:30:00.000' AS DateTime), N'cca', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (200, 4, CAST(N'2016-01-02 05:10:28.000' AS DateTime), N'cca', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (201, 5, CAST(N'2016-01-02 05:20:39.000' AS DateTime), N'cca', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (202, 2, CAST(N'2016-01-02 05:45:53.000' AS DateTime), N'cca', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (203, 3, CAST(N'2016-01-02 05:55:06.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (204, 2, CAST(N'2016-01-02 13:00:31.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (205, 3, CAST(N'2016-01-02 14:35:38.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (206, 2, CAST(N'2016-01-02 15:10:18.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (207, 5, CAST(N'2016-01-02 15:29:31.690' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (209, 4, CAST(N'2016-01-02 14:55:22.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (210, 2, CAST(N'2016-01-02 16:20:02.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (211, 2, CAST(N'2016-01-02 19:40:08.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (212, 5, CAST(N'2016-01-02 19:15:16.000' AS DateTime), N'cca - ikea', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (213, 5, CAST(N'2016-01-02 23:26:11.290' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (214, 3, CAST(N'2016-01-02 23:50:17.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (215, 2, CAST(N'2016-01-03 00:45:40.567' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (216, 3, CAST(N'2016-01-03 00:45:44.607' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (217, 4, CAST(N'2016-01-03 05:36:41.750' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (218, 5, CAST(N'2016-01-03 06:28:05.027' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (219, 3, CAST(N'2016-01-03 06:45:33.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (221, 1, CAST(N'2016-01-03 09:40:34.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (222, 5, CAST(N'2016-01-03 10:00:42.000' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (223, 2, CAST(N'2016-01-03 09:30:51.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (224, 4, CAST(N'2016-01-03 09:15:23.000' AS DateTime), N'probudio sam se plačući jako i naglo nakon dugog povremenog kmečkanja u snu koje je zahtijevalo ljuljanje svakih 15-30 minuta', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (225, 1, CAST(N'2016-01-03 11:52:37.990' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (226, 2, CAST(N'2016-01-03 11:15:10.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (227, 5, CAST(N'2016-01-03 12:12:16.703' AS DateTime), N'', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (228, 2, CAST(N'2016-01-03 13:11:10.133' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (230, 3, CAST(N'2016-01-03 13:45:54.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (231, 4, CAST(N'2016-01-03 16:44:18.370' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (232, 5, CAST(N'2016-01-03 16:46:10.367' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (233, 1, CAST(N'2016-01-03 17:24:35.367' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (234, 2, CAST(N'2016-01-03 17:20:11.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (235, 2, CAST(N'2016-01-03 18:27:24.723' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (236, 3, CAST(N'2016-01-03 18:27:25.533' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (237, 4, CAST(N'2016-01-03 18:53:32.777' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (238, 2, CAST(N'2016-01-03 19:17:26.547' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (239, 5, CAST(N'2016-01-03 19:53:10.973' AS DateTime), N'Malo zelene kakice', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (240, 2, CAST(N'2016-01-03 20:25:14.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (241, 3, CAST(N'2016-01-03 22:09:09.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (242, 4, CAST(N'2016-01-04 01:09:39.570' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (243, 3, CAST(N'2016-01-04 01:10:24.080' AS DateTime), N'uz malo ljuljanja', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (244, 4, CAST(N'2016-01-04 01:30:27.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (245, 2, CAST(N'2016-01-04 02:10:37.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (246, 3, CAST(N'2016-01-04 02:10:41.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (247, 5, CAST(N'2016-01-04 01:45:48.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (248, 4, CAST(N'2016-01-04 05:15:07.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (249, 2, CAST(N'2016-01-04 05:35:12.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (250, 3, CAST(N'2016-01-04 05:35:18.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (251, 4, CAST(N'2016-01-04 07:45:37.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (252, 2, CAST(N'2016-01-04 08:25:49.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (253, 3, CAST(N'2016-01-04 08:25:55.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (254, 4, CAST(N'2016-01-04 09:05:01.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (255, 2, CAST(N'2016-01-04 09:35:06.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (256, 3, CAST(N'2016-01-04 09:35:13.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
GO
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (257, 4, CAST(N'2016-01-04 09:56:18.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (258, 5, CAST(N'2016-01-04 06:15:10.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (259, 5, CAST(N'2016-01-04 10:05:19.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (260, 2, CAST(N'2016-01-04 11:00:41.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (261, 3, CAST(N'2016-01-04 11:15:47.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (262, 4, CAST(N'2016-01-04 11:35:52.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (263, 5, CAST(N'2016-01-04 12:20:05.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (264, 2, CAST(N'2016-01-04 13:05:26.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (265, 3, CAST(N'2016-01-04 13:05:31.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (267, 4, CAST(N'2016-01-04 14:15:58.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (268, 2, CAST(N'2016-01-04 15:20:41.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (269, 5, CAST(N'2016-01-04 15:42:44.010' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (270, 2, CAST(N'2016-01-04 16:20:46.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (271, 3, CAST(N'2016-01-04 16:21:50.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (272, 7, CAST(N'2016-01-04 15:43:45.000' AS DateTime), N'dobio 2 x D3 kapi', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (273, 4, CAST(N'2016-01-04 16:45:24.080' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (274, 2, CAST(N'2016-01-04 18:20:21.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (275, 5, CAST(N'2016-01-04 18:40:29.517' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (276, 2, CAST(N'2016-01-04 21:00:03.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (277, 3, CAST(N'2016-01-04 19:00:21.000' AS DateTime), N'cca', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (278, 4, CAST(N'2016-01-04 20:00:35.000' AS DateTime), N'cca', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (279, 5, CAST(N'2016-01-04 21:40:04.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (280, 2, CAST(N'2016-01-04 22:19:04.567' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (282, 3, CAST(N'2016-01-04 22:45:05.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (283, 4, CAST(N'2016-01-05 04:22:13.623' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (284, 5, CAST(N'2016-01-05 04:35:59.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (285, 2, CAST(N'2016-01-05 05:15:12.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (286, 3, CAST(N'2016-01-05 05:42:03.460' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (287, 2, CAST(N'2016-01-05 08:28:56.513' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (288, 4, CAST(N'2016-01-05 08:15:04.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (289, 5, CAST(N'2016-01-05 08:50:32.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (290, 7, CAST(N'2016-01-05 09:00:41.000' AS DateTime), N'primio 2 x D3 kapi', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (291, 2, CAST(N'2016-01-05 10:40:34.000' AS DateTime), N'jeo intermittently 09:50 - 10:40', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (292, 2, CAST(N'2016-01-05 13:55:03.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (293, 3, CAST(N'2016-01-05 11:50:34.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (294, 4, CAST(N'2016-01-05 13:35:40.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (295, 3, CAST(N'2016-01-05 14:09:59.637' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (296, 5, CAST(N'2016-01-05 14:32:50.000' AS DateTime), N'', 1, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (297, 4, CAST(N'2016-01-05 14:25:04.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (298, 1, CAST(N'2016-01-05 14:43:55.977' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (299, 5, CAST(N'2016-01-05 15:10:11.000' AS DateTime), N'jako puno kakice koja jako smrdi, normalne boje i konzistencije', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (300, 2, CAST(N'2016-01-05 16:02:44.517' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (301, 3, CAST(N'2016-01-05 16:02:45.080' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (302, 4, CAST(N'2016-01-05 16:20:03.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (303, 3, CAST(N'2016-01-05 16:38:37.983' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (304, 4, CAST(N'2016-01-05 17:10:11.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (305, 5, CAST(N'2016-01-05 18:30:30.000' AS DateTime), N'malo smrdljive kakice normalne boje i konzistencije', 2, N'LovroDiaperChangedEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (306, 2, CAST(N'2016-01-05 17:30:21.000' AS DateTime), N'cca', NULL, N'LovroBaseEvent')
INSERT [dbo].[LovroBaseEvents] ([ID], [Type], [Time], [Note], [Status], [Discriminator]) VALUES (308, 3, CAST(N'2016-01-05 18:50:37.000' AS DateTime), N'', NULL, N'LovroBaseEvent')
SET IDENTITY_INSERT [dbo].[LovroBaseEvents] OFF
USE [master]
GO
ALTER DATABASE [LovroLog] SET  READ_WRITE 
GO
