USE [C:\USERS\NDUSA\DESKTOP\TEST\ULAZNITEST\APP_DATA\TEST_BAZA.MDF]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/27/2018 6:26:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Supplier] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [Name], [Description], [Category], [Brand], [Supplier], [Price]) VALUES (2, N'HP Envy 15', N'This lap top is Cooolllll', N'Laptops', N'HP', N'GIgatron', 100000.0000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Category], [Brand], [Supplier], [Price]) VALUES (3, N'Mouse', N'Fast Mouse', N'Gaming equipment', N'Logitech', N'China', 50.1000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Category], [Brand], [Supplier], [Price]) VALUES (4, N'TEST', N'Test', N'Monitors', N'TEst', N'Test', 0.2000)
INSERT [dbo].[Products] ([ID], [Name], [Description], [Category], [Brand], [Supplier], [Price]) VALUES (5, N'Samsung 18"', N'Lenovo', N'Monitors', N'Samsung', N'Japan', 200.0000)
SET IDENTITY_INSERT [dbo].[Products] OFF
