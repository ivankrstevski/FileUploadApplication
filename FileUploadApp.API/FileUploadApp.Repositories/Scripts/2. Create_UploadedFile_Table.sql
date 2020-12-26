USE [FileUploadDb]
GO

/****** Object:  Table [dbo].[UploadedFile]    Script Date: 26-Dec-20 11:12:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UploadedFile]') AND type in (N'U'))
DROP TABLE [dbo].[UploadedFile]

CREATE TABLE [dbo].[UploadedFile](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_UploadedFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UploadedFile] ADD  CONSTRAINT [DF_File_Id]  DEFAULT (newid()) FOR [Id]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_UploadedFile_Name] ON [dbo].[UploadedFile]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
