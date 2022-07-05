DROP PROCEDURE IF EXISTS dbo.mst_Property_Insert

GO

CREATE PROCEDURE dbo.mst_Property_Insert
(
	@PropertyID uniqueidentifier ,
	@CompanyID uniqueidentifier = null ,
	@SeqNo int = null ,
	@PropertyTypeID uniqueidentifier = null ,
	@PropertyCode nvarchar(7) = null ,
	@PropertyName nvarchar(65) = null ,
	@AddressID uniqueidentifier = null ,
	@PropManagerName nvarchar(180) = null ,
	@PrimaryContactNo nvarchar(17) = null ,
	@PrimaryEmail nvarchar(180) = null ,
	@PrimaryFax nvarchar(17) = null ,
	@PropertyDisplayName nvarchar(35) = null ,
	@PropertyRegisteredOn datetime = null ,
	@PropertyRegisteredBy uniqueidentifier = null ,
	@PropertyCreatedOn datetime = null ,
	@IsApproved bit = null ,
	@ApprovedBy uniqueidentifier = null ,
	@ApprovedOn datetime = null ,
	@PropertyRating nvarchar(65) = null ,
	@PropertyComments nvarchar(MAX) = null ,
	@LastUpdateOn datetime = null ,
	@LastUpdateBy uniqueidentifier = null ,
	@IsSynch bit = null ,
	@IsActive bit = null ,
	@ActivationKey nvarchar(65) = null ,
	@ActivationCode nvarchar(65) = null ,
	@LicenseNoOfUsers int = null ,
	@Thumb nvarchar(MAX) = null ,
	@SynchOn datetime = null ,
	@SBArea decimal(18,2) = null ,
	@CarpetArea decimal(18,2) = null ,
	@PhotoLocal image = null ,
	@SBAreaCommercial decimal(18,2) = null ,
	@KhataNo nvarchar(MAX) = null ,
	@BuldingPlanApprovalNo nvarchar(MAX) = null ,
	@KPSBNoc nvarchar(MAX) = null ,
	@SEACNOC nvarchar(MAX) = null ,
	@CertificationNo nvarchar(MAX) = null ,
	@LicenceNo nvarchar(MAX) = null,
	@PurchaseOptionID uniqueidentifier = null,
	@SurveyNo nvarchar(65) = null,
	@PaymentTermID uniqueidentifier = null

)
AS
BEGIN

DECLARE @PropertyConfigurationID uniqueidentifier,	@ConPropertyID uniqueidentifier,	@ConSeqNo int,	@DateFormatID uniqueidentifier,	@TimeFormatID uniqueidentifier,
	@SmtpAddress nvarchar(360),	@POP3InServer nvarchar(360),	@POP3OutGoingServer nvarchar(360),	@UserName nvarchar(360),	@Password nvarchar(360),	@PrimoryDomainName nvarchar(360),
	@PrimoryEmail nvarchar(360),	@IsADPlugIn bit,	@DNSName nvarchar(360),	@BaseCurrencyCode nvarchar(50),	@NoOfCounters bit,	@IsSkipPostCode bit,	@IsSkipAddress bit,
	@IsSkipEmail bit,	@IsSkipContactNo bit,	@IsIdenticationReg bit,	@Updatelog timestamp,	@RoodDescription nvarchar(MAX),	@TubeDescription nvarchar(MAX),	@ByAirDescription nvarchar(MAX),
	@ByPublicTranspertation nvarchar(MAX),	@MapView nvarchar(MAX),	@ConLastUpdateOn datetime,	@ConLastUpdateBy uniqueidentifier,	@ConIsSynch bit,	@ConSynchOn datetime,
	@ConIsActive bit,	@ConCompanyID uniqueidentifier

