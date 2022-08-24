DROP PROCEDURE IF EXISTS dbo.mst_SalePartnerData_GetByIdWise

GO

ALTER PROCEDURE [dbo].[mst_SalePartnerData_GetByIdWise](
@PartnerID uniqueidentifier
)
AS
BEGIN
SELECT FirstName,LastName,MiddleName,MobileNo FROM mst_partner WHERE PartnerID = @PartnerID;
END