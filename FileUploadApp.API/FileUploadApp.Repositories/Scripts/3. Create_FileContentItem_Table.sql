USE [FileUploadDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileContentItem]') AND type in (N'U'))
DROP TABLE [dbo].[FileContentItem]

CREATE TABLE [dbo].[FileContentItem](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[Label] [varchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_FileContentItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FileContentItem] ADD  CONSTRAINT [DF_FileContentItem_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[FileContentItem]  WITH CHECK ADD  CONSTRAINT [FK_FileContentItem_UploadedFile] FOREIGN KEY([ParentId])
REFERENCES [dbo].[UploadedFile] ([Id])
GO

ALTER TABLE [dbo].[FileContentItem] CHECK CONSTRAINT [FK_FileContentItem_UploadedFile]
GO


