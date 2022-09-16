USE [symphony_sakariyagroup]
GO

/****** Object:  Table [dbo].[mst_Property]    Script Date: 9/12/2022 11:36:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mst_Property](
	[PropertyID] [uniqueidentifier] NOT NULL,
	[CompanyID] [uniqueidentifier] NULL,
	[SeqNo] [int] IDENTITY(1,1) NOT NULL,
	[PropertyTypeID] [uniqueidentifier] NULL,
	[PropertyCode] [nvarchar](7) NULL,
	[PropertyName] [nvarchar](65) NULL,
	[AddressID] [uniqueidentifier] NULL,
	[PropManagerName] [nvarchar](180) NULL,
	[PrimaryContactNo] [nvarchar](17) NULL,
	[PrimaryEmail] [nvarchar](180) NULL,
	[PrimaryFax] [nvarchar](17) NULL,
	[PropertyDisplayName] [nvarchar](35) NULL,
	[PropertyRegisteredOn] [datetime] NULL,
	[PropertyRegisteredBy] [uniqueidentifier] NULL,
	[PropertyCreatedOn] [datetime] NULL,
	[IsApproved] [bit] NULL,
	[ApprovedBy] [uniqueidentifier] NULL,
	[ApprovedOn] [datetime] NULL,
	[PropertyRating] [nvarchar](65) NULL,
	[PropertyComments] [nvarchar](max) NULL,
	[LastUpdateOn] [datetime] NULL,
	[LastUpdateBy] [uniqueidentifier] NULL,
	[IsSynch] [bit] NULL,
	[IsActive] [bit] NULL,
	[ActivationKey] [nvarchar](65) NULL,
	[ActivationCode] [nvarchar](65) NULL,
	[LicenseNoOfUsers] [int] NULL,
	[Thumb] [nvarchar](max) NULL,
	[SynchOn] [datetime] NULL,
	[UpdateLog] [timestamp] NULL,
	[SBArea] [numeric](18, 2) NULL,
	[CarpetArea] [numeric](18, 2) NULL,
	[PhotoLocal] [image] NULL,
	[SBAreaCommercial] [numeric](18, 2) NULL,
	[KhataNo] [nvarchar](max) NULL,
	[BuldingPlanApprovalNo] [nvarchar](max) NULL,
	[KPSBNoc] [nvarchar](max) NULL,
	[SEACNOC] [nvarchar](max) NULL,
	[CertificationNo] [nvarchar](max) NULL,
	[LicenceNo] [nvarchar](max) NULL,
	[PurchaseOptionID] [uniqueidentifier] NULL,
	[SurveyNo] [nvarchar](65) NULL,
	[PaymentTermID] [uniqueidentifier] NULL,
	[Jantri] [decimal](18, 2) NULL,
	[PropertyStatusID] [uniqueidentifier] NULL,
	[Price] [decimal](18, 2) NULL,
	[PurchaseArea] [decimal](18, 2) NULL,
	[TotalCost] [decimal](18, 2) NULL,
	[InstallmentTypeTerm] [varchar](50) NULL,
	[TotalPaymentMonth] [int] NULL,
 CONSTRAINT [PK_mst_Property] PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


