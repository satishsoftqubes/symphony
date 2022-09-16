DROP PROCEDURE IF EXISTS dbo.PartnerPayment_SelectData

GO

CREATE PROCEDURE dbo.PartnerPayment_SelectData
(  
	@PropertyID UNIQUEIDENTIFIER = null,
	@PartnerID UNIQUEIDENTIFIER = null,	
	@PurchaseScheduleID UNIQUEIDENTIFIER = null,
	@PropertyName VARCHAR(65) = null
)  
AS  
BEGIN  

	SELECT PartnerPaymentID, PP.PartnerID, PP.PropertyID, PropertyPurchaseScheduleID, PaymentAmount, 
		PP.MOPTerm, BankName, ChequeNo, TransactionDate, ReceivedBy, PP.SeqNo, PP.IsActive, PP.UpdateLog, UploadDocument, Description,
		P.PropertyName AS 'PropertyName', PRT.DisplayName AS 'PartnerName', NULLIF(PS.Installment, '') AS 'Installment'
		
	FROM tra_partnerpayment PP
	LEFT JOIN mst_property P ON P.PropertyID = PP.PropertyID
	LEFT JOIN mst_partner PRT ON PRT.PartnerID = PP.PartnerID
	LEFT JOIN propertypurchase_schedule PS ON PS.PurchaseScheduleID = PP.PropertyPurchaseScheduleID
	
	WHERE   	
		-- PP.PartnerID = @PartnerID and
		-- PP.PropertyID = @PropertyID and
		-- PP.PropertyPurchaseScheduleID = @PurchaseScheduleID and
		ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%'
END