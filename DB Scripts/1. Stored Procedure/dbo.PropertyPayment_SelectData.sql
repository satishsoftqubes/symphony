DROP PROCEDURE IF EXISTS dbo.PropertyPayment_SelectData

GO

CREATE PROCEDURE dbo.PropertyPayment_SelectData
(  
	@PropertyPaymentID UNIQUEIDENTIFIER = null,
	@PropertyID UNIQUEIDENTIFIER = null,
	@PartnerID UNIQUEIDENTIFIER = null,	
	@PurchaseScheduleID UNIQUEIDENTIFIER = null,
	@PropertyName VARCHAR(65) = null
)  
AS  
BEGIN  

	SELECT PropertyPaymentID, PP.PropertyID, PropertyScheduleID AS PurchaseScheduleID, AmountPaid, PP.MOPTerm, DateOfTransaction, BankName, ChequeNo,
		ChequeTo, OrderNo, UserID, Description, P.PropertyName AS 'PropertyName', PS.Installment AS 'Installment'
	FROM tra_propertypayment PP
	LEFT JOIN mst_property P ON P.PropertyID = PP.PropertyID	
	LEFT JOIN propertypurchase_schedule PS ON PS.PurchaseScheduleID = PP.PropertyScheduleID
	
	WHERE   	
		PropertyPaymentID = @PropertyPaymentID
		-- PP.PartnerID = @PartnerID and
		-- PP.PropertyID = @PropertyID and
		-- PP.PropertyPurchaseScheduleID = @PurchaseScheduleID and
		--ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%'
END