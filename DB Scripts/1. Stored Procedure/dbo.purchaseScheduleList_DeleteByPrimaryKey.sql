DROP PROCEDURE IF EXISTS dbo.purchaseScheduleList_DeleteByPrimaryKey

GO

CREATE PROCEDURE [dbo].[purchaseScheduleList_DeleteByPrimaryKey]
(
	@PropertyID uniqueidentifier
)
AS
BEGIN

DELETE FROM [dbo].[propertypurchase_schedule]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1
	
DELETE FROM [dbo].[mst_propertypartner]
WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1
	
DELETE FROM [dbo].[purchasepartner_schedule]
WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1

END