DROP PROCEDURE IF EXISTS dbo.PartnerPayment_DeleteByPrimaryKey

GO

CREATE PROCEDURE [dbo].[PartnerPayment_DeleteByPrimaryKey]
(
	@PartnerPaymentID uniqueidentifier,
	@PaymentAmount DECIMAL(18,2),
	@PropertyPurchaseScheduleID UNIQUEIDENTIFIER,
	@PropertyID UNIQUEIDENTIFIER,
	@PartnerID UNIQUEIDENTIFIER,
	@Installment VARCHAR(50)
)
AS
BEGIN


	UPDATE propertypurchase_schedule
	SET TotalPaid = TotalPaid - @PaymentAmount, TotalDue = TotalDue + @PaymentAmount	 
	WHERE PurchaseScheduleID = @PropertyPurchaseScheduleID AND IsActive = 1

	UPDATE purchasepartner_schedule
	SET TotalPaid = TotalPaid - @PaymentAmount, TotalDue = TotalDue + @PaymentAmount
	WHERE PropertyID = @PropertyID AND PartnerID = @PartnerID -- AND PurchaseScheduleID = @PropertyPurchaseScheduleID  
	AND Installment = @Installment
	AND IsActive = 1	
	
	UPDATE mst_propertypartner
	SET TotalInvested = TotalInvested - @PaymentAmount, TotalDue = TotalDue + @PaymentAmount	
	WHERE PropertyID = @PropertyID AND PartnerID = @PartnerID AND IsActive = 1	


	DELETE FROM [dbo].[tra_partnerpayment]
	 WHERE 
		[PartnerPaymentID] = @PartnerPaymentID AND IsActive = 1

END