DROP PROCEDURE IF EXISTS dbo.mst_PropertyPartner_SelectByPrimaryKey

GO

CREATE PROCEDURE dbo.mst_PropertyPartner_SelectByPrimaryKey
(
	@PropertyPartnerID uniqueidentifier
)
AS
BEGIN
	SELECT 
		[PropertyPartnerID], [PropertyID], [PartnerID], [AddedOn], [partnershipInPercentage], [TotalToInvest], [TotalDue], [TotalInvested], [PartnershipDissolveOn], [StatusTerm], [SeqNo], [IsActive], [PartnerLegalName], [Description]
	FROM [dbo].[mst_propertypartner]
	WHERE 
			[PropertyPartnerID] = @PropertyPartnerID
END

