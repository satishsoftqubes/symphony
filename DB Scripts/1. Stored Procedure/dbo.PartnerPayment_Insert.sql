DROP PROCEDURE IF EXISTS dbo.PartnerPayment_Insert

GO

CREATE PROCEDURE dbo.PartnerPayment_Insert
(
	@PartnerPaymentID uniqueidentifier,
	@PartnerID uniqueidentifier,
	@PropertyID uniqueidentifier = null,
	@PropertyPurchaseScheduleID uniqueidentifier = null,
	@PaymentAmount DECIMAL(18,2) = null,
	@MOPTerm VARCHAR(39) = null,
	@BankName VARCHAR(61) = null,
	@ChequeNo VARCHAR(11) = null,
	@TransactionDate DATETIME = null,
	@ReceivedBy CHAR(38) = null,
	@UploadDocument VARCHAR(361) = null,
	@Description VARCHAR(3710) = null
)
AS
BEGIN

	-- purchase schedule insert
	INSERT [dbo].[tra_partnerpayment]
	(
		[PartnerPaymentID],
		[PartnerID],	
		[PropertyID] ,
		[PropertyPurchaseScheduleID] ,
		[PaymentAmount] ,
		[MOPTerm] ,
		[BankName] ,
		[ChequeNo] ,
		[TransactionDate] ,
		[ReceivedBy],
		[UploadDocument],
		[Description],
		[IsActive] ,
		[UpdateLog]
	)
	VALUES
	(
		@PartnerPaymentID,
		@PartnerID,
		@PropertyID,
		@PropertyPurchaseScheduleID,
		@PaymentAmount,
		@MOPTerm,
		@BankName,
		@ChequeNo,
		@TransactionDate,
		@ReceivedBy,
		@UploadDocument,
		@Description,
		1,
		CURRENT_TIMESTAMP
	)

	UPDATE propertypurchase_schedule
	SET TotalPaid = TotalPaid + @PaymentAmount, TotalDue = TotalDue - @PaymentAmount	 
	WHERE PurchaseScheduleID = @PropertyPurchaseScheduleID AND IsActive = 1

	UPDATE purchasepartner_schedule
	SET TotalPaid = TotalPaid + @PaymentAmount, TotalDue = TotalDue - @PaymentAmount
	WHERE PropertyID = @PropertyID AND PartnerID = @PartnerID AND PurchaseScheduleID = @PropertyPurchaseScheduleID  
	AND IsActive = 1	
	
	UPDATE mst_propertypartner
	SET TotalInvested = TotalInvested + @PaymentAmount, TotalDue = TotalDue - @PaymentAmount
	WHERE PropertyID = @PropertyID AND PartnerID = @PartnerID AND IsActive = 1	

END