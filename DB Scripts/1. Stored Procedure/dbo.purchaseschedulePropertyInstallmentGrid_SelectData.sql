DROP PROCEDURE IF EXISTS dbo.purchaseschedulePropertyInstallmentGrid_SelectData

GO

CREATE PROCEDURE [dbo].[purchaseschedulePropertyInstallmentGrid_SelectData]
(  
	@PropertyID uniqueidentifier = null,  
	@CompanyID uniqueidentifier = null,  
	@PropertyName nvarchar(65) = null	
)  
AS  
BEGIN  

	SELECT PS.PurchaseScheduleID, PS.InstallmentTypeTerm, PS.InstallmentAmount, PS.InstallmentInPercentage, PS.MOPTerm,
			P1.TermID 'InstallmentTypeTermID', P2.TermID 'MOPTermID',PS.Date
		FROM propertypurchase_schedule PS
		INNER JOIN mst_property P ON P.PropertyID = PS.PropertyID
		LEFT JOIN mst_ProjectTerm P1 on P1.Term = PS.InstallmentTypeTerm and P1.Category = 'PAYMENTPERIOD' 
		LEFT JOIN mst_ProjectTerm P2 on P2.Term = PS.MOPTerm  
	WHERE   
		ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(P.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
		ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyID, ISNULL(P.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and    
		ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%' and   
		ISNULL(PS.IsActive,1) = 1
	GROUP BY P.PropertyID, P.PropertyName, P.PurchaseOptionID, P.Price, P.PurchaseArea, P.TotalCost, PS.PurchaseScheduleID, PS.InstallmentTypeTerm, PS.InstallmentAmount,
	PS.InstallmentInPercentage, PS.MOPTerm, P1.TermID, P2.TermID,PS.Date
END