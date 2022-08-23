DROP PROCEDURE IF EXISTS dbo.purchaseschedule_SelectData

GO

CREATE PROCEDURE dbo.purchaseschedule_SelectData
(  
	@PropertyID uniqueidentifier = null,  
	@CompanyID uniqueidentifier = null,  
	@PropertyName nvarchar(65) = null	
)  
AS  
BEGIN  

	SELECT P.PropertyID, P.PropertyName, COUNT(PS.PurchaseScheduleID) AS PurchaseScheduleCount
		FROM propertypurchase_schedule PS
		INNER JOIN mst_property P ON P.PropertyID = PS.PropertyID
	WHERE   
		ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
		ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyID, ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and    
		ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%' and   
		ISNULL(PS.IsActive,1) = 1
	GROUP BY P.PropertyID, P.PropertyName
END