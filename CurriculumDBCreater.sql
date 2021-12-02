USE [master]
GO

/****** Object:  Database [CurriculumDB]    Script Date: 2021/11/23 下午 08:42:31 ******/
DROP DATABASE [CurriculumDB]
GO

/****** Object:  Database [CurriculumDB]    Script Date: 2021/11/23 下午 08:42:31 ******/
CREATE DATABASE [CurriculumDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CurriculumDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CurriculumDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CurriculumDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CurriculumDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CurriculumDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [CurriculumDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [CurriculumDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [CurriculumDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [CurriculumDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [CurriculumDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [CurriculumDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [CurriculumDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [CurriculumDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [CurriculumDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [CurriculumDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [CurriculumDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [CurriculumDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [CurriculumDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [CurriculumDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [CurriculumDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [CurriculumDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [CurriculumDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [CurriculumDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [CurriculumDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [CurriculumDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [CurriculumDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [CurriculumDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [CurriculumDB] SET RECOVERY FULL 
GO

ALTER DATABASE [CurriculumDB] SET  MULTI_USER 
GO

ALTER DATABASE [CurriculumDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [CurriculumDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [CurriculumDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [CurriculumDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [CurriculumDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [CurriculumDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [CurriculumDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [CurriculumDB] SET  READ_WRITE 
GO


USE [CurriculumDB]
GO

/****** Object:  Table [dbo].[Course]    Script Date: 2021/11/23 下午 08:46:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Course]') AND type in (N'U'))
DROP TABLE [dbo].[Course]
GO

/****** Object:  Table [dbo].[Course]    Script Date: 2021/11/23 下午 08:46:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Units] [int] NOT NULL,
	[Locations] [nvarchar](20) NOT NULL,
	[Teacher] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [CurriculumDB]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 2021/11/23 下午 08:46:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
DROP TABLE [dbo].[Student]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 2021/11/23 下午 08:46:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [CurriculumDB]
GO

ALTER TABLE [dbo].[Student_CourseSelection] DROP CONSTRAINT [FK_Student_CourseSelection_Student]
GO

ALTER TABLE [dbo].[Student_CourseSelection] DROP CONSTRAINT [FK_Student_CourseSelection_Course]
GO

/****** Object:  Table [dbo].[Student_CourseSelection]    Script Date: 2021/11/23 下午 08:47:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_CourseSelection]') AND type in (N'U'))
DROP TABLE [dbo].[Student_CourseSelection]
GO

/****** Object:  Table [dbo].[Student_CourseSelection]    Script Date: 2021/11/23 下午 08:47:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student_CourseSelection](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Student_ID] [int] NOT NULL,
	[Course_ID] [int] NOT NULL,
 CONSTRAINT [PK_Student_CourseSelection] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student_CourseSelection]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseSelection_Course] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([ID])
GO

ALTER TABLE [dbo].[Student_CourseSelection] CHECK CONSTRAINT [FK_Student_CourseSelection_Course]
GO

ALTER TABLE [dbo].[Student_CourseSelection]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseSelection_Student] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([ID])
GO

ALTER TABLE [dbo].[Student_CourseSelection] CHECK CONSTRAINT [FK_Student_CourseSelection_Student]
GO

