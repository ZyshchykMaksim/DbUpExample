SET IDENTITY_INSERT [dbo].[Table_1] ON 
GO
INSERT [dbo].[Table_1] ([id], [username], [createdAt], [email]) VALUES (2, N'user_1', CAST(N'2020-07-19T00:00:00.0000000' AS DateTime2), N'user_1@gmail.com')
GO
INSERT [dbo].[Table_1] ([id], [username], [createdAt], [email]) VALUES (3, N'user_2', CAST(N'2020-07-19T00:00:00.0000000' AS DateTime2), N'user_2@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Table_1] OFF
GO