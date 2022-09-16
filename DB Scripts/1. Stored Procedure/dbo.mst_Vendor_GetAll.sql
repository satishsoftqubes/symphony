DROP PROCEDURE IF EXISTS dbo.mst_Vendor_GetAll
GO

CREATE PROCEDURE [dbo].[mst_Vendor_GetAll](
  @VendorName nvarchar(67),
  @MobileNo nvarchar(67)
)
AS
BEGIN
    SELECT VendorID,VendorName,ContactName,Email,MobileNo,DisplayTerm,TypeID
    FROM mst_vendor mv LEFT JOIN mst_ProjectTerm mp ON mp.TermID = mv.TypeID
    WHERE mv.IsActive = 1
	AND ISNULL(VendorName,'-aa#$$') = ISNULL(@VendorName, ISNULL(VendorName,'-aa#$$'))
	AND ISNULL(MobileNo,'-aa#$$') = ISNULL(@MobileNo,ISNULL(MobileNo,'-aa#55')) 
END