INSERT [dbo].[mst_Property]
(
	[PropertyID],
	[CompanyID],
	[PropertyTypeID],
	[PropertyCode],
	[PropertyName],
	[AddressID],
	[PropManagerName],
	[PrimaryContactNo],
	[PrimaryEmail],
	[PrimaryFax],
	[PropertyDisplayName],
	[PropertyRegisteredOn],
	[PropertyRegisteredBy],
	[PropertyCreatedOn],
	[IsApproved],
	[ApprovedBy],
	[ApprovedOn],
	[PropertyRating],
	[PropertyComments],
	[LastUpdateOn],
	[LastUpdateBy],
	[IsSynch],
	[IsActive],
	[ActivationKey],
	[ActivationCode],
	[LicenseNoOfUsers],
	[Thumb],
	[SynchOn],
	[SBArea],
	[CarpetArea],
	[PhotoLocal],
	[SBAreaCommercial],
	[KhataNo],
	[BuldingPlanApprovalNo],
	[KPSBNoc],
	[SEACNOC],
	[CertificationNo],
	[LicenceNo],
	[PurchaseOptionID],
	[SurveyNo],
	[PaymentTermID]

)
VALUES
(
	@PropertyID,
	@CompanyID,
	@PropertyTypeID,
	@PropertyCode,
	@PropertyName,
	@AddressID,
	@PropManagerName,
	@PrimaryContactNo,
	@PrimaryEmail,
	@PrimaryFax,
	@PropertyDisplayName,
	@PropertyRegisteredOn,
	@PropertyRegisteredBy,
	@PropertyCreatedOn,
	@IsApproved,
	@ApprovedBy,
	@ApprovedOn,
	@PropertyRating,
	@PropertyComments,
	@LastUpdateOn,
	@LastUpdateBy,
	@IsSynch,
	@IsActive,
	@ActivationKey,
	@ActivationCode,
	@LicenseNoOfUsers,
	@Thumb,
	@SynchOn,
	@SBArea,
	@CarpetArea,
	@PhotoLocal,
	@SBAreaCommercial,
	@KhataNo,
	@BuldingPlanApprovalNo,
	@KPSBNoc,
	@SEACNOC,
	@CertificationNo,
	@LicenceNo,
	@PurchaseOptionID,
	@SurveyNo,
	@PaymentTermID

)

SELECT @PropertyConfigurationID = NEWID()

Select @ConPropertyID  = PropertyID,
	@DateFormatID = DateFormatID,
	@TimeFormatID  = TimeFormatID,
	@SmtpAddress  = SmtpAddress,
	@POP3InServer  = POP3InServer,
	@POP3OutGoingServer = POP3OutGoingServer,
	@UserName = UserName,
	@Password = [Password],
	@PrimoryDomainName = PrimoryDomainName,
	@PrimoryEmail = PrimoryEmail,
	@IsADPlugIn = IsADPlugIn,
	@DNSName = DNSName,
	@BaseCurrencyCode  = BaseCurrencyCode,
	@NoOfCounters = NoOfCounters,
	@IsSkipPostCode = IsSkipPostCode,
	@IsSkipAddress = IsSkipAddress,
	@IsSkipEmail = IsSkipEmail,
	@IsSkipContactNo = IsSkipContactNo,
	@IsIdenticationReg = IsIdenticationReg,
	@RoodDescription = RoodDescription,
	@TubeDescription = TubeDescription,
	@ByAirDescription = ByAirDescription,
	@ByPublicTranspertation = ByPublicTranspertation,
	@MapView = MapView,
	@ConLastUpdateOn = LastUpdateOn,
	@ConLastUpdateBy = LastUpdateBy,
	@ConIsSynch = IsSynch,
	@ConSynchOn = SynchOn,
	@ConIsActive = IsActive
from mst_PropertyConfiguration where PropertyID is NULL and CompanyID  = @CompanyID

EXEC [mst_PropertyConfiguration_Insert] 
	@PropertyConfigurationID,
	@PropertyID,
	null ,
	@DateFormatID,
	@TimeFormatID,
	@SmtpAddress,
	@POP3InServer,
	@POP3OutGoingServer,
	@UserName,
	@Password,
	@PrimoryDomainName,
	@PrimoryEmail,
	@IsADPlugIn,
	@DNSName,
	@BaseCurrencyCode,
	@NoOfCounters,
	@IsSkipPostCode,
	@IsSkipAddress,
	@IsSkipEmail,
	@IsSkipContactNo,
	@IsIdenticationReg,
	@RoodDescription,
	@TubeDescription,
	@ByAirDescription,
	@ByPublicTranspertation,
	@MapView,
	@ConLastUpdateOn,
	@ConLastUpdateBy,
	@ConIsSynch,
	@ConSynchOn,
	@ConIsActive,
	null,
	null

END