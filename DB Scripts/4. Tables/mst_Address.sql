DROP TABLE dbo.mst_Address
USE [symphony_sakariyagroup]
GO

/****** Object:  Table [dbo].[mst_Address]    Script Date: 9/9/2022 6:04:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mst_Address](
	[AddressID] [uniqueidentifier] NOT NULL,
	[CompanyID] [uniqueidentifier] NULL,
	[Add1] [nvarchar](380) NULL,
	[Add2] [nvarchar](380) NULL,
	[Add3] [nvarchar](220) NULL,
	[CityID] [uniqueidentifier] NULL,
	[ZipCode] [nvarchar](13) NULL,
	[StateID] [uniqueidentifier] NULL,
	[CountryID] [uniqueidentifier] NULL,
	[City] [nvarchar](78) NULL,
	[AddressTypeTermID] [uniqueidentifier] NULL,
	[RetAddressID] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL,
	[UpdateLog] [timestamp] NULL,
	[IsSynch] [bit] NULL,
	[SynchOn] [datetime] NULL,
	[SeqNo] [int] IDENTITY(1,1) NOT NULL,
	[PropertyID] [uniqueidentifier] NULL,
	[AssociationID] [uniqueidentifier] NULL,
	[AssociationType] [nvarchar](65) NULL,
	[Village] [nvarchar](65) NULL,
 CONSTRAINT [PK_mst_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[mst_Address]  WITH CHECK ADD  CONSTRAINT [FK_mst_Address_mst_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[mst_City] ([CityID])
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[mst_Address] CHECK CONSTRAINT [FK_mst_Address_mst_City]
GO


