CREATE LOGIN [tododb] WITH PASSWORD = '123456'
GO

CREATE DATABASE [ToDoDb]
GO

USE [ToDoDb]
GO

CREATE USER [tododb] FOR LOGIN [tododb] WITH DEFAULT_SCHEMA=[dbo]
GO

ALTER ROLE [db_owner] ADD MEMBER [tododb]
GO

CREATE TABLE [dbo].[TaskItem](
	[TaskId] [bigint] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](4000) NOT NULL,
	[IsComplete] [bit] NOT NULL,
 CONSTRAINT [PK_TaskItem] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
