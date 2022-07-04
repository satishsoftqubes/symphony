DROP PROCEDURE IF EXISTS dbo.mst_Property_Update

GO

CREATE PROCEDURE dbo.mst_Property_Update
(
	@PropertyID uniqueidentifier,
	@CompanyID uniqueidentifier = null,
	@SeqNo int = null,
	@PropertyTypeID uniqueidentifier = null,
	@PropertyCode nvarchar(7) = null,
	@PropertyName nvarchar(65) = null,
	@AddressID uniqueidentifier = null,
	@PropManagerName nvarchar(180) = null,
	@PrimaryContactNo nvarchar(17) = null,
	@PrimaryEmail nvarchar(180) = null,
	@PrimaryFax nvarchar(17) = null,
	@PropertyDisplayName nvarchar(35) = null,
	@PropertyRegisteredOn datetime = null,
	@PropertyRegisteredBy uniqueidentifier = null,
	@PropertyCreatedOn datetime = null,
	@IsApproved bit = null,
	@ApprovedBy uniqueidentifier = null,
	@ApprovedOn datetime = null,
	@PropertyRating nvarchar(65) = null,
	@PropertyComments nvarchar(MAX) = null,
	@LastUpdateOn datetime = null,
	@LastUpdateBy uniqueidentifier = null,
	@IsSynch bit = null,
	@IsActive bit = null,
	@ActivationKey nvarchar(65) = null,
	@ActivationCode nvarchar(65) = null,
	@LicenseNoOfUsers int = null,
	@Thumb nvarchar(MAX) = null,
	@SynchOn datetime = null,
	@UpdateLog timestamp = null,
	@SBArea decimal(18,2) = null,
	@CarpetArea decimal(18,2) = null,
	@PhotoLocal image = null,
	@SBAreaCommercial decimal(18,2) = null,
	@KhataNo nvarchar(MAX) = null,
	@BuldingPlanApprovalNo nvarchar(MAX) = null,
	@KPSBNoc nvarchar(MAX) = null,
	@SEACNOC nvarchar(MAX) = null,
	@CertificationNo nvarchar(MAX) = null,
	@LicenceNo nvarchar(MAX) = null,
	@PurchaseOptionID uniqueidentifier = null

)
AS
BEGIN
UPDATE [dbo].[mst_Property]
SET
	[PropertyID] = @PropertyID,
	[CompanyID] = @CompanyID,
	[PropertyTypeID] = @PropertyTypeID,
	[PropertyCode] = @PropertyCode,
	[PropertyName] = @PropertyName,
	[AddressID] = @AddressID,
	[PropManagerName] = @PropManagerName,
	[PrimaryContactNo] = @PrimaryContactNo,
	[PrimaryEmail] = @PrimaryEmail,
	[PrimaryFax] = @PrimaryFax,
	[PropertyDisplayName] = @PropertyDisplayName,
	[PropertyRegisteredOn] = @PropertyRegisteredOn,
	[PropertyRegisteredBy] = @PropertyRegisteredBy,
	[PropertyCreatedOn] = @PropertyCreatedOn,
	[IsApproved] = @IsApproved,
	[ApprovedBy] = @ApprovedBy,
	[ApprovedOn] = @ApprovedOn,
	[PropertyRating] = @PropertyRating,
	[PropertyComments] = @PropertyComments,
	[LastUpdateOn] = @LastUpdateOn,
	[LastUpdateBy] = @LastUpdateBy,
	[IsSynch] = @IsSynch,
	[IsActive] = @IsActive,
	[ActivationKey] = @ActivationKey,
	[ActivationCode] = @ActivationCode,
	[LicenseNoOfUsers] = @LicenseNoOfUsers,
	[Thumb] = @Thumb,
	[SynchOn] = @SynchOn,
	[SBArea] = @SBArea,
	[CarpetArea] = @CarpetArea,
	[PhotoLocal] = @PhotoLocal,
	[SBAreaCommercial] = @SBAreaCommercial,
	[KhataNo] = @KhataNo,
	[BuldingPlanApprovalNo] = @BuldingPlanApprovalNo,
	[KPSBNoc] = @KPSBNoc,
	[SEACNOC] = @SEACNOC,
	[CertificationNo] = @CertificationNo,
	[LicenceNo] = @LicenceNo,
	[PurchaseOptionID] = @PurchaseOptionID
 WHERE 
	[PropertyID] = @PropertyID
END