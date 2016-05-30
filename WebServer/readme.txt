USE [master]
GO

/****** Object:  Database [WebServiceDB]    Script Date: 30.05.2016 10:40:17 ******/
CREATE DATABASE [WebServiceDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebServiceDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WebServiceDB.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebServiceDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WebServiceDB_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [WebServiceDB] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebServiceDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [WebServiceDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [WebServiceDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [WebServiceDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [WebServiceDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [WebServiceDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [WebServiceDB] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [WebServiceDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [WebServiceDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [WebServiceDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [WebServiceDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [WebServiceDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [WebServiceDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [WebServiceDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [WebServiceDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [WebServiceDB] SET  ENABLE_BROKER 
GO

ALTER DATABASE [WebServiceDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [WebServiceDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [WebServiceDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [WebServiceDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [WebServiceDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [WebServiceDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [WebServiceDB] SET HONOR_BROKER_PRIORITY OFF 
GO
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
USE [WebServiceDB]
GO

/****** Object:  Table [dbo].[Clients]    Script Date: 30.05.2016 10:41:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients](
	[ClientId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[Surname] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
USE [WebServiceDB]
GO

/****** Object:  Table [dbo].[Managers]    Script Date: 30.05.2016 10:41:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Managers](
	[ManagerId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[Surname] [nvarchar](15) NOT NULL,
	[Work] [int] NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nchar](13) NULL,
	[Login] [nvarchar](15) NULL,
	[Password] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
USE [WebServiceDB]
GO

/****** Object:  Table [dbo].[Forms]    Script Date: 30.05.2016 10:41:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Forms](
	[FormId] [uniqueidentifier] NOT NULL,
	[ManagerId] [uniqueidentifier] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[Answer1] [nchar](3) NULL,
	[Comment1] [nvarchar](512) NULL,
	[Answer2] [nchar](3) NULL,
	[Comment2] [nvarchar](512) NULL,
	[Answer3] [nchar](3) NULL,
	[Comment3] [nvarchar](512) NULL,
	[Answer4] [nchar](3) NULL,
	[Comment4] [nvarchar](512) NULL,
	[Answer5] [nchar](3) NULL,
	[Comment5] [nvarchar](512) NULL,
PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Forms]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO

ALTER TABLE [dbo].[Forms]  WITH CHECK ADD FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Managers] ([ManagerId])
GO



~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
USE [WebServiceDB]
GO

/****** Object:  Table [dbo].[Appeals]    Script Date: 30.05.2016 10:32:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Appeals](
	[AppealId] [uniqueidentifier] NOT NULL,
	[ManagerId] [uniqueidentifier] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[Result] [nvarchar](100) NULL,
	[Comment] [nvarchar](512) NULL,
	[References] [nvarchar](256) NULL,
	[ClientAppeal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AppealId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Appeals]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO

ALTER TABLE [dbo].[Appeals]  WITH CHECK ADD FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Managers] ([ManagerId])
GO