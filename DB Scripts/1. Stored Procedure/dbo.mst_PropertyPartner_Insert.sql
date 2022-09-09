DROP PROCEDURE IF EXISTS dbo.mst_PropertyPartner_Insert

GO

CREATE PROCEDURE dbo.mst_PropertyPartner_Insert
(
	@PropertyPartnerID uniqueidentifier ,
	@PropertyID uniqueidentifier ,
	@PartnerID uniqueidentifier ,
	@AddedOn DATETIME = null,
	@PartnershipInPercentage DECIMAL(18,2) = null,
	@TotalToInvest DECIMAL(18,2) = null,
	@TotalDue DECIMAL(18,2) = null,
	@TotalInvested DECIMAL(18,2) = null,
	@PartnershipDissolveOn DATETIME = null,
	@StatusTerm VARCHAR(39) = null, 
	@SeqNo int = null ,
	@IsActive bit = null ,
	@PartnerLegalName VARCHAR(161) = null,
	@Description VARCHAR(3710) = null	
)
AS
BEGIN

INSERT [dbo].[mst_propertypartner]
(
	[PropertyPartnerID],
	[PropertyID],
	[PartnerID],
	[AddedOn],
	[PartnershipInPercentage],
	[TotalToInvest],
	[TotalDue],
	[TotalInvested],
	[PartnershipDissolveOn],
	[StatusTerm],	
	[IsActive],
	[PartnerLegalName],
	[Description]
)
VALUES
(
	@PropertyPartnerID,
	@PropertyID,
	@PartnerID,
	CURRENT_TIMESTAMP,
	@PartnershipInPercentage,
	@TotalToInvest,
	@TotalDue,
	@TotalInvested,
	@PartnershipDissolveOn,
	'Active',	
	1,
	@PartnerLegalName,
	@Description
)

END