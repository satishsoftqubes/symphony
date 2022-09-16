USE [symphony_sakariyagroup]
GO

/****** Object:  Table [dbo].[mst_vendor]    Script Date: 9/9/2022 5:24:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mst_vendor](
	[VendorID] [uniqueidentifier] NOT NULL,
	[CompanyID] [uniqueidentifier] NULL,
	[VendorName] [nvarchar](61) NULL,
	[ContactName] [nvarchar](61) NULL,
	[Email] [nvarchar](61) NULL,
	[MobileNo] [nvarchar](13) NULL,
	[AddressID] [uniqueidentifier] NULL,
	[VendorDetail] [nvarchar](max) NULL,
	[VendorType_Term] [nvarchar](17) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [char](38) NULL,
	[BusinessDomain_Term] [nvarchar](67) NULL,
	[Status_Term] [nvarchar](45) NULL,
	[LastBusinessDate] [datetime] NULL,
	[TotalBusiness] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[UpdateLog] [datetime] NULL,
	[SeqNo] [int] IDENTITY(1,1) NOT NULL,
	[PayableAcctID] [uniqueidentifier] NULL,
	[UpdatedBy] [char](38) NULL,
	[UpdatedOn] [datetime] NULL,
	[TypeID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [CompanyID]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [ContactName]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [Email]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [MobileNo]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [AddressID]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [VendorDetail]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [VendorType_Term]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [CreatedBy]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [BusinessDomain_Term]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [Status_Term]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [LastBusinessDate]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [TotalBusiness]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [IsActive]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [UpdateLog]
GO

ALTER TABLE [dbo].[mst_vendor] ADD  DEFAULT (NULL) FOR [PayableAcctID]
GO


