DROP PROCEDURE IF EXISTS dbo.mst_PropertyPartner_Update

GO

CREATE PROCEDURE dbo.mst_PropertyPartner_Update
(
	@PropertyPartnerID uniqueidentifier ,
	@PropertyID uniqueidentifier ,
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
UPDATE [dbo].[mst_propertypartner]
SET
	
	[PropertyID] = @PropertyID,
	[AddedOn] = @AddedOn,
	[PartnershipInPercentage] = @PartnershipInPercentage,
	[TotalToInvest] = @TotalToInvest,
	[TotalDue] = @TotalDue,
	[TotalInvested] = @TotalInvested,	
	[PartnershipDissolveOn] = @PartnershipDissolveOn,
	[StatusTerm] = @StatusTerm,	
	[IsActive] = @IsActive,
	[PartnerLegalName] = @PartnerLegalName,
	[Description] = @Description
 WHERE 
	[PropertyPartnerID] = @PropertyPartnerID
END