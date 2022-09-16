DROP PROCEDURE dbo.mst_VendorData_GetByIdWise
GO

CREATE PROCEDURE [dbo].[mst_VendorData_GetByIdWise](
@VendorID uniqueidentifier
)
AS
BEGIN
SELECT VendorID,VendorName,ContactName,Email,MobileNo,vendorDetail,DisplayTerm,TypeID
FROM mst_vendor mv LEFT JOIN mst_ProjectTerm mp ON mp.TermID = mv.TypeID
WHERE mv.IsActive = 1 
AND VendorID = @VendorID
END