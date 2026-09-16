/****** Object:  Table [dbo].[Songs]    Script Date: 9/16/2026 4:51:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Songs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Artist] [varchar](100) NOT NULL,
	[Added] [datetime] NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Songs] ADD  CONSTRAINT [DF_Songs_Added]  DEFAULT (getdate()) FOR [Added]
GO

ALTER TABLE [dbo].[Songs] ADD  CONSTRAINT [DF_Songs_Active]  DEFAULT ((1)) FOR [Active]
GO


