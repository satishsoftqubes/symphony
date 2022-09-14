DROP PROCEDURE IF EXISTS dbo.purchaseScheduleList_DeleteByPrimaryKey

GO

CREATE PROCEDURE [dbo].[purchaseScheduleList_DeleteByPrimaryKey]
(
	@PropertyID uniqueidentifier
)
AS
BEGIN

-- purchase schedule
DELETE FROM [dbo].[propertypurchase_schedule]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1

-- purchase partner schedule
DELETE FROM [dbo].[purchasepartner_schedule]
WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1
	
-- partner payment
DELETE FROM [dbo].[tra_partnerpayment]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1

END