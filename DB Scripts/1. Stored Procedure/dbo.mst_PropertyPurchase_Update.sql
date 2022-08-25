DROP PROCEDURE IF EXISTS dbo.mst_PropertyPurchase_Update

GO

CREATE PROCEDURE dbo.mst_PropertyPurchase_Update
(
	@PropertyID uniqueidentifier,		
	@PurchaseOptionID uniqueidentifier = null,
	@Price decimal(18,2) = null,
	@PurchaseArea decimal(18,2) = null,
	@TotalCost decimal(18,2) = null	
)
AS
BEGIN
UPDATE [dbo].[mst_Property]
SET
	[PurchaseOptionID] = @PurchaseOptionID,
	[Price] = @Price,
	[PurchaseArea] = @PurchaseArea,
	[TotalCost] = @TotalCost	
	
 WHERE 
	[PropertyID] = @PropertyID
END