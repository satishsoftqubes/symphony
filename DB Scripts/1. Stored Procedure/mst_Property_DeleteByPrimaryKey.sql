DROP PROCEDURE IF EXISTS dbo.mst_Property_DeleteByPrimaryKey

GO

CREATE PROCEDURE [dbo].[mst_Property_DeleteByPrimaryKey]
(
	@PropertyID uniqueidentifier
)
AS
BEGIN
DELETE FROM [dbo].[propertypurchase_schedule]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1

DELETE FROM [dbo].[mst_Property]
 WHERE 
	[PropertyID] = @PropertyID AND IsActive = 1
END