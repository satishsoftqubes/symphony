DROP PROCEDURE IF EXISTS dbo.mst_Property_DeleteByPrimaryKey

GO

CREATE PROCEDURE [dbo].[mst_Property_DeleteByPrimaryKey]
(
	@PropertyID uniqueidentifier
)
AS
BEGIN

-- property partner
DELETE FROM [dbo].[mst_propertypartner]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1

-- purchase schedule	
DELETE FROM [dbo].[propertypurchase_schedule]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1

-- purchase partner
DELETE FROM [dbo].[purchasepartner_schedule]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1
	
-- property 
DELETE FROM [dbo].[mst_Property]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1

	
END