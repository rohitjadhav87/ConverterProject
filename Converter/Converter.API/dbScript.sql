
/****** Object:  Table [dbo].[MeasurementDetails]    Script Date: 08-02-2023 3.07.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementDetails](
	[MeasurementValue] [decimal](18, 4) NOT NULL,
	[Name] [char](10) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MeasurementDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TemperatureDetails]    Script Date: 08-02-2023 3.07.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemperatureDetails](
	[Value1] [numeric](3, 2) NOT NULL,
	[Value2] [numeric](3, 0) NULL,
	[Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TemperatureDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MeasurementDetails] ([MeasurementValue], [Name], [Id]) VALUES (CAST(0.0394 AS Decimal(18, 4)), N'inches', N'b902c720-c060-4e5f-9902-333d363b116c')
GO
INSERT [dbo].[MeasurementDetails] ([MeasurementValue], [Name], [Id]) VALUES (CAST(2.2046 AS Decimal(18, 4)), N'pounds', N'42edfc9a-37da-4ed7-8188-408ea34b020a')
GO
INSERT [dbo].[MeasurementDetails] ([MeasurementValue], [Name], [Id]) VALUES (CAST(25.4000 AS Decimal(18, 4)), N'mm', N'd768bf9e-b17f-4eab-b9e4-5162c04647f8')
GO
INSERT [dbo].[MeasurementDetails] ([MeasurementValue], [Name], [Id]) VALUES (CAST(12.0000 AS Decimal(18, 4)), N'feetToInch', N'cf30e16d-44f0-4aab-b147-99e61f391abd')
GO
INSERT [dbo].[MeasurementDetails] ([MeasurementValue], [Name], [Id]) VALUES (CAST(0.0010 AS Decimal(18, 4)), N'tons', N'd2506bf0-76ce-4281-849d-d1c7fab30868')
GO
INSERT [dbo].[TemperatureDetails] ([Value1], [Value2], [Id]) VALUES (CAST(1.80 AS Numeric(3, 2)), CAST(32 AS Numeric(3, 0)), N'6e6a459a-10ff-4424-9ced-5c6aa5c5286e')
GO
