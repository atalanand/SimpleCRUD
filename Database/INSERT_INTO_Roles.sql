USE [SimpleCRUD]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Title]) VALUES (1, N'Super Admin')
INSERT [dbo].[Roles] ([Id], [Title]) VALUES (2, N'Admin')
INSERT [dbo].[Roles] ([Id], [Title]) VALUES (3, N'Manager')
INSERT [dbo].[Roles] ([Id], [Title]) VALUES (4, N'Supervisor')
INSERT [dbo].[Roles] ([Id], [Title]) VALUES (5, N'Developer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
