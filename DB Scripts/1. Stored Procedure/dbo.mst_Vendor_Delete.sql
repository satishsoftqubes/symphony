DROP PROCEDURE dbo.mst_VendorDelete_IdWise
GO

CREATE PROCEDURE [dbo].[mst_VendorDelete_IdWise](
@VendorID uniqueidentifier 
)
AS
BEGIN
UPDATE mst_vendor SET 
      IsActive = 0 WHERE VendorID = @VendorID
END