DROP PROCEDURE IF EXISTS dbo.purchaseschedule_SelectData

GO

CREATE PROCEDURE [dbo].[purchaseschedule_SelectData]
(  
	@PropertyID uniqueidentifier = null,  
	@CompanyID uniqueidentifier = null,  
	@PropertyName nvarchar(65) = null	
)  
AS  
BEGIN  

	SELECT PS.PurchaseScheduleID, P.PropertyID, P.PropertyName, P.PurchaseOptionID, P.Price, P.PurchaseArea, 
	       P.TotalCost,P.InstallmentTypeTerm,P.TotalPaymentMonth
	-- COUNT(PS.PurchaseScheduleID) AS PurchaseScheduleCount

	SELECT P.PropertyID, P.PropertyName, P.PurchaseOptionID, P.Price, P.PurchaseArea, P.TotalCost, PS.PurchaseScheduleID, NULLIF(PS.Installment, '') AS 'Installment'
		FROM propertypurchase_schedule PS
		INNER JOIN mst_property P ON P.PropertyID = PS.PropertyID	
		INNER JOIN tra_partnerpayment PP ON PP.PropertyPurchaseScheduleID != PS.PurchaseScheduleID
		
	WHERE   
		ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
		ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyID, ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and    
		ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%' and   
		ISNULL(PS.IsActive,1) = 1
	

	SELECT PRT.PartnerID, PRT.DisplayName AS 'PartnerName'
	FROM  mst_propertypartner PP
		INNER JOIN mst_Partner PRT ON PRT.PartnerID = PP.PartnerID
		INNER JOIN mst_property P ON P.PropertyID = PP.PropertyID		
	WHERE
		ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyID, ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and    
		ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%' and   
		ISNULL(PP.IsActive,1) = 1
		
END