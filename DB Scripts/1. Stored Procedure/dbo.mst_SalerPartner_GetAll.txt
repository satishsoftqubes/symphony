DROP PROCEDURE IF EXISTS dbo.mst_SalerPartner_GetAll
GO
CREATE PROCEDURE [dbo].[mst_SalerPartner_GetAll](
@FirstName nvarchar(65) = null,
@MobileNo nvarchar(13) = null
)
AS
BEGIN

SELECT 
     PartnerID,
     ISNULL(FirstName,'') as FirstName,ISNULL(LastName,'') as LastName,
	 ISNULL(MiddleName,'') as MiddleName,ISNULL(DisplayName,'') as DisplayName,
	 ISNULl(MobileNo,'') as MobileNo,ISNULL(Email,'') as Email,
	 ISNULL(TotalProperties,0) as TotalProperties,ISNULL(TotalInvestment,0) as TotalInvestment,
	 ISNULL(UpdateLog,'') as UpdateLog
FROM mst_partner
WHERE IsActive = 1
AND ISNULL(FirstName,'-aa#$$') = ISNULL(@FirstName, ISNULL(FirstName,'-aa#$$')) 
AND ISNULL(MobileNo,'-aa#$$') = ISNULL(@MobileNo,ISNULL(MobileNo,'-aa#$$'))
END