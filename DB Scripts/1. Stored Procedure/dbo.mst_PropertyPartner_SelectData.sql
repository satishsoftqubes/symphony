DROP PROCEDURE IF EXISTS dbo.mst_PropertyPartner_SelectData

GO

CREATE PROCEDURE dbo.mst_PropertyPartner_SelectData
(  
	@PropertyPartnerID UNIQUEIDENTIFIER = null,
	@PropertyName VARCHAR(65) = null,
	@CompanyID UNIQUEIDENTIFIER = null
)  
AS  
BEGIN  

	SELECT PP.PropertyPartnerID, PP.PropertyID, PP.PartnerID, P.PropertyName AS 'PropertyName', PRT.DisplayName AS 'PartnerName', P.CompanyID, PP.PartnershipInPercentage, PP.TotalToInvest, PP.TotalDue, PP.TotalInvested, PP.PartnershipDissolveOn, PP.Description
		FROM mst_propertypartner PP
	LEFT JOIN mst_property P ON P.PropertyID = PP.PropertyID
	LEFT JOIN mst_partner PRT ON PRT.PartnerID = PP.PartnerID
	WHERE   	
		-- ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyID, -- ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and 	
		ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%' and   
		PP.PropertyPartnerID = @PropertyPartnerID and
		ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) 
END