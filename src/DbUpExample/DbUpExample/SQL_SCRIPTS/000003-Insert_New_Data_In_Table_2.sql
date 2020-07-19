SET IDENTITY_INSERT [dbo].[Table_2] ON 
GO
INSERT [dbo].[Table_2] ([id], [company_name], [createdAt]) VALUES (1, N'LuckyDay', CAST(N'2016-12-21T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Table_2] ([id], [company_name], [createdAt]) VALUES (2, N'ITRex', CAST(N'2016-12-21T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Table_2] OFF
GO