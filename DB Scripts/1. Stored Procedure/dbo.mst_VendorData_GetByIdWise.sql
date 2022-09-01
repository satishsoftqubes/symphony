DROP PROCEDURE dbo.mst_VendorData_GetByIdWise
GO

CREATE PROCEDURE [dbo].[mst_VendorData_GetByIdWise](
@VendorID uniqueidentifier
)
AS
BEGIN
SELECT VendorID,VendorName,ContactName,Email,MobileNo,vendorDetail
FROM mst_vendor
WHERE IsActive = 1 
AND VendorID = @VendorID
END