SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[email] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO