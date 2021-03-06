USE [master]
GO
/****** Object:  Database [NoduleDb]    Script Date: 5/7/2013 11:08:03 μμ ******/
CREATE DATABASE [NoduleDb] ON  PRIMARY 
( NAME = N'NoduleDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NoduleDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NoduleDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NoduleDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NoduleDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NoduleDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NoduleDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NoduleDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NoduleDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NoduleDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NoduleDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [NoduleDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NoduleDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NoduleDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NoduleDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NoduleDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NoduleDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NoduleDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NoduleDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NoduleDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NoduleDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NoduleDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NoduleDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NoduleDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NoduleDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NoduleDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NoduleDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NoduleDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NoduleDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NoduleDb] SET RECOVERY FULL 
GO
ALTER DATABASE [NoduleDb] SET  MULTI_USER 
GO
ALTER DATABASE [NoduleDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NoduleDb] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NoduleDb', N'ON'
GO
USE [NoduleDb]
GO
/****** Object:  Table [dbo].[Commits]    Script Date: 5/7/2013 11:08:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commits](
	[Id] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[Name] [nvarchar](500) NULL,
	[Username] [nvarchar](500) NULL,
	[ModifiedNo] [int] NOT NULL,
	[AddedNo] [int] NOT NULL,
	[DeletedNo] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Url] [nvarchar](1000) NOT NULL,
	[Message] [ntext] NOT NULL,
 CONSTRAINT [PK_Commits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostStatuses]    Script Date: 5/7/2013 11:08:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostStatuses](
	[Id] [tinyint] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PostStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WebHookPostCommits]    Script Date: 5/7/2013 11:08:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebHookPostCommits](
	[WebHookPostId] [bigint] NOT NULL,
	[CommitId] [nvarchar](100) NOT NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK__WebHookPostCommits_Commits] PRIMARY KEY CLUSTERED 
(
	[WebHookPostId] ASC,
	[CommitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WebHookPosts]    Script Date: 5/7/2013 11:08:03 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebHookPosts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PostData] [ntext] NULL,
	[StatusId] [tinyint] NOT NULL,
	[RepoUrl] [nvarchar](500) NULL,
	[PullRequestReference] [nvarchar](500) NULL,
	[Result] [ntext] NULL,
	[Organization] [nvarchar](500) NULL,
	[Repository] [nvarchar](500) NULL,
 CONSTRAINT [PK_WebHookPosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[PostStatuses] ([Id], [Description]) VALUES (1, N'Just recieved')
INSERT [dbo].[PostStatuses] ([Id], [Description]) VALUES (2, N'Processing')
INSERT [dbo].[PostStatuses] ([Id], [Description]) VALUES (3, N'Success')
INSERT [dbo].[PostStatuses] ([Id], [Description]) VALUES (4, N'Failed')
/****** Object:  View [dbo].[ListOfRequests]    Script Date: 9/27/2013 4:31:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ListOfRequests]
AS
SELECT dbo.WebHookPosts.Id, dbo.WebHookPosts.Date, CAST(dbo.WebHookPosts.StatusId AS int) AS StatusId, dbo.PostStatuses.Description AS StatusDescription, dbo.WebHookPosts.RepoUrl, 
                  dbo.WebHookPosts.PullRequestReference
FROM     dbo.WebHookPosts INNER JOIN
                  dbo.PostStatuses ON dbo.WebHookPosts.StatusId = dbo.PostStatuses.Id

GO
ALTER TABLE [dbo].[WebHookPostCommits]  WITH CHECK ADD  CONSTRAINT [FK_Commit] FOREIGN KEY([CommitId])
REFERENCES [dbo].[Commits] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WebHookPostCommits] CHECK CONSTRAINT [FK_Commit]
GO
ALTER TABLE [dbo].[WebHookPostCommits]  WITH CHECK ADD  CONSTRAINT [FK_WebHookPosts] FOREIGN KEY([WebHookPostId])
REFERENCES [dbo].[WebHookPosts] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WebHookPostCommits] CHECK CONSTRAINT [FK_WebHookPosts]
GO
ALTER TABLE [dbo].[WebHookPosts]  WITH CHECK ADD  CONSTRAINT [FK_PostStatuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[PostStatuses] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WebHookPosts] CHECK CONSTRAINT [FK_PostStatuses]
GO
USE [master]
GO
ALTER DATABASE [NoduleDb] SET  READ_WRITE 
GO
