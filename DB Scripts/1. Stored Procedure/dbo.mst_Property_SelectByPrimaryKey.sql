DROP PROCEDURE IF EXISTS dbo.mst_Property_SelectByPrimaryKey

GO

CREATE PROCEDURE dbo.mst_Property_SelectByPrimaryKey
(
	@PropertyID uniqueidentifier
)
AS
BEGIN
	SELECT 
		[PropertyID], [CompanyID], [SeqNo], [PropertyTypeID], [PropertyCode], [PropertyName], [AddressID], [PropManagerName], [PrimaryContactNo], [PrimaryEmail], [PrimaryFax], [PropertyDisplayName], [PropertyRegisteredOn], [PropertyRegisteredBy], [PropertyCreatedOn], [IsApproved], [ApprovedBy], [ApprovedOn], [PropertyRating], [PropertyComments], [LastUpdateOn], [LastUpdateBy], [IsSynch], [IsActive], [ActivationKey], [ActivationCode], [LicenseNoOfUsers], [Thumb], [SynchOn], [UpdateLog], [SBArea], [CarpetArea], [PhotoLocal], [SBAreaCommercial], [KhataNo], [BuldingPlanApprovalNo], [KPSBNoc], [SEACNOC], [CertificationNo], [LicenceNo],
		[PurchaseOptionID], [SurveyNo], [Jantri], [PropertyStatusID], [Price], [PurchaseArea], [TotalCost]
	FROM [dbo].[mst_Property]
	WHERE 
			[PropertyID] = @PropertyID
END

