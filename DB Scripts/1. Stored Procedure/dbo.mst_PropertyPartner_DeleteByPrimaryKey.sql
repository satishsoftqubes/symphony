DROP PROCEDURE IF EXISTS dbo.mst_PropertyPartner_DeleteByPrimaryKey

GO

CREATE PROCEDURE [dbo].[mst_PropertyPartner_DeleteByPrimaryKey]
(
	@PropertyPartnerID uniqueidentifier
)
AS
BEGIN

DELETE FROM [dbo].[mst_propertypartner]
 WHERE 
	[PropertyPartnerID] = @PropertyPartnerID AND IsActive = 1

END