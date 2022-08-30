DROP PROCEDURE IF EXISTS dbo.propertyListForPurchaseSchedule

GO

CREATE PROCEDURE [dbo].[propertyListForPurchaseSchedule]
(  
	@PropertyID uniqueidentifier = null,  
	@CompanyID uniqueidentifier = null,  
	@PropertyName nvarchar(65) = null	
)  
AS  
BEGIN  

SELECT DISTINCT
 mst_Property.PropertyID, mst_Property.CompanyID, PropertyName
 FROM [dbo].[mst_Property]  
 INNER JOIN propertypurchase_schedule PS on PS.PropertyID = mst_Property.PropertyID
	
 WHERE   
 ISNULL(mst_Property.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(mst_Property.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
 ISNULL(mst_Property.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyID, ISNULL(mst_Property.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
 ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%' and
 ISNULL(mst_Property.IsActive,1) = 1 
 
END