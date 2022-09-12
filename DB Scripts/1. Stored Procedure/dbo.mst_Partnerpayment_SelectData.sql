DROP PROCEDURE IF EXISTS dbo.mst_Partnerpayment_SelectData

GO

CREATE PROCEDURE dbo.mst_Partnerpayment_SelectData
(  
	@PartnerID UNIQUEIDENTIFIER = null,
	@PropertyID UNIQUEIDENTIFIER = null,
	@PurchaseScheduleID UNIQUEIDENTIFIER = null
)  
AS  
BEGIN  

	SELECT PartnerPaymentID, PartnerID, PropertyID, PropertyPurchaseScheduleID, PaymentAmount, 
		MOPTerm, BankName, ChequeNo, TransactionDate, ReceivedBy, SeqNo, IsActive, UpdateLog, UploadDocument, Description
	FROM tra_partnerpayment 
	WHERE   	
		PartnerID = @PartnerID and
		PropertyID = @PropertyID and
		PropertyPurchaseScheduleID = @PurchaseScheduleID 
END