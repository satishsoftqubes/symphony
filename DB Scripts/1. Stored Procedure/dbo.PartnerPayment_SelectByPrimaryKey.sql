DROP PROCEDURE IF EXISTS dbo.PartnerPayment_SelectByPrimaryKey

GO

CREATE PROCEDURE dbo.PartnerPayment_SelectByPrimaryKey
(
	@PartnerPaymentID uniqueidentifier
)
AS
BEGIN
	SELECT 
		[PartnerPaymentID], [PartnerID], [PropertyID], [PropertyPurchaseScheduleID], [PaymentAmount], [MOPTerm], [BankName],
		[ChequeNo], [TransactionDate], [ReceivedBy], [UploadDocument], [Description]
	FROM [dbo].[tra_partnerpayment]
	WHERE 
			[PartnerPaymentID] = @PartnerPaymentID
END

