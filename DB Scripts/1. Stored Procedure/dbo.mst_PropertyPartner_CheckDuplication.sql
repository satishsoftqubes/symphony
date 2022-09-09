DROP PROCEDURE IF EXISTS dbo.mst_PropertyPartner_CheckDuplication

GO

CREATE PROCEDURE dbo.mst_PropertyPartner_CheckDuplication
(  
	@PropertyID UNIQUEIDENTIFIER = null,
	@PartnerID UNIQUEIDENTIFIER = null	
)  
AS  
BEGIN  

	SELECT COUNT(PropertyPartnerID) AS PropertyPartnerCount FROM mst_propertypartner WHERE PropertyID = @PropertyID
	AND PartnerID = @PartnerID

